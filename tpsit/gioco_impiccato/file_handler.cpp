#include "include/file_handler.h"
using namespace std;

inline bool compare(pair<string, int>& a, pair<string, int>& b)
{
	return a.second > b.second;
}

string trim(const string& str)
{
	size_t start = str.find_first_not_of(" \t\n\r");
	size_t end = str.find_last_not_of(" \t\n\r");
	if (start == string::npos) return "";

	return str.substr(start, end - start + 1);
}

namespace gioco
{
	string get_random_word(const string& file_path, const int& file_length)
	{
		string s = "";
		ifstream words_file (file_path);
		if (!words_file.is_open())
		{
			cout << "Percorso non valido" << endl;
			return s;
		}

		random_device r;
		mt19937 gen(r()); // Mersenne Twister
		uniform_int_distribution<> distribution(1, file_length);
		int line_number = distribution(gen);

		for (int i = 1; i <= line_number; i++)
			getline(words_file, s);

		words_file.close();
		return s;
	}

	bool print_scoreboard()
	{
		ifstream f (SCOREBOARD_PATH);
		if (!f.is_open())
		{
			cout << "Percorso non valido" << endl;
			return false;
		}
		stringstream s;
		s << f.rdbuf();
		cout << "---CLASSIFICA---\n" << s.str() << "\n----------------" << endl;
		f.close();
		return true;
	}

	bool add_to_scoreboard(const string& nickname, int score)
	{
		ifstream in_f (SCOREBOARD_PATH);
		if (!in_f.is_open())
		{
			cout << "Percorso non valido" << endl;
			return false;
		}
		string line;
		vector<string> splitted;
		while (getline(in_f, line))
		{
			istringstream s_buf(line);
			string s;
			while (getline(s_buf, s, '-'))
				splitted.push_back(trim(s));
		}
		in_f.close();

		vector<pair<string, int>> player_points;
		for (int i = 1; i < splitted.size(); i+=2)
		{
			pair<string, int> player;
			player.first = splitted[i-1];
			player.second = stoi(splitted[i]);
			player_points.push_back(player);
		}

		bool alr = false;
		for (auto &x : player_points)
		{
			if (nickname == x.first)
			{
				x.second = max(score, x.second);
				alr = true;
			}
		}
		if (!alr) player_points.push_back({nickname, score});

		sort(player_points.begin(), player_points.end(), compare);

		ofstream out_f (SCOREBOARD_PATH);
		for (auto &x : player_points)
			out_f << x.first << " - " << x.second << endl;

		out_f.close();
		return true;
	}
}