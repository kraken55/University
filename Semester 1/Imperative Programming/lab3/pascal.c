#include <stdio.h>
#include <math.h>

long factorial(int n);

int main(void)
{
    int n;
    scanf("%d", &n);

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n - 1; j++)
        {
            printf(" ");
        }

        for (int j = 0; j < i; j++)
        {
            printf("%ld ", factorial(i) / (factorial(j) * factorial(i - j)));
        }

        printf("\n");
    }

    return 0;
}

long factorial(int n)
{
  if (n == 0)
  {
    return 1;  
  }
  else
  {
        return(n * factorial(n-1));  
  }
}