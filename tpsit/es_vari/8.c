#include <stdio.h>

int main()
{
	int l, s = 0;
	printf("Inserisci la lunghezza: ");
	scanf("%d", &l);

	printf("Inserisci gli elementi dell'array: \n");
	int arr[l];
	for (int i = 0; i < l; i++)
	{
		scanf("%d", arr+i);
		s = s + *(arr + i);
	}

	printf("somma = %d\n", s);
	return 0;
}