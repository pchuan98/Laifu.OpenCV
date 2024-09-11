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

#define IN
#define OUT

void finder(
    IN vector<Mat> *images,
    OUT vector<ImageFeatures> *features,
    IN Ptr<Feature2D> finder,
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

String matches2string(
    int count,
    IN std::vector<MatchesInfo> &pairwise_matches,
    float conf_threshold)
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
    IN vector<ImageFeatures> *features,
    OUT vector<MatchesInfo> *matches,
    IN Ptr<FeaturesMatcher> matcher)
{
    // todo 可以改成并行加速

    (*matcher)(*features, *matches);
    matcher->collectGarbage();
}

void motion(
    IN vector<ImageFeatures> *features,
    IN vector<MatchesInfo> *matches,
    OUT vector<CameraParams> *cameras,
    OUT Ptr<Estimator> estimator,
    OUT Ptr<BundleAdjusterBase> adjuster,
    bool is_focals = false,
    bool is_ppx = false,
    bool is_ppy = false,
    bool is_aspect = false,
    bool is_else = false,
    bool is_wave_correct = false,
    double conf = 1.0)
{
    auto is_estimate = (*estimator)(*features, *matches, *cameras);
    if (!is_estimate)
    {
        cout << "!!!!!!!!!!!! Estimation failed. !!!!!!!!!!!!" << endl;
        return;
    }
    // else
    // {
    //     cout << "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX" << endl;
    //     for (size_t i = 0; i < cameras->size(); i++)
    //     {
    //         cout << "focal: " << (*cameras)[i].focal << endl;
    //         cout << "ppx: " << (*cameras)[i].ppx << endl;
    //         cout << "ppy: " << (*cameras)[i].ppy << endl;
    //         cout << "aspect: " << (*cameras)[i].aspect << endl;
    //         cout << "R: " << (*cameras)[i].R << endl;
    //         cout << "t: " << (*cameras)[i].t << endl;
    //     }
    //     cout << "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX" << endl;
    // }

    for (size_t i = 0; i < cameras->size(); ++i)
    {
        Mat R;
        (*cameras)[i].R.convertTo(R, CV_32F);
        (*cameras)[i].R = R;
    }

    adjuster->setConfThresh(conf);
    Mat_<uchar> refine_mask = Mat::zeros(3, 3, CV_8U);

    if (is_focals)
        refine_mask(0, 0) = 1;
    if (is_ppx)
        refine_mask(0, 1) = 1;
    if (is_ppy)
        refine_mask(0, 2) = 1;
    if (is_aspect)
        refine_mask(1, 1) = 1;
    if (is_else)
        refine_mask(1, 2) = 1;

    adjuster->setRefinementMask(refine_mask);

    auto is_adjust = (*adjuster)(*features, *matches, *cameras);
    if (!is_adjust)
    {
        cout << "!!!!!!!!!!!! Adjusting failed. !!!!!!!!!!!!" << endl;
        return;
    }

    // if (is_wave_correct)
    // {
    //     vector<Mat> rmats;
    //     for (size_t i = 0; i < cameras->size(); ++i)
    //         rmats.push_back(cameras[i].R.clone());
    //     waveCorrect(rmats, wave_correct);
    //     for (size_t i = 0; i < cameras.size(); ++i)
    //         cameras[i].R = rmats[i];
    // }
}

void warper(
    IN vector<Mat> *images,
    OUT vector<UMat> *images_warped,
    OUT vector<UMat> *masks_warped,
    OUT vector<Point> *corners,
    IN vector<CameraParams> *cameras,
    IN Ptr<WarperCreator> creator,
    double seam_work_aspect = 1.0)
{
    auto warper = creator->create(1.0f);
    auto count = cameras->size();

    corners->resize(count);
    images_warped->resize(count);
    masks_warped->resize(count);

    vector<UMat> masks(count);
    for (int i = 0; i < count; ++i)
    {
        masks[i].create((*images)[i].size(), CV_8U);
        masks[i].setTo(Scalar::all(255));
    }

    for (int i = 0; i < count; ++i)
    {
        Mat_<float> K;

        cameras->at(i).K().convertTo(K, CV_32F);

        float swa = (float)seam_work_aspect;
        K(0, 0) *= swa;
        K(0, 2) *= swa;
        K(1, 1) *= swa;
        K(1, 2) *= swa;

        (*corners)[i] = warper->warp(
            (*images)[i],
            K,
            (*cameras)[i].R,
            INTER_LINEAR,
            BORDER_REFLECT,
            (*images_warped)[i]);

        warper->warp(
            masks[i],
            K,
            (*cameras)[i].R,
            INTER_NEAREST,
            BORDER_CONSTANT,
            (*masks_warped)[i]);
    }
}

void compensator(
    IN vector<Point> *corners,
    IN vector<UMat> *images_warped,
    IN vector<UMat> *masks_warped,
    IN Ptr<ExposureCompensator> compensator,
    int feeds = 1,
    int filtering = 2,
    int block = 32)
{
    if (dynamic_cast<GainCompensator *>(compensator.get()))
    {
        GainCompensator *gcompensator = dynamic_cast<GainCompensator *>(compensator.get());
        gcompensator->setNrFeeds(feeds);
    }

    if (dynamic_cast<ChannelsCompensator *>(compensator.get()))
    {
        ChannelsCompensator *ccompensator = dynamic_cast<ChannelsCompensator *>(compensator.get());
        ccompensator->setNrFeeds(feeds);
    }

    if (dynamic_cast<BlocksCompensator *>(compensator.get()))
    {
        BlocksCompensator *bcompensator = dynamic_cast<BlocksCompensator *>(compensator.get());
        bcompensator->setNrFeeds(feeds);
        bcompensator->setNrGainsFilteringIterations(filtering);
        bcompensator->setBlockSize(block, block);
    }

    compensator->feed(*corners, *images_warped, *masks_warped);

    vector<Mat> gains;
    cout << "size: " << gains.size() << endl;
    compensator->getMatGains(gains);
    for (auto gain : gains)
        cout << gain << endl;
}

void seam(
    IN vector<Point> *corners,
    IN vector<UMat> *images_warped,
    IN vector<UMat> *masks_warped,
    Ptr<SeamFinder> seam_finder)
{
    auto size = images_warped->size();
    vector<UMat> images_warped_f(size);
    for (int i = 0; i < size; ++i)
        (*images_warped)[i].convertTo(images_warped_f[i], CV_32F);

    seam_finder->find(images_warped_f, *corners, *masks_warped);
}

int main()
{
    vector<Mat> images = {
        imread("D:\\.test\\stitch2\\3-4.jpg"),
        imread("D:\\.test\\stitch2\\3-5.jpg")
        // imread("D:\\.test\\test_16C3\\1-2.tif"),
        // imread("D:\\.test\\test_16C3\\1-3.tif"),
        // imread("D:\\.test\\test_16C3\\1-4.tif"),
        // imread("D:\\.test\\test_human\\0709\\src\\1_1.tif"),
        // imread("D:\\.test\\test_human\\0709\\src\\1_2.tif"),
        // imread("D:\\.test\\test_human\\0709\\src\\1_3.tif"),
        // imread("D:\\.test\\test_human\\0709\\src\\2_1.tif"),
        // imread("D:\\.test\\test_human\\0709\\src\\2_2.tif"),
        // imread("D:\\.test\\test_human\\0709\\src\\2_3.tif"),
        // imread("D:\\.test\\test_human\\0709\\src\\3_1.tif"),
        // imread("D:\\.test\\test_human\\0709\\src\\3_2.tif"),
        // imread("D:\\.test\\test_human\\0709\\src\\3_3.tif"),
    };
    auto count = images.size();

    auto scale = 0.6;
    vector<ImageFeatures> features(count);
    finder(&images, &features, SIFT::create(), scale);

    vector<MatchesInfo> matches;
    auto match_conf = 0.5f;
    auto conf_thresh = 0.1f;
    matcher(&features, &matches, makePtr<AffineBestOf2NearestMatcher>(false, false, match_conf));
    // matcher(&features, &matches, makePtr<BestOf2NearestMatcher>(false, match_conf));
    // matcher(&features, &matches, makePtr<BestOf2NearestRangeMatcher>(5, false, match_conf));
    // cout << matches2string(count, matches, conf_thresh) << endl;

    for (auto m : matches)
    {
        cout << m.src_img_idx << "\t"
             << m.dst_img_idx << "\t"
             << m.matches.size() << "\t"
             << m.num_inliers << "\t"
             << m.confidence << endl;
    }

    cout << "---------------------------------------" << endl;
    cout << "features size: " << features.size() << endl;
    cout << "matcher count: " << matches.size() << endl;
    auto indices = leaveBiggestComponent(features, matches, conf_thresh);
    cout << "features size: " << features.size() << endl;
    cout << "matcher count: " << matches.size() << endl;
    cout << "indices: " << indices.size() << endl;

    for (auto m : matches)
    {
        cout << m.src_img_idx << "\t"
             << m.dst_img_idx << "\t"
             << m.matches.size() << "\t"
             << m.num_inliers << "\t"
             << m.confidence << endl;
    }

    // Mat img_match, m1, m2;

    // resize(images[1], m1, Size(), scale, scale, INTER_LINEAR_EXACT);
    // resize(images[2], m2, Size(), scale, scale, INTER_LINEAR_EXACT);
    // drawMatches(
    //     m1, features[1].keypoints,
    //     m2, features[2].keypoints,
    //     matches[5].matches,
    //     img_match,
    //     Scalar::all(-1),
    //     Scalar::all(-1),
    //     vector<char>(),
    //     DrawMatchesFlags::DEFAULT);

    // imshow("matches", img_match);
    // waitKey(0);

    vector<CameraParams> cameras;
    Ptr<Estimator> estimator = makePtr<AffineBasedEstimator>();

    // Ptr<Estimator> estimator = makePtr<HomographyBasedEstimator>();
    // Ptr<BundleAdjusterAffine> adjuster = makePtr<BundleAdjusterAffine>();
    // Ptr<BundleAdjusterAffine> adjuster = makePtr<BundleAdjusterRay>();
    // Ptr<BundleAdjusterAffine> adjuster = makePtr<BundleAdjusterAffinePartial>();

    Ptr<BundleAdjusterBase> adjuster = makePtr<NoBundleAdjuster>();

    motion(&features, &matches, &cameras, estimator, adjuster, true, true, true, true, true, true, conf_thresh);

    for (size_t i = 0; i < cameras.size(); ++i)
    {
        Mat R;
        cameras[i].R.convertTo(R, CV_32F);
        cameras[i].R = R;
        cout << "===============================\n"
             << cameras[i].ppx << "\n"
             << cameras[i].ppy << "\n"
             << cameras[i].K() << "\n"
             << cameras[i].R << "\n"
             << cameras[i].t << endl;
    }

    // Ptr<WarperCreator> creator = makePtr<cv::PlaneWarper>();
    // Ptr<WarperCreator> creator = makePtr<cv::AffineWarper>();
    // Ptr<WarperCreator> creator = makePtr<cv::CylindricalWarper>();
    // Ptr<WarperCreator> creator = makePtr<cv::SphericalWarper>();
    // Ptr<WarperCreator> creator = makePtr<cv::FisheyeWarper>();
    // Ptr<WarperCreator> creator = makePtr<cv::StereographicWarper>();
    // Ptr<WarperCreator> creator = makePtr<cv::CompressedRectilinearWarper>(2.0f, 1.0f);
    // Ptr<WarperCreator> creator = makePtr<cv::CompressedRectilinearWarper>(1.5f, 1.0f);
    // Ptr<WarperCreator> creator = makePtr<cv::CompressedRectilinearPortraitWarper>(2.0f, 1.0f);
    // Ptr<WarperCreator> creator = makePtr<cv::CompressedRectilinearPortraitWarper>(1.5f, 1.0f);
    // Ptr<WarperCreator> creator = makePtr<cv::PaniniWarper>(2.0f, 1.0f);
    // Ptr<WarperCreator> creator = makePtr<cv::PaniniWarper>(1.5f, 1.0f);
    // Ptr<WarperCreator> creator = makePtr<cv::PaniniPortraitWarper>(2.0f, 1.0f);
    // Ptr<WarperCreator> creator = makePtr<cv::PaniniPortraitWarper>(1.5f, 1.0f);
    // Ptr<WarperCreator> creator = makePtr<cv::MercatorWarper>();
    // Ptr<WarperCreator> creator = makePtr<cv::TransverseMercatorWarper>();

    // vector<UMat> images_warped;
    // vector<UMat> masks_warped;
    // vector<Point> corners;

    // warper(&images, &images_warped, &masks_warped, &corners, &cameras, creator, 1.0);

    // Ptr<ExposureCompensator> excom = ExposureCompensator::createDefault(ExposureCompensator::NO);
    // Ptr<ExposureCompensator> excom = ExposureCompensator::createDefault(ExposureCompensator::GAIN);
    // Ptr<ExposureCompensator> excom = ExposureCompensator::createDefault(ExposureCompensator::GAIN_BLOCKS);
    // Ptr<ExposureCompensator> excom = ExposureCompensator::createDefault(ExposureCompensator::CHANNELS);
    // Ptr<ExposureCompensator> excom = ExposureCompensator::createDefault(ExposureCompensator::CHANNELS_BLOCKS);

    // compensator(&corners, &images_warped, &masks_warped, excom);

    // Ptr<SeamFinder> seam_finder = makePtr<detail::NoSeamFinder>();
    // Ptr<SeamFinder> seam_finder = makePtr<detail::VoronoiSeamFinder>();
    // Ptr<SeamFinder> seam_finder = makePtr<detail::GraphCutSeamFinder>(GraphCutSeamFinderBase::COST_COLOR);
    // Ptr<SeamFinder> seam_finder = makePtr<detail::GraphCutSeamFinder>(GraphCutSeamFinderBase::COST_COLOR_GRAD);
    // Ptr<SeamFinder> seam_finder = makePtr<detail::DpSeamFinder>(DpSeamFinder::COLOR);
    // Ptr<SeamFinder> seam_finder = makePtr<detail::DpSeamFinder>(DpSeamFinder::COLOR_GRAD);

    // vector<UMat> src_mask;
    // for (auto m : masks_warped)
    //     src_mask.push_back(m.clone());

    // seam(&corners, &images_warped, &masks_warped, seam_finder);

    // for (size_t i = 0; i < count; i++)
    // {
    //     imshow("src", src_mask[i]);
    //     imshow("dst", masks_warped[i]);
    //     waitKey(0);
    // }

    printf("Program finished.\n");
}
