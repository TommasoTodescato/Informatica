#include <stdio.h>

int main()
{
	int prev = 0, n = 0;
	do
	{
		prev = n;
		printf("Inserisci un numero: ");
		scanf("%d", &n);
	}
	while (prev != n);

	return 0;
}