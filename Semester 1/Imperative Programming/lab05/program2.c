#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>

#define N_ARGC 4

void usage()
{
    printf("A help szöveg jönne ide, de lusta vagyok megírni :)\n");
}

int main(int argc, char **argv)
{
    if (strcmp("-h", argv[1]) == 0)
    {
        usage();
        return EXIT_SUCCESS;
    }

    if (argc == N_ARGC)
    {
        if (strcmp("+", argv[2]) == 0)
        {
            printf("%d\n", atoi(argv[1]) + atoi(argv[3]));
        }
        else if (strcmp("-", argv[2]) == 0)
        {
            printf("%d\n", atoi(argv[1]) - atoi(argv[3]));
        }
        else if (strcmp("*", argv[1]) == 0)
        {
            printf("%d\n", atoi(argv[1]) * atoi(argv[3]));
        }
        else if (strcmp("/", argv[2]) == 0)
        {
            printf("%.4f\n", atof(argv[1]) / atof(argv[3]));
        }
        else
        {
            printf("Nincs ilyen operátor!\n");
            return EXIT_FAILURE;
        }
        return EXIT_SUCCESS;
    }
    else if (argc < N_ARGC)
    {
        printf("Kevés!!!!!!!!!\n");
        return EXIT_FAILURE;
    }
    else
    {
        printf("Sooooook!!!!!!!\n");
        return EXIT_FAILURE;
    }

    return 0;
}