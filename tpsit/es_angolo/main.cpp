#include <iostream>
#define pi 3.141592653589

class Angolo
{
private:
	int gradi;
	int primi;
	int secondi;

public:
	explicit Angolo(int gradi, int primi, int secondi)
	{
		set(gradi, primi, secondi);
	}

	void set(int g, int p, int s)
	{
		gradi = g;
		primi = p;
		secondi = s;
	}

	int getGradi()
	{
		return gradi;
	}

	int getPrimi()
	{
		return primi;
	}

	int getSecondi()
	{
		return secondi;
	}

	double radianti()
	{
		double fact = pi/180;
		double res = (double)gradi + (double)primi/60 + (double)secondi/3600;
		return res * fact;
	}

	void stampa()
	{
		std::cout << gradi << "° " << primi << "' " << secondi << "'' " << std::endl;
	}
};

int main()
{
	auto a = Angolo(10, 5, 5);
	a.stampa();
	std::cout << a.radianti() << std::endl;

	return 0;
}