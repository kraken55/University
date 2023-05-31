#include <stdio.h>
#include <stdbool.h>

int main(void)
{
    int num = 341;
    int bytes[32] = {0};

    for (int i = 0; num != 0; i++)
    {
        bytes[i] = num % 2;
        num /= 2;
    }

    int start = 0;
    for (int i = 31; i >= 0; i--)
    {
        if (bytes[i] == 1)
        {
            start = 1;
        }
        if (start == 1)
        {
            printf("%d", bytes[i]);
        }
    }
    printf("\n");

    return 0;
}