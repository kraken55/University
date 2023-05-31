#include <stdio.h>
#include <ctype.h>
#include <string.h>

int *letterCount(char *str)
{
    static int ret[] = {0, 0};
    const char *VOWELS = "aeiou";

    int i = 0;
    while (str[i] != '\0')
    {
        char c = tolower(str[i]);

        if (isalpha(c))
        {
            int guard = 1;
            for (int j = 0; j < 5; j++)
            {
                if (c == VOWELS[j])
                {
                    ret[0]++;
                    guard = 0;
                    break;
                }
            }

            if (guard == 1)
            {
                ret[1]++;
            }
        }

        i++;
    }

    return ret;
}

int isAmicable(int *arr, int len)
{
    
}

int main(void)
{
    char *string = "Apple trees are nice!";
    int cnt[2];
    memcpy(cnt, letterCount(string), sizeof (cnt));
    for (int i = 0; i < 2; i++)
    {
        printf("%d ", cnt[i]);
    }
    printf("\n");
    return 0;
}
