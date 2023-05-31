#include <stdio.h>
#include <stdbool.h>
#include <math.h>

bool isPrime(int n);

int main(void)
{
    int curr = 2;
    int num;
    scanf("%d", &num);

    while (num != 1)
    {
        while (num % curr == 0)
        {
            printf("%d ", curr);
            num /= curr;
        }
        
        curr++;
        while (!isPrime(curr))
        {
            curr++;
        }
    }

    return 0;
}

bool isPrime(int n)
{
    for (int i = 2; i < (int) sqrt(n); i++)
    {
        if (n % i == 0)
        {
            return false;
        }
    }

    return true;
}
