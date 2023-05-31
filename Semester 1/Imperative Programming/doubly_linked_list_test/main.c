#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct NodeStr
{
    struct NodeStr *prev;
    struct NodeStr *next;
    char *str;
} node_t;

node_t *create_new_list(char *str)
{
    node_t *start = malloc(sizeof(node_t));
    if (!start)
    {
        fprintf(stderr, "malloc: error allocating memory\n");
        exit(EXIT_FAILURE);
    }
    start->prev = NULL;
    start->next = NULL;

    start->str = malloc(sizeof(char) * (strlen(str) + 1));
    if (!start->str)
    {
        fprintf(stderr, "malloc: error allocating memory\n");
        exit(EXIT_FAILURE);
    }
    strcpy(start->str, str);

    return start;
}

// dest = 1 -> append to front
// dest = 0 -> append to back
void append(node_t *source, int dest, char *str)
{
    node_t *curr = source;
    if (dest == 0)
    {
        while (curr->next != NULL)
        {
            curr = curr->next;
        }
    }
    else if (dest == 1)
    {
        while (curr->prev != NULL)
        {
            curr = curr->prev;
        }
    }
    else
    {
        fprintf(stderr, "append: error appending string\n");
        fprintf(stderr, "usage: dest = 0 -> append to back, dest = 1 -> append to front\n");
        exit(EXIT_FAILURE);
    }

    curr->str = malloc(sizeof(char) * (strlen(str) + 1));
    if (!curr->str)
    {
        fprintf(stderr, "malloc: error allocating memory\n");
        exit(EXIT_FAILURE);
    }

    return;
}

int main(void)
{
    node_t *linked_list = create_new_list("Test String");

    printf("Success!!!!\n");

    free(linked_list->str);
    free(linked_list);

    return EXIT_SUCCESS;
}