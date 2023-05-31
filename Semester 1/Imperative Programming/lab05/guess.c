#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main(int argc, char **argv)
{
    srand(time(NULL));
    const int TARGET = rand() % 100 + 1;

    if (argc != 2)
    {
        return EXIT_FAILURE;
    }
    
    int guess = atoi(argv[1]);
    while (guess != TARGET)
    {
        if (guess < TARGET)
        {
            printf("Kicsi!\n");
            scanf("%d", &guess);
        }
        else if (guess > TARGET)
        {
            printf("Nagy!\n");
            scanf("%d", &guess);
        }
    }

    return EXIT_SUCCESS;
}