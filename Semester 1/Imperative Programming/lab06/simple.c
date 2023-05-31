#include <stdio.h>
#include <ctype.h>

void fillWithZeros(int *arr, int len)
{
    for (int i = 0; i < len; i++)
    {
        arr[i] = 0;
    }
}

int sumArr(int *arr, int len)
{
    int sum = 0;
    for (int i = 0; i < len; i++)
    {
        sum += arr[i];
    }

    return sum;
}

int maxInArr(int *arr, int len)
{
    int maxIndex = 0;
    for (int i = 0; i < len; i++)
    {
        if (arr[i] > arr[maxIndex])
        {
            maxIndex = i;
        }
    }

    return maxIndex;
}

int secondMaxInArr(int *arr, int len)
{
    int maxVal = arr[maxInArr(arr, len)];
    int secondMaxIndex = 0;
    for (int i = 0; i < len; i++)
    {
        if (arr[i] > arr[secondMaxIndex] && arr[i] < maxVal)
        {
            secondMaxIndex = i;
        }
    }

    return secondMaxIndex;
}

int weightedSum(int *arr, int *wght, int len)
{
    int sum = 0;
    for (int i = 0; i < len; i++)
    {
        sum += arr[i] * wght[i];
    }

    return sum;
}

double avg(int *arr, int len)
{
    int sum = 0;
    int count = 0;
    for (int i = 0; i < len; i++)
    {
        sum += arr[i];
        count++;
    }

    return sum / (double) count;
}

int abcOrder(char *str1, char *str2)
{
    int i = 0;
    while (str1[i] != '\0' && str2[i] != '\0')
    {
        if (tolower(str1[i]) > tolower(str2[i]))
        {
            return 1;
        }
        else if (tolower(str1[i]) < tolower(str2[i]))
        {
            return 0;
        }

        i++;
    }

    if (str1[i] == '\0' && str2[i] == '\0')
    {
        return -1;
    }
    else if (str1[i] == '\0')
    {
        return 0;
    }
    else
    {
        return 1;
    }
}

int countChar(char *str)
{
    int count = 0;

    int i = 0;
    while (str[i] != '\0')
    {
        count++;
        i++;
    }
    count++;

    return count;
}

void swapMinMax(int *arr, int len)
{
    int minIndex = 0;
    int maxIndex = 0;
    for (int i = 0; i < len; i++)
    {
        if (arr[i] > arr[maxIndex])
        {
            maxIndex = i;
        }
        if (arr[i] < arr[minIndex])
        {
            minIndex = i;
        }
    }

    int temp = arr[maxIndex];
    arr[maxIndex] = arr[minIndex];
    arr[minIndex] = temp;
}

int countLines(char *str)
{
    int count = 0;

    int i = 0;
    while (str[i] != '\0')
    {
        if (str[i] == '\n')
        {
            count++;
        }

        i++;
    }

    if (str[i--] == '\n')
    {
        count--;
    }

    return count;
}

int main(void)
{
    int testArr[] = {1,2,3,4,5,6,7,7,8,9,10};
    swapMinMax(testArr, sizeof testArr / sizeof (int));
    for (int i = 0; i < (int) (sizeof testArr / sizeof (int)); i++)
    {
        printf("%d ", testArr[i]);
    }
    printf("\n");
}


