#include <stdio.h>
#include <math.h>

int main(void)
{
    int a;
    scanf("%d", &a);

    double s = 3 * a / 2.0;
    printf("%.2f\n", sqrt(s * (s - a) * (s - a) * (s - a)));

    return 0;
}