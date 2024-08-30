/**
 * @file matexpr.hpp
 * @author pchuan98 (haeer98@outlook.com)
 * @brief
 * @version 0.1
 * @date 2024-08-30
 *
 * @copyright Copyright (c) 2024
 *
 */

#pragma once

#include "common.hpp"

API(ExceptionStatus)
api_matexpr_new1(cv::MatExpr **output)
{
    BEGIN_WRAP;
    *output = new cv::MatExpr();
    END_WRAP;
}

API(ExceptionStatus)
api_matexpr_new2(cv::Mat *mat, cv::MatExpr **output)
{
    BEGIN_WRAP;
    *output = new cv::MatExpr(*mat);
    END_WRAP;
}

// Size size() const;
API(CvSize)
api_matexpr_size(cv::MatExpr *expr)
{
    auto size = expr->size();
    return {size.width, size.height};
}

// int type() const;
API(int)
api_matexpr_type(cv::MatExpr *expr)
{
    return expr->type();
}

// MatExpr row(int y) const;
API(ExceptionStatus)
api_matexpr_row(cv::MatExpr *expr, int y, cv::MatExpr **output)
{
    BEGIN_WRAP;
    *output = new cv::MatExpr(expr->row(y));
    END_WRAP;
}

// MatExpr col(int x) const;
API(ExceptionStatus)
api_matexpr_col(cv::MatExpr *expr, int x, cv::MatExpr **output)
{
    BEGIN_WRAP;
    *output = new cv::MatExpr(expr->col(x));
    END_WRAP;
}

// MatExpr diag(int d = 0) const;
API(ExceptionStatus)
api_matexpr_diag(cv::MatExpr *expr, int d, cv::MatExpr **output)
{
    BEGIN_WRAP;
    *output = new cv::MatExpr(expr->diag(d));
    END_WRAP;
}

// MatExpr t() const;
API(ExceptionStatus)
api_matexpr_t(cv::MatExpr *expr, cv::MatExpr **output)
{
    BEGIN_WRAP;
    *output = new cv::MatExpr(expr->t());
    END_WRAP;
}

// MatExpr inv(int method = DECOMP_LU) const;
API(ExceptionStatus)
api_matexpr_inv(cv::MatExpr *expr, int method, cv::MatExpr **output)
{
    BEGIN_WRAP;
    *output = new cv::MatExpr(expr->inv(method));
    END_WRAP;
}

// MatExpr mul(const MatExpr& e, double scale=1) const;
API(ExceptionStatus)
api_matexpr_mul1(cv::MatExpr *expr, cv::MatExpr *e, double scale, cv::MatExpr **output)
{
    BEGIN_WRAP;
    *output = new cv::MatExpr(expr->mul(*e, scale));
    END_WRAP;
}

// MatExpr mul(const Mat& m, double scale=1) const;
API(ExceptionStatus)
api_matexpr_mul2(cv::Mat *mat, cv::Mat *m, double scale, cv::MatExpr **output)
{
    BEGIN_WRAP;
    *output = new cv::MatExpr(mat->mul(*m, scale));
    END_WRAP;
}

// Mat cross(const Mat& m) const;
API(ExceptionStatus)
api_matexpr_cross(cv::MatExpr *expr, cv::Mat *m, cv::Mat **output)
{
    BEGIN_WRAP;
    *output = new cv::Mat(expr->cross(*m));
    END_WRAP;
}

// double dot(const Mat& m) const;
API(double)
api_matexpr_dot(cv::MatExpr *expr, cv::Mat *m)
{
    return expr->dot(*m);
}

// void swap(MatExpr& b);
API(ExceptionStatus)
api_matexpr_swap(cv::MatExpr *expr, cv::MatExpr *b)
{
    BEGIN_WRAP;
    expr->swap(*b);
    END_WRAP;
}

#pragma region operators

// todo 还有很多类型好像写掉了，Matx以及Mat等的运算重载方法

