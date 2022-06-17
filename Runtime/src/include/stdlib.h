#pragma once

typedef unsigned int size_t;

typedef signed int ssize_t;

typedef int ptrdiff_t;

#define NULL ((void *)0)

#define EXIT_SUCCESS ((int)0)
#define EXIT_FAILURE ((int)-1)

void exit(int status);

void abort(void);


