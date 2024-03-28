#include <stdio.h>

int secondi(int ore, int min, int sec) { return ( 60 * 60 * ore ) + (60 * min) + sec; }

int main()
{
	int ore, min, sec, s1, s2;

	printf("Inserisci ore:minuti:secondi\n");
	scanf("%d:%d:%d", &ore, &min, &sec);
	s1 = secondi(ore, min, sec);
	
	printf("Inserisci ore:minuti:secondi\n");
	scanf("%d:%d:%d", &ore, &min, &sec);
	s2 = secondi(ore, min, sec);


	char m = ( s1 > s2 ) ? '>' : '<';
	printf("primo %c secondo\n", m);
	return 0;
}