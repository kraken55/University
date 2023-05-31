#include <stdio.h>

int main(void)
{
    signed char num = (-3) & 5 << 2 | 3 % 2 + 1;

    printf("%d\n", num);

    return 0;
}