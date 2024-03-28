#include <stdio.h>
#include <stdlib.h>

int main()
{
	char *s;
	scanf("%s", s);

	int i = 0;
	while ( (*(s+i)) != NULL ) i++;

	printf("%d\n", i);
	return 0;
}