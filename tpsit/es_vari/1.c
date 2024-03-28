#include <stdio.h>

int main()
{
	int l1, l2, l3;
	printf("Inserisci i 3 numeri in formato n1 n2 n3\n");
	scanf("%d %d %d", &l1, &l2, &l3);
	if ( (l1*l1 + l2*l2) == l3*l3 )
		printf("rettangolo\n");
	else
		printf("non rettangolo\n");

	return 0;
}