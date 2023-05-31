#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main(void)
{
    /*
    char **buffer = malloc(8);
    int currSize = 0;
    int maxSize = 8;
    FILE *file = fopen("test.txt", "r");
    char line[256];
    fgets(line, 256, file);
    printf("asdasd\n");
    while ( (int) (strlen(line) * sizeof(char) + 1 + currSize) > maxSize)
    {
        printf("Reallocating\n");
        maxSize = 2 * maxSize;
        buffer = realloc(buffer, maxSize);
    }
    //buffer[0] = malloc(256);
    strcpy(buffer[0], line);
    printf("buffer[0]: %s", buffer[0]);

    fgets(line, 256, file);
    buffer[1] = malloc(256);
    strcpy(buffer[1], line);
    printf("buffer[1]: %s", buffer[1]);
    */

   int num = 2;
   int *numptr = &num;
   (*numptr)++;
   if (*numptr > 2)
   {
    printf("adasd\n");
   }
   else
   {
    printf("nothing\n");
   }

   printf("%d\n", *numptr - 1);

    return 0;
}