#pragma once

#include <assert.h>

typedef signed int intptr_t;

typedef int int32_t;
static_assert(sizeof(int32_t) == 4, "size mismatch");

typedef unsigned int uint32_t;
static_assert(sizeof(uint32_t) == 4, "size mismatch");

typedef unsigned long long int uint64_t;
static_assert(sizeof(uint64_t) == 8, "size mismatch");

typedef double double_t;
static_assert(sizeof(double_t) == 8, "size mismatch");


