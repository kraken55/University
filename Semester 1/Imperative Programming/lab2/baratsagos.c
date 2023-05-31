#include <stdio.h>
#include <stdbool.h>
#include <math.h>

bool baratsagos(int a, int b);


int main(void)
{
    printf("%d\n", baratsagos(9363584, 9437056));
    return 0;
}

bool baratsagos(int a, int b)
{
    int sumA = 0;
    for (int i = 1; i <= sqrt(a); i++)
    {
        if (a % i == 0)
        {
            if (a / i == i)
            {
                sumA += i;
            }
            else
            {
                sumA += i;
                sumA += a / i;
            }
        }
    }
    sumA -= a;

    int sumB = 0;
    for (int i = 1; i <= sqrt(b); i++)
    {
        if (b % i == 0)
        {
            if (b / i == i)
            {
                sumB += i;
            }
            else
            {
                sumB += i;
                sumB += b / i;
            }
        }
    }
    sumB -= b;

    if (sumA == b && sumB == a)
    {
        return true;
    }
    else
    {
        return false;
    }
}