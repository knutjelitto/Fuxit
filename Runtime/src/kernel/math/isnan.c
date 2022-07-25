#include <math.h>

bool isnan(double x)
{
    return __fpclassify(x) == FP_NAN;
}