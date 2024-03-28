#include "include/file_handler.h"
#include "include/player.h"
using namespace std;

#define INPUT_PATH "parole.txt"
#define INPUT_LEN 60453
#define LIFES 10

string input_nickname()
{
	string player_name;
	cout << "Inserisci il tuo nickname: ";
	cin >> player_name;
	while (player_name.length() > 16)
	{
		cout << "Il nome deve essere sotto i 16 caratteri, riprova: ";
		cin >> player_name;
	}
	return player_name;
}

int main()
{
	int mod = 1;
	while (mod)
	{
		cout << "\n<0> Gioca\n"
				"<1> Classifica\n"
				"<n> Esci" << endl;
		cin >> mod;
		if (cin.fail() || (mod != 0 && mod != 1)) return 0;
		if (mod)
		{
			gioco::print_scoreboard();
			continue;
		}

		string nickname = input_nickname();
		auto p = gioco::player(nickname, LIFES);

		int tot_score = 0;
		while (p.life > 0)
		{
			string word = gioco::get_random_word(INPUT_PATH, INPUT_LEN);
			if (word.empty()) return 1;

			// cout << word << endl; // decommentando questo si ha la soluzione ( solo per testing )
			tot_score += p.play(word);
		}
		cout << "[X] HAI PERSO! | punteggio = " << tot_score << endl;
		gioco::add_to_scoreboard(nickname, tot_score);
		mod = 1;
	}
	return 0;
}