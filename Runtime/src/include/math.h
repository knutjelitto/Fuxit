#pragma once

#include <stdbool.h>
#include <stdint.h>

#define FP_NAN       0
#define FP_INFINITE  1
#define FP_ZERO      2
#define FP_SUBNORMAL 3
#define FP_NORMAL    4

#include <features.h>

#define NAN       __builtin_nanf("")
#define INFINITY  __builtin_inff()

hidden int      __fpclassify(double);

hidden int      __rem_pio2(double,double*);
hidden int      __rem_pio2_large(double*,double*,int,int,int);

hidden double   __sin(double,double,int);
hidden double   __cos(double,double);
hidden double   __tan(double,double,int);
hidden double   __expo2(double,double);

hidden double   __math_invalid(double);
hidden double   __math_uflow(uint32_t);
hidden double   __math_oflow(uint32_t);

bool         isnan(double);

static inline double core_math_ceil(double x)
{
    return __builtin_ceil(x);
}

static inline double core_math_floor(double x)
{
    return __builtin_floor(x);
}

double      acos(double);
double      acosh(double);
double      asin(double);
double      asinh(double);
double      atan(double);
double      atan2(double, double);
double      atanh(double);
double      cbrt(double);

double      copysign(double, double);
double      cos(double);
double      cosh(double);
double      erf(double);
double      erfc(double);
double      exp(double);
double      exp2(double);
double      expm1(double);
double      fabs(double);
double      fdim(double, double);

double      fma(double, double, double);
double      fmax(double, double);
double      fmin(double, double);
double      fmod(double, double);
double      frexp(double, int *);
double      hypot(double, double);
int         ilogb(double);
double      ldexp(double, int);
double      lgamma(double);
long long   llrint(double);
long long   llround(double);
double      log(double);
double      log10(double);
double      log1p(double);
double      log2(double);
double      logb(double);
long        lrint(double);
long        lround(double);
double      modf(double, double *);
double      nan(const char *);
double      nearbyint(double);
double      nextafter(double, double);
double      nexttoward(double, long double);
double      pow(double, double);
double      remainder(double, double);
double      remquo(double, double, int *);
double      rint(double);
double      round(double);
double      scalbln(double, long);
double      scalbn(double, int);
double      sin(double);
double      sinh(double);
double      sqrt(double);
double      tan(double);
double      tanh(double);
double      tgamma(double);
double      trunc(double);
