#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char **readfile(FILE *file, int maxlen, int *totalLinesRead)
{
    char **buffer = malloc(sizeof(char*));
    if (buffer == NULL)
    {
        fprintf(stderr, "Memory allocation failed!\n");
        free(buffer);
        return NULL;
    }

    char currLine[maxlen];
    int maxLineCapacity = 1;
    while(fgets(currLine, maxlen, file))
    {
        // Flush unread characters from input buffer in case fgets overflows
        if (strchr(currLine, '\n') == NULL)
        {
            int c;
            while ((c = fgetc(file)) != '\n' && c != EOF);
        }

        (*totalLinesRead)++;
        if (*totalLinesRead > maxLineCapacity)
        {
            maxLineCapacity = 2 * maxLineCapacity;
            buffer = realloc(buffer, maxLineCapacity * sizeof(char*));
            if (buffer == NULL)
            {
                fprintf(stderr, "Memory reallocation failed!\n");
                free(buffer);
                return NULL;
            }
        }

        buffer[*totalLinesRead - 1] = malloc(strlen(currLine) + 1);
        strcpy(buffer[*totalLinesRead - 1], currLine);
    }

    return buffer;
}

void printInReverse(char **fileBuf, int lineCount, int isLineNums)
{
    for (int i = lineCount - 1; i >= 0; i--)
    {
        if (isLineNums)
        {
            printf("%d ", lineCount);
            lineCount--;
        }
        for (int j = strlen(fileBuf[i]) - 1; j >= 0; j--)
        {
            if (fileBuf[i][j] == '\n')
            {
                continue;
            }
            putc(fileBuf[i][j], stdout);
        }
        putc('\n', stdout);
    }
}

void freeBuffer(char **buffer, int lineCount)
{
    for (int i = 0; i < lineCount; i++)
    {
        free(buffer[i]);
    }
    free(buffer);
}