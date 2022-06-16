#pragma once

#define STDIN_FILENO (0)
#define STDOUT_FILENO (1)
#define STDERR_FILENO  (2)

ssize_t write(int fd, const void *buf, size_t count);

int brk(void *addr);
void *sbrk(intptr_t increment);