// MatExpr operator()( const Range& rowRange, const Range& colRange ) const;
API(ExceptionStatus)
api_matexpr_operator_bracket(cv::MatExpr *expr, const cv::Range rowRange, const cv::Range colRange, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*expr)(rowRange, colRange);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}
// MatExpr operator()( const Rect& roi ) const;
API(ExceptionStatus)
api_matexpr_operator_bracket2(cv::MatExpr *expr, const cv::Rect roi, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*expr)(roi);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator + (const Mat& a, const Mat& b);
API(ExceptionStatus)
api_matexpr_operator_plus1(cv::Mat *a, cv::Mat *b, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) + (*b);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator + (const Mat& a, const Scalar& s);
API(ExceptionStatus)
api_matexpr_operator_plus2(cv::Mat *a, cv::Scalar s, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) + (s);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator + (const MatExpr& e, const Mat& m);
API(ExceptionStatus)
api_matexpr_operator_plus3(cv::MatExpr *e, cv::Mat *m, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*e) + (*m);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator + (const MatExpr& e, const Scalar& s);
API(ExceptionStatus)
api_matexpr_operator_plus4(cv::MatExpr *e, cv::Scalar s, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*e) + (s);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator + (const MatExpr& e1, const MatExpr& e2);
API(ExceptionStatus)
api_matexpr_operator_plus5(cv::MatExpr *e1, cv::MatExpr *e2, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*e1) + (*e2);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator - (const Mat& a, const Mat& b);
API(ExceptionStatus)
api_matexpr_operator_minus1(cv::Mat *a, cv::Mat *b, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) - (*b);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator - (const Mat& a, const Scalar& s);
API(ExceptionStatus)
api_matexpr_operator_minus2(cv::Mat *a, cv::Scalar s, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) - (s);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator - (const MatExpr& e, const Mat& m);
API(ExceptionStatus)
api_matexpr_operator_minus3(cv::MatExpr *e, cv::Mat *m, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*e) - (*m);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator - (const MatExpr& e, const Scalar& s);
API(ExceptionStatus)
api_matexpr_operator_minus4(cv::MatExpr *e, cv::Scalar s, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*e) - (s);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator - (const MatExpr& e1, const MatExpr& e2);
API(ExceptionStatus)
api_matexpr_operator_minus5(cv::MatExpr *e1, cv::MatExpr *e2, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*e1) - (*e2);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator - (const Mat& m);
API(ExceptionStatus)
api_matexpr_operator_minus6(cv::Mat *m, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = -(*m);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator - (const MatExpr& e);
API(ExceptionStatus)
api_matexpr_operator_minus7(cv::MatExpr *e, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = -(*e);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator * (const Mat& a, const Mat& b);
API(ExceptionStatus)
api_matexpr_operator_mul1(cv::Mat *a, cv::Mat *b, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) * (*b);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator * (const Mat& a, double s);
API(ExceptionStatus)
api_matexpr_operator_mul2(cv::Mat *a, double s, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) * s;
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator * (const MatExpr& e, const Mat& m);
API(ExceptionStatus)
api_matexpr_operator_mul3(cv::MatExpr *e, cv::Mat *m, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*e) * (*m);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator * (const MatExpr& e, double s);
API(ExceptionStatus)
api_matexpr_operator_mul4(cv::MatExpr *e, double s, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*e) * s;
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator * (const MatExpr& e1, const MatExpr& e2);
API(ExceptionStatus)
api_matexpr_operator_mul5(cv::MatExpr *e1, cv::MatExpr *e2, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*e1) * (*e2);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator / (const Mat& a, const Mat& b);
API(ExceptionStatus)
api_matexpr_operator_div1(cv::Mat *a, cv::Mat *b, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) / (*b);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator / (const Mat& a, double s);
API(ExceptionStatus)
api_matexpr_operator_div2(cv::Mat *a, double s, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) / s;
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator / (double s, const Mat& a);
API(ExceptionStatus)
api_matexpr_operator_div3(double s, cv::Mat *a, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = s / (*a);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator / (const MatExpr& e, const Mat& m);
API(ExceptionStatus)
api_matexpr_operator_div4(cv::MatExpr *e, cv::Mat *m, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*e) / (*m);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator / (const Mat& m, const MatExpr& e);
API(ExceptionStatus)
api_matexpr_operator_div5(cv::Mat *m, cv::MatExpr *e, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*m) / (*e);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator / (const MatExpr& e, double s);
API(ExceptionStatus)
api_matexpr_operator_div6(cv::MatExpr *e, double s, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*e) / s;
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator / (double s, const MatExpr& e);
API(ExceptionStatus)
api_matexpr_operator_div7(double s, cv::MatExpr *e, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = s / (*e);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator / (const MatExpr& e1, const MatExpr& e2);
API(ExceptionStatus)
api_matexpr_operator_div8(cv::MatExpr *e1, cv::MatExpr *e2, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*e1) / (*e2);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator < (const Mat& a, const Mat& b);
API(ExceptionStatus)
api_matexpr_operator_less1(cv::Mat *a, cv::Mat *b, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) < (*b);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator < (const Mat& a, double s);
API(ExceptionStatus)
api_matexpr_operator_less2(cv::Mat *a, double s, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) < s;
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator <= (const Mat& a, const Mat& b);
API(ExceptionStatus)
api_matexpr_operator_less_equal1(cv::Mat *a, cv::Mat *b, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) <= (*b);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator <= (const Mat& a, double s);
API(ExceptionStatus)
api_matexpr_operator_less_equal2(cv::Mat *a, double s, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) <= s;
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator <= (double s, const Mat& a);
API(ExceptionStatus)
api_matexpr_operator_less_equal3(double s, cv::Mat *a, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = s <= (*a);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator == (const Mat& a, const Mat& b);
API(ExceptionStatus)
api_matexpr_operator_equal1(cv::Mat *a, cv::Mat *b, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) == (*b);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator == (const Mat& a, double s);
API(ExceptionStatus)
api_matexpr_operator_equal2(cv::Mat *a, double s, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) == s;
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator != (const Mat& a, const Mat& b);
API(ExceptionStatus)
api_matexpr_operator_not_equal1(cv::Mat *a, cv::Mat *b, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) != (*b);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator != (const Mat& a, double s);
API(ExceptionStatus)
api_matexpr_operator_not_equal2(cv::Mat *a, double s, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) != s;
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator >= (const Mat& a, const Mat& b);
API(ExceptionStatus)
api_matexpr_operator_greater_equal1(cv::Mat *a, cv::Mat *b, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) >= (*b);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator >= (const Mat& a, double s);
API(ExceptionStatus)
api_matexpr_operator_greater_equal2(cv::Mat *a, double s, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) >= s;
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator > (const Mat& a, const Mat& b);
API(ExceptionStatus)
api_matexpr_operator_greater1(cv::Mat *a, cv::Mat *b, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) > (*b);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator > (const Mat& a, double s);
API(ExceptionStatus)
api_matexpr_operator_greater2(cv::Mat *a, double s, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) > s;
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator & (const Mat& a, const Mat& b);
API(ExceptionStatus)
api_matexpr_operator_and1(cv::Mat *a, cv::Mat *b, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) & (*b);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator & (const Mat& a, const Scalar& s);
API(ExceptionStatus)
api_matexpr_operator_and2(cv::Mat *a, cv::Scalar *s, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) & (*s);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator & (const Scalar& s, const Mat& a);
API(ExceptionStatus)
api_matexpr_operator_and3(cv::Scalar *s, cv::Mat *a, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*s) & (*a);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator | (const Mat& a, const Mat& b);
API(ExceptionStatus)
api_matexpr_operator_or1(cv::Mat *a, cv::Mat *b, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) | (*b);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator | (const Mat& a, const Scalar& s);
API(ExceptionStatus)
api_matexpr_operator_or2(cv::Mat *a, cv::Scalar *s, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) | (*s);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator | (const Scalar& s, const Mat& a);
API(ExceptionStatus)
api_matexpr_operator_or3(cv::Scalar *s, cv::Mat *a, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*s) | (*a);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator ^ (const Mat& a, const Mat& b);
API(ExceptionStatus)
api_matexpr_operator_xor1(cv::Mat *a, cv::Mat *b, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) ^ (*b);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator ^ (const Mat& a, const Scalar& s);
API(ExceptionStatus)
api_matexpr_operator_xor2(cv::Mat *a, cv::Scalar *s, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*a) ^ (*s);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator ^ (const Scalar& s, const Mat& a);
API(ExceptionStatus)
api_matexpr_operator_xor3(cv::Scalar *s, cv::Mat *a, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = (*s) ^ (*a);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr operator ~(const Mat& m);
API(ExceptionStatus)
api_matexpr_operator_not(cv::Mat *m, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = ~(*m);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

#pragma endregion

// CV_EXPORTS MatExpr min(const Mat& a, const Mat& b);
API(ExceptionStatus)
api_matexpr_min1(cv::Mat *a, cv::Mat *b, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = cv::min(*a, *b);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr min(const Mat& a, double s);
API(ExceptionStatus)
api_matexpr_min2(cv::Mat *a, double s, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = cv::min(*a, s);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr min(double s, const Mat& a);
API(ExceptionStatus)
api_matexpr_min3(double s, cv::Mat *a, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = cv::min(s, *a);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr max(const Mat& a, const Mat& b);
API(ExceptionStatus)
api_matexpr_max1(cv::Mat *a, cv::Mat *b, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = cv::max(*a, *b);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr max(const Mat& a, double s);
API(ExceptionStatus)
api_matexpr_max2(cv::Mat *a, double s, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = cv::max(*a, s);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr max(double s, const Mat& a);
API(ExceptionStatus)
api_matexpr_max3(double s, cv::Mat *a, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = cv::max(s, *a);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr abs(const Mat& m);
API(ExceptionStatus)
api_matexpr_abs1(cv::Mat *m, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = cv::abs(*m);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}

// CV_EXPORTS MatExpr abs(const MatExpr& e);
API(ExceptionStatus)
api_matexpr_abs2(cv::MatExpr *e, cv::MatExpr **output)
{
    BEGIN_WRAP;
    const auto ret = cv::abs(*e);
    *output = new cv::MatExpr(ret);
    END_WRAP;
}