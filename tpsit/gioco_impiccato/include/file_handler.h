#ifndef GIOCO_IMPICCATO_FILE_HANDLER_H
#define GIOCO_IMPICCATO_FILE_HANDLER_H

#include <iostream>
#include <fstream>
#include <random>
#include <sstream>
#include <algorithm>

#define SCOREBOARD_PATH "scoreboard.txt"

namespace gioco
{
	std::string get_random_word(const std::string& file_path, const int& file_length);
	bool print_scoreboard(); // true : success, false : failure
	bool add_to_scoreboard(const std::string& nickname, int score); // true : success, false: failure
}

#endif
