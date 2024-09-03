/**
 * @file main.cpp
 * @author pchuan98 (haeer98@outlook.com)
 * @brief Demo for stitching
 * @version 0.1
 * @date 2024-09-03
 *
 * @copyright Copyright (c) 2024
 *
 */

#include <iostream>
#include <fstream>
#include <string>
#include "opencv2/opencv_modules.hpp"
#include <opencv2/core/utility.hpp>
#include "opencv2/imgcodecs.hpp"
#include "opencv2/highgui.hpp"
#include "opencv2/stitching/detail/autocalib.hpp"
#include "opencv2/stitching/detail/blenders.hpp"
#include "opencv2/stitching/detail/timelapsers.hpp"
#include "opencv2/stitching/detail/camera.hpp"
#include "opencv2/stitching/detail/exposure_compensate.hpp"
#include "opencv2/stitching/detail/matchers.hpp"
#include "opencv2/stitching/detail/motion_estimators.hpp"
#include "opencv2/stitching/detail/seam_finders.hpp"
#include "opencv2/stitching/detail/warpers.hpp"
#include "opencv2/stitching/warpers.hpp"

#ifdef HAVE_OPENCV_XFEATURES2D
#include "opencv2/xfeatures2d.hpp"
#include "opencv2/xfeatures2d/nonfree.hpp"
#endif

using namespace std;
using namespace cv;
using namespace cv::detail;

void finder(
    vector<Mat> *images,
    vector<ImageFeatures> *features,
    Ptr<Feature2D> finder,
    double scale = 1.0)
{
    // todo 可以改成并行加速

    Mat full_img, img;
    auto num = images->size();

    for (int i = 0; i < num; ++i)
    {
        full_img = (*images)[i];
        img = full_img;

        if (abs(scale - 1.0) >= 1e-6)
            resize(full_img, img, Size(), scale, scale, INTER_LINEAR_EXACT);

        computeImageFeatures(finder, img, (*features)[i]);
        (*features)[i].img_idx = i;
    }

    full_img.release();
    img.release();
}

String matches2string(int count, std::vector<MatchesInfo> &pairwise_matches, float conf_threshold)
{
    std::stringstream str;
    std::set<std::pair<int, int>> span_tree_edges;
    DisjointSets comps(count);

    for (int i = 0; i < count; ++i)
    {
        for (int j = 0; j < count; ++j)
        {
            if (pairwise_matches[i * count + j].confidence < conf_threshold)
                continue;
            int comp1 = comps.findSetByElem(i);
            int comp2 = comps.findSetByElem(j);
            if (comp1 != comp2)
            {
                comps.mergeSets(comp1, comp2);
                span_tree_edges.insert(std::make_pair(i, j));
            }
        }
    }

    str << "src\tdest\tmatches\tinliers\tconfidence\n";
    for (std::set<std::pair<int, int>>::const_iterator itr = span_tree_edges.begin();
         itr != span_tree_edges.end(); ++itr)
    {
        std::pair<int, int> edge = *itr;
        if (span_tree_edges.find(edge) != span_tree_edges.end())
        {
            int pos = edge.first * count + edge.second;
            str << edge.first << "\t" << edge.second
                << "\t" << pairwise_matches[pos].matches.size()
                << "\t" << pairwise_matches[pos].num_inliers
                << "\t" << pairwise_matches[pos].confidence << "\n";
        }
    }

    return str.str().c_str();
}

void matcher(
    vector<ImageFeatures> *features,
    vector<MatchesInfo> *matches,
    Ptr<FeaturesMatcher> matcher)
{
    // todo 可以改成并行加速

    (*matcher)(*features, *matches);
    matcher->collectGarbage();
}

int main()
{
    vector<Mat> images = {
        imread("D:\\.test\\test_16C3\\1-2.tif"),
        imread("D:\\.test\\test_16C3\\1-3.tif"),
        imread("D:\\.test\\test_16C3\\1-4.tif"),
    };
    auto count = images.size();

    vector<ImageFeatures> features(count);
    finder(&images, &features, xfeatures2d::SURF::create());

    vector<MatchesInfo> matches;
    auto match_conf = 0.1f;
    auto conf_thresh = 0.1f;
    matcher(&features, &matches, makePtr<AffineBestOf2NearestMatcher>(false, false, match_conf));
    // matcher(&features, &matches, makePtr<BestOf2NearestMatcher>(false, match_conf));
    // matcher(&features, &matches, makePtr<BestOf2NearestRangeMatcher>(5, false, match_conf));
    cout << matches2string(count, matches, conf_thresh) << endl;

    auto indices = leaveBiggestComponent(features, matches, conf_thresh);
    cout << "indices: " << indices.size() << endl;

    // Mat img_match;

    // drawMatches(
    //     images[0], features[0].keypoints,
    //     images[1], features[1].keypoints,
    //     matches[1].matches,
    //     img_match,
    //     Scalar::all(-1),
    //     Scalar::all(-1),
    //     vector<char>(),
    //     DrawMatchesFlags::DEFAULT);

    // imshow("matches", img_match);
    // waitKey(0);

    printf("Program finished.\n");
}