/**
 * @file orb.hpp
 * @author pchuan98 (haeer98@outlook.com)
 * @brief
 * @version 0.1
 * @date 2024-09-02
 *
 * @copyright Copyright (c) 2024
 *
 */

#pragma once

#include "common.hpp"
#include <opencv2/features2d.hpp>
#include <opencv2/xfeatures2d.hpp>

// CV_WRAP static Ptr<ORB> create(int nfeatures=500, float scaleFactor=1.2f, int nlevels=8, int edgeThreshold=31,
//     int firstLevel=0, int WTA_K=2, ORB::ScoreType scoreType=ORB::HARRIS_SCORE, int patchSize=31, int fastThreshold=20);

API(ExceptionStatus)
api_orb_create(
    int nFeatures, float scaleFactor, int nlevels, int edgeThreshold,
    int firstLevel, int wtaK, int scoreType, int patchSize, int fastThreshold,
    cv::Ptr<cv::ORB> **output)
{
    BEGIN_WRAP
    const auto ptr = cv::ORB::create(
        nFeatures, scaleFactor, nlevels, edgeThreshold, firstLevel, wtaK, static_cast<cv::ORB::ScoreType>(scoreType), patchSize, fastThreshold);
    *output = clone(ptr);
    END_WRAP
}

API(ExceptionStatus)
api_orb_ptr_get(cv::Ptr<cv::ORB> *ptr, cv::ORB **output)
{
    BEGIN_WRAP
    *output = ptr->get();
    END_WRAP
}

// CV_WRAP virtual void setMaxFeatures(int maxFeatures) = 0;
// CV_WRAP virtual int getMaxFeatures() const = 0;

API(ExceptionStatus)
api_orb_setMaxFeatures(cv::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setMaxFeatures(val);
    END_WRAP
}
API(int)
api_orb_getMaxFeatures(cv::ORB *obj)
{
    return obj->getMaxFeatures();
}

// CV_WRAP virtual void setScaleFactor(double scaleFactor) = 0;
// CV_WRAP virtual double getScaleFactor() const = 0;

API(ExceptionStatus)
api_orb_setScaleFactor(cv::ORB *obj, double val)
{
    BEGIN_WRAP
    obj->setScaleFactor(val);
    END_WRAP
}
API(double)
api_orb_getScaleFactor(cv::ORB *obj)
{
    return obj->getScaleFactor();
}

// CV_WRAP virtual void setNLevels(int nlevels) = 0;
// CV_WRAP virtual int getNLevels() const = 0;

API(ExceptionStatus)
api_orb_setNLevels(cv::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setNLevels(val);
    END_WRAP
}
API(int)
api_orb_getNLevels(cv::ORB *obj)
{
    return obj->getNLevels();
}

// CV_WRAP virtual void setEdgeThreshold(int edgeThreshold) = 0;
// CV_WRAP virtual int getEdgeThreshold() const = 0;

API(ExceptionStatus)
api_orb_setEdgeThreshold(cv::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setEdgeThreshold(val);
    END_WRAP
}
API(int)
api_orb_getEdgeThreshold(cv::ORB *obj)
{
    return obj->getEdgeThreshold();
}

// CV_WRAP virtual void setFirstLevel(int firstLevel) = 0;
// CV_WRAP virtual int getFirstLevel() const = 0;

API(ExceptionStatus)
api_orb_setFirstLevel(cv::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setFirstLevel(val);
    END_WRAP
}
API(int)
api_orb_getFirstLevel(cv::ORB *obj)
{
    return obj->getFirstLevel();
}

// CV_WRAP virtual void setWTA_K(int wta_k) = 0;
// CV_WRAP virtual int getWTA_K() const = 0;

API(ExceptionStatus)
api_orb_setWTA_K(cv::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setWTA_K(val);
    END_WRAP
}
API(int)
api_orb_getWTA_K(cv::ORB *obj)
{
    return obj->getWTA_K();
}

// CV_WRAP virtual void setScoreType(ORB::ScoreType scoreType) = 0;
// CV_WRAP virtual ORB::ScoreType getScoreType() const = 0;

API(ExceptionStatus)
api_orb_setScoreType(cv::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setScoreType(static_cast<cv::ORB::ScoreType>(val));
    END_WRAP
}
API(int)
api_orb_getScoreType(cv::ORB *obj)
{
    return static_cast<int>(obj->getScoreType());
}

// CV_WRAP virtual void setPatchSize(int patchSize) = 0;
// CV_WRAP virtual int getPatchSize() const = 0;

API(ExceptionStatus)
api_orb_setPatchSize(cv::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setPatchSize(val);
    END_WRAP
}
API(int)
api_orb_getPatchSize(cv::ORB *obj)
{
    return obj->getPatchSize();
}

// CV_WRAP virtual void setFastThreshold(int fastThreshold) = 0;
// CV_WRAP virtual int getFastThreshold() const = 0;

API(ExceptionStatus)
api_orb_setFastThreshold(cv::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setFastThreshold(val);
    END_WRAP
}
API(int)
api_orb_getFastThreshold(cv::ORB *obj)
{
    return obj->getFastThreshold();
}

// CV_WRAP virtual String getDefaultName() const CV_OVERRIDE;
// todo