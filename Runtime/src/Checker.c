#include <stdint.h>
#include <math.h>

double core_f64_ceil(double x)
{
    return __builtin_ceil(x);
}

double core_f64_floor(double x)
{
    return __builtin_floor(x);
}

double core_f64_trunc(double x)
{
    return __builtin_trunc(x);
}

double core_f64_nearest(double x)
{
    return __builtin_nearbyint(x);
}

double core_f64_sqrt(double x)
{
    return __builtin_sqrt(x);
}

double core_f64_min(double x, double y)
{
    return x <= y ? x : y;
}

double core_f64_max(double x, double y)
{
    return x >= y ?  x : y;
}

double core_f64_abs(double x)
{
    return __builtin_fabs(x);
}

double core_f64_neg(double x)
{
    return -(x);
}


