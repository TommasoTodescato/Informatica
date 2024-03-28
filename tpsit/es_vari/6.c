#include <time.h>
#include <stdlib.h>
#include <stdio.h>

int main()
{
	srand(time(NULL));
	int arr[10];
	for (int i = 0; i < 10; i++)
	{
		int r = (rand()%89) + 1;
		for (int j = 0; j < 10; j++)
		{
			while (r == arr[j])
				r = (rand()%89) + 1;
		}
		arr[i] = r;

		printf("%d\n", arr[i]);
	}
}