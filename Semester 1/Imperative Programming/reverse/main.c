#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#ifndef MAIN_H
#define MAIN_H
    #include "main.h"
#endif

int main(int argc, char *argv[])
{
    if (argc < 3)
    {
        printf("Usage\n\trev [SHOW LINE NUMBERS] [MAX LINE LENGTH] files...\n");
        return 1;
    }

    struct Parameters
    {
        int printLineNumbers;
        int maxLineLength;
    } params;

    if (strcmp("linenums", argv[1]) == 0)
    {
        params.printLineNumbers = 1;
    }
    else if (strcmp("nolinenums", argv[1]) == 0)
    {
        params.printLineNumbers = 0;
    }
    else
    {
        printf("Error: unrecognised parameter <%s>\n", argv[1]);
        return 2;
    }

    params.maxLineLength = atoi(argv[2]);

    // Reads from stdin if no files are specified in argv
    if (argc == 3)
    {
        int lineCount = 0;
        char **consoleInput = readfile(stdin, params.maxLineLength, &lineCount);
        if (consoleInput == NULL)
        {
            freeBuffer(consoleInput, lineCount);
            return 3;
        }
        printInReverse(consoleInput, lineCount, params.printLineNumbers);
        freeBuffer(consoleInput, lineCount);
    }
    else
    {
        for (int i = 3; i < argc; i++)
        {
            FILE *file = fopen(argv[i], "r");
            if (file == NULL)
            {
                fprintf(stderr, "File opening unsuccessful: <%s>\n", argv[i]);
                continue;
            }

            int lineCount = 0;
            char **currFile = readfile(file, params.maxLineLength, &lineCount);
            if (currFile == NULL)
            {
                free(currFile);
                fclose(file);
                return 3;
            }
            printInReverse(currFile, lineCount, params.printLineNumbers);
            freeBuffer(currFile, lineCount);
            fclose(file);
        }
    }
    return 0;
}