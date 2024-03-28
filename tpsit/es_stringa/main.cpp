#include <iostream>
#include <cstring>

class stringa
{
private:
	char *str;
	size_t len;

public:
	explicit stringa(const char *string)
	{
		len = strlen(string);
		str = new char[len];
		strncpy(str, string, len);
	}

	~stringa()
	{
		delete[] str;
	}

	void set(const char *string)
	{
		delete[] str;
		len = strlen(string);
		str = new char[len];
		strncpy(str, string, len);
	}

	void stampa()
	{
		std::cout << str << std::endl;
	}

	void reverse()
	{
		for (int i = 0; i < len / 2; i++)
		{
			char tmp = str[i];
			str[i] = str[len - i - 1];
			str[len - i - 1] = tmp;
		}
	}

	int cerca(char c)
	{
		for (int i = 0; i < len; i++)
			if (str[i] == c)
				return i;

		return -1;
	}

	int conta(char c)
	{
		int res = 0;
		for (int i = 0; i < len; i++)
			if (str[i] == c)
				res++;

		return res;
	}

	void to_upper()
	{
		for (int i = 0; i < len; i++)
			str[i] = (char)toupper(str[i]);
	}

	void to_lower()
	{
		for (int i = 0; i < len; i++)
			str[i] = (char)tolower(str[i]);
	}

	void flip_case()
	{
		for (int i = 0; i < len; i++)
			str[i] = (char)(isupper(str[i]) ? tolower(str[i]) : toupper(str[i]));
	}

	bool is_palindrome()
	{
		for (int i = 0; i < len / 2; i++)
			if (str[i] != str[len - i - 1])
				return false;

		return true;
	}

	size_t operator~()
	{
		return strlen(str);
	}

	stringa operator+(stringa *s2) const
	{
		char *result = str;
		strncat(result, s2->str, len + s2->len);

		return stringa(result);
	}

	bool operator==(stringa *s2)
	{
		if (strcmp(str, s2->str) == 0)
			return true;

		return false;
	}
};

int main()
{
	auto s1 = stringa("oaic");
	auto s2 = stringa("ciao");
	s1.reverse();
	auto s3 = s1 + &s2;
	s3.stampa();

	return 0;
}