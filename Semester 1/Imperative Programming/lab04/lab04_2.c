#include <stdio.h>

int main(void)
{
    int a, b;
    scanf("%d %d", &a, &b);

    int area = a * b;
    int circum = 2 * a + 2 * b;

    printf("Area: %d\n", area);
    printf("Circumference: %d\n", circum);

    return 0;
}