#include <stdio.h>
#include <stdbool.h>
#include <string.h>

#define MAX 9
#define MAX_NAME_LEN 64

bool vote(char* name);
void print_winner(void);

typedef struct
{
    char* name;
    int votes;
}
candidate;

candidate candidates[MAX];

int candidate_count;

int main(int argc, char* argv[])
{
    if (argc < 2)
    {
        printf("Usage: plurality [candidate...]\n");
        return 1;
    }

    candidate_count = argc - 1;
    if (candidate_count > MAX)
    {
        printf("Maximum number of candidates is: %d\n", MAX);
        return 2;
    }
    for (int i = 0; i < candidate_count; i++)
    {
        candidates[i].name = argv[i + 1];
        candidates[i].votes = 0;
    }

    int voter_count;
    printf("Enter the number of voters: ");
    scanf("%d", &voter_count);
    
    for (int i = 0; i < voter_count; i++)
    {
        char name[MAX_NAME_LEN];
        printf("Name: ");
        scanf("%s", name);

        if (!vote(name))
        {
            printf("%s\n", name);
            printf("Invalid vote: %s\n", name);
        }

    }

    print_winner();

    return 0;
}

bool vote(char* name)
{
    for (int i = 0; i < candidate_count; i++)
    {
        if (strcmp(candidates[i].name, name) == 0)
        {
            candidates[i].votes++;
            return true;
        }
    }

    return false;
}

void print_winner(void)
{
    int max_votes = 0;
    for (int i = 0; i < candidate_count; i++)
    {
        if (candidates[i].votes > max_votes)
        {
            max_votes = candidates[i].votes;
        }
    }

    for (int i = 0; i < candidate_count; i++)
    {
        if (candidates[i].votes == max_votes)
        {
            printf("%s\n", candidates[i].name);
        }
    }
}