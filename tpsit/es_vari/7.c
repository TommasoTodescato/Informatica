#include <stdio.h>

int main()
{
	int arr[10] = {4, 6, 124, 13512, 3, 7, 8, 98, 906, 1111}, n;
	printf("Inserisci il numero da cercare: ");
	scanf("%d", &n);
	for (int i = 0; i < sizeof(arr)/sizeof(int); i++)
		if (n == *(arr+i)) printf("trovato a indice %d\n", i);

	return 0;
}