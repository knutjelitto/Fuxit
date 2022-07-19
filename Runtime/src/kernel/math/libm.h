#pragma once

#include <assert.h>
#include <stdint.h>

#define predict_true(x) __builtin_expect(!!(x), 1)
#define predict_false(x) __builtin_expect(x, 0)

#define DBL_EPSILON 2.22044604925031308085e-16

#define asuint64(f) ((union{double _f; uint64_t _i;}){f})._i

#define GET_HIGH_WORD(hi,d)                       \
do {                                              \
  (hi) = asuint64(d) >> 32;                       \
} while (0)


#ifndef fp_force_evalf
#define fp_force_evalf fp_force_evalf
static inline void fp_force_evalf(float x)
{
	volatile float y;
	y = x;
}
#endif

#ifndef fp_force_eval
#define fp_force_eval fp_force_eval
static inline void fp_force_eval(double x)
{
	volatile double y;
	y = x;
}
#endif

#ifndef fp_force_evall
#define fp_force_evall fp_force_evall
static inline void fp_force_evall(long double x)
{
	volatile long double y;
	y = x;
}
#endif

#define FORCE_EVAL(x) do {                      \
	if (sizeof(x) == sizeof(float)) {           \
		fp_force_evalf(x);                      \
	} else if (sizeof(x) == sizeof(double)) {   \
		fp_force_eval(x);                       \
	} else {                                    \
		fp_force_evall(x);                      \
	}                                           \
} while(0)



#define __cos 				core_math___cos
#define __sin 				core_math___sin
#define __rem_pio2 			core_math___rem_pio2
#define __rem_pio2_large 	core_math___rem_pio2_large
#define cos 				core_math_cos
#define sin 				core_math_sin
#define scalbn 				core_math_scalbn
