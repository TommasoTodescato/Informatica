#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <stdbool.h>
#include <unistd.h>
#include <sys/wait.h>

#define DIM 	100
#define RANGE 	100
#define NC 		25
/*
 * SCOPO : Implementare un bubble sort classico e misurarne la complessità algoritmica.
 *
 * 1) void CaricaVettore(int d, int *v) => carica il vettore v di dimensione d con valori random.
 *
 * 2) void StampaVettore(int d, int *v, char *commento) => stampa tutti i d valori del vettore v.
 *
 * 3) int BubbleSort(int d, int *v) => ordina il vettore tramite bubble sort. Ritorna il numero di swap fatti.
 */

void CaricaVettore(int d, int *v);
void StampaVettore(int d, int *v, char *commento);
void swap(int *x, int *y);
int BubbleSort(int d, int *v);

int main()
{
	int arr[DIM];
	int v1[DIM/2];
	int v2[DIM/2];

	CaricaVettore(DIM, arr);

	for (int i = 0; i < DIM/2; i++) v1[i] = arr[i];
	for (int i = DIM/2 + 1; i < DIM; i++) v2[i-(DIM/2+1)] = arr[i];

	int id = fork();
	if (id == 0)
	{
		int scambi_figlio = BubbleSort(DIM/2, v2);
		printf("vettore figlio ordinato in %d scambi\n\n", scambi_figlio);
	}
	else
	{
		int scambi_padre = BubbleSort(DIM / 2, v1);
		printf("vettore padre ordinato in %d scambi\n", scambi_padre);
		wait(NULL);

		int passi = BubbleSort(DIM, arr);

		StampaVettore(DIM, arr, "ordinato");

		printf("\n\nvettore ordinato in %d scambi", passi);
	}
	return 0;
}


void CaricaVettore(int d, int *v)
{
	srand(time(NULL));
	for (int i = 0; i < d; i++)
	{
		v[i] = rand() % RANGE;
 	}
}

void StampaVettore(int d, int *v, char *commento)
{
	printf("%s", commento);
	for (int i = 0; i < d; i++)
	{
		if (i % NC == 0)
		{
			printf("\n");
		}
		printf("%d ", v[i]);
	}
}

void swap(int *x, int *y)
{
	int tmp = *x;
	*x = *y;
	*y = tmp;
}

int BubbleSort(int d, int *v)
{
	int c = 0;
	bool finito = false;
	for (int i = 0; i < d - 1; i++)
	{
		finito = false;
		for (int j = 0; j < d - i - 1; j++)
		{
			if (v[j] > v[j + 1])
			{
				swap(v+j, v+j+1);
				finito = true;
				c++;
			}
		}
		if (!finito) break;
	}
	return c;
}
