#include <stdio.h>

// DA FINIRE

int main()
{
	int arr1[5] = {4, 6, 93, 234, 1445};
	int arr2[5] = {1, 3, 89, 232, 12345};
	int res[10];

	for (int i = 0; i < 10; i++)
	{
		if (arr1[i] < arr2[i])
		{
			res[i] = arr1[i];
		}
	}

	return 0;
}