#pragma once

#include <stdbool.h>

double pow( double base, double exponent );
double round( double arg );
double floor( double arg );
double ceil( double arg );
double log( double arg );

bool isnan(double arg);

#define hidden __attribute__((__visibility__("hidden")))

#include "math_rename.h"

hidden int    __rem_pio2(double,double*);
hidden int    __rem_pio2_large(double*,double*,int,int,int);

hidden double __sin(double,double,int);
hidden double __cos(double,double);
hidden double __tan(double,double,int);
hidden double __expo2(double,double);
