#ifndef GIOCO_IMPICCATO_PLAYER_H
#define GIOCO_IMPICCATO_PLAYER_H

#include <iostream>

namespace gioco
{
	class player
	{
	public:
		std::string name;
		int life;

		explicit player(const std::string& name, const int& life)
		{
			this->name = name;
			this->life = life;
		}

		int play(std::string word); //returns the score, or 0 if lost
	};
}

#endif