#include <stdio.h>
#include <math.h>

int main(void)
{
    int a, b;
    scanf("%d %d", &a, &b);

    int lenA = (int) floor(log10(a)) + 1;
    int lenB = (int) floor(log10(b)) + 1;
    int aArr[lenA];
    int bArr[lenB];

    for (int i = lenA - 1; i >= 0; i--)
    {
        aArr[i] = a % 10;
        a /= 10;
    }
    for (int i = lenB - 1; i >= 0; i--)
    {
        bArr[i] = b % 10;
        b /= 10;
    }

    int temp = aArr[0];
    aArr[0] = bArr[0];
    bArr[0] = temp;

    temp = aArr[lenA - 1];
    aArr[lenA - 1] = bArr[lenB - 1];
    bArr[lenB - 1] = temp;

    for (int i = 0; i < lenA; i++)
    {
        printf("%d", aArr[i]);
    }
    printf("\n");
    for (int i = 0; i < lenB; i++)
    {
        printf("%d", bArr[i]);
    }
    printf("\n");

    return 0;
}