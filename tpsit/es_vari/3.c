#include <stdio.h>

int somma(int arr[5])
{
	int s = 0;
	for (int i = 0; i < 5; i++)
		s = s + arr[i];
	return s;
}

int media(int arr[5]) { return somma(arr) / 5; }

int main()
{
	int arr[5];
	printf("Inserisci 5 numeri: \n");
	for(int i = 0; i < 5; i++)
		scanf("%d", &arr[i]);
	
	printf("%d\n", somma(arr));
	printf("%d\n", media(arr));

	return 0;
}