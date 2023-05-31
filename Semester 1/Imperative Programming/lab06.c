#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

int GAME_VER;

bool checkIfSeen(int *arr, int startPos, int target)
{
    for (int i = startPos; i >= 0; i--)
    {
        if (arr[i] == target)
        {
            printf("Nem jó!\n");
            return true;
        }
    }

    return false;
}

int main(int argc, char **argv)
{
    if (argc != 2)
    {
        return -1;
    }

    GAME_VER = atoi(argv[1]);
    if (GAME_VER < 1 || GAME_VER > 10)
    {
        return -2;
    }

    int nums[GAME_VER];
    for (int i = 0; i < GAME_VER; i++)
    {
        do
        {
            int input;
            scanf("%d", &input);
            nums[i] = input;
        } 
        while (checkIfSeen(nums, i - 1, nums[i]));
    }

    return 0;
}
