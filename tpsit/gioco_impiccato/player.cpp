#include "include/player.h"
using namespace std;

namespace gioco
{
	int player::play(string word)
	{
		string unknown(word.size(), '_');
		cout << unknown << " (" << unknown.length() << ") " << endl;

		for (this->life; this->life >= 0; this->life--)
		{
			string input;
			cout << "[?] (" << this->life << " vite) Indovina la lettera: " << endl;
			cin >> input;
			while (input.length() != 1 || !isalpha(input[0]))
			{
				cout << "[!] Stringa non alfabetica o troppo lunga. Riprova: " << endl;
				cin >> input;
			}

			if (word.find(input[0]) != string::npos)
			{
				if (unknown.find(input[0]) != string::npos)
				{
					cout << "[X] Già trovata | " << unknown << endl;
					continue;
				}

				for (int c = 0; c < unknown.length(); c++)
					if (word[c] == input[0])
						unknown[c] = word[c];

				cout << "[V] Giusto | " << unknown << endl;
				this->life++;
			}
			else cout << "[X] Sbagliato | " << unknown << endl;

			if (word == unknown)
			{
				cout << "[V] HAI VINTO! | " << unknown << endl << endl;
				this->life--;
				return (int)word.length();
			}
		}
		return (word != unknown) ? 0 : (int)word.length();
	}
}