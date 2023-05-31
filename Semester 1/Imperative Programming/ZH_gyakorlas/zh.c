#include <stdio.h>
#include <stdbool.h>

const int HEIGHT = 6;
const int WIDTH = 7;
int BOARD[HEIGHT + 2][WIDTH + 2]; // Borders filled with zeros on the sides for easier evaluation

int main(void)
{
    return 0;
}

int init(void)
{
    for (int i = 0; i < HEIGHT + 2; i++)
    {
        for (int j = 0; j < WIDTH + 2; j++)
        {
            BOARD[i][j] = 0;
        }
    }
}

void printTable(void)
{
    for (int i = 1; i < HEIGHT; i++)
    {
        for (int j = 1; j < WIDTH; j++)
        {
            printf("%d ", BOARD[i][j]);
        }
        printf("\n");
    }
}

bool submit(int player, int column)
{
    for (int i = 1; i < HEIGHT; i++)
    {
        if ((column + 1) < 0 || (column + 1) > WIDTH - 1)
        {
            printf("Illegal move: no such column\n");
            return false;
        }

        if (BOARD[i][column + 1] != 0)
        {
            if (i == 0)
            {
                printf("Illegal move: no free slots in specified column\n");
                return false
            }
            else
            {
                BOARD[i - 1][column + 1] = player;
                return true;
            }
        }

        if (i == HEIGHT - 1)
        {
            BOARD[i][column + 1] = player;
            return true;
        }
    }
}

int evaluate(void)
{
    for ()
}