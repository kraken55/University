#include <stdio.h>
#include <time.h>
#include <stdlib.h>

#define MIN -5
#define MAX 5

void swap(int *pa, int *pb);
void swap(int *pa, int *pb)
{
    int temp;
    temp = *pa;
    *pa = *pb;
    *pb = temp;
}

void change(int num);
void change(int num) 
{
    printf("%d \n", num+2);
    printf("%d \n", num);
    int r = rand() % 20; //local var
    num=num * r;
    printf("%d \n", num);
    printf("%d \n", num * rand() % 20);
}

void fillZero(double *t);
void fillZero(double *t)
{
    for (double *p = t; p != t + 100; ++p)
    {
        *p = 0.0;
    }
}

void print(double *t);
void print(double *t)
{
    for (int i = 0; i != 100; ++i)
    {
        printf("%g ", t[i]);
    }
    printf("\n ");
}

void fillRandomNumbers(double *t);
void fillRandomNumbers(double *t)
{
    for (int i = 0; i != 100; ++i)
    {
        t[i] = rand() % 20+1;
    }
}

void fillRandomNumbersOverload(double *t, int min, int max);
void fillRandomNumbersOverload(double *t, int min, int max)
{
    for (int i = 0; i != 100; ++i)
    {
        t[i] = rand() % (2 * max + 1) + min;
    }
}

int greatest(double *t, int len);
int greatest(double *t, int len)
{
    int max = 0;
    for (int i = 1; i < len; i++)
    {
        if (t[i] > t[max])
        {
            max = i;
        }
    }

    return max;
}

int main(int argc, char **argv)
{
    srand(time(NULL)); // Initialization
    double x = 2.3;
    double y = 1.9;
    double *p;
    p = &x;
    printf("p = %p \n", p);
    printf("*p = %g \n", *p);
    int a[3];
    *a = 3;
    a[1] = 4;
    *(a + 2) = 5;

    printf("%d %d %d\n", a[0], a[1], a[2]);

    swap(&a[0], &a[1]);

    printf("%d %d %d\n", a[0], a[1], a[2]);

    change(20);
    double a1[100];
    fillZero(a1);
    print(a1);
    fillRandomNumbersOverload(a1, MIN, MAX);
    print(a1);

    printf("-------------------------------\n");
    printf("%d\n", greatest(a1, 100));

    return 0;
}