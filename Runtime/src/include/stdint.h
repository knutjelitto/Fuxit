#pragma once

#include <assert.h>

typedef signed int intptr_t;

typedef signed char int8_t;
static_assert(sizeof(int8_t) == 1, "size mismatch");

typedef unsigned char uint8_t;
static_assert(sizeof(uint8_t) == 1, "size mismatch");

typedef signed short int16_t;
static_assert(sizeof(int16_t) == 2, "size mismatch");

typedef unsigned short uint16_t;
static_assert(sizeof(uint16_t) == 2, "size mismatch");

typedef signed int int32_t;
static_assert(sizeof(int32_t) == 4, "size mismatch");

typedef unsigned int uint32_t;
static_assert(sizeof(uint32_t) == 4, "size mismatch");

typedef signed long long int int64_t;
static_assert(sizeof(int64_t) == 8, "size mismatch");

typedef unsigned long long int uint64_t;
static_assert(sizeof(uint64_t) == 8, "size mismatch");

typedef double double_t;
static_assert(sizeof(double_t) == 8, "size mismatch");


