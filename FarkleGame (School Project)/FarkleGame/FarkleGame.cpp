//Alexander Sufran
//Alex's Farkle Game - Final Project
//IT-312
//12/10/2022


#include <iostream>
#include <fstream>
#include <string>

#include "GamePlay.h"

using namespace std;

void ReadGameRules();

int main()
{
	ReadGameRules();
	GamePlay game;

	game.RunGame();

	return 0;

}

void ReadGameRules()
{
	//open rules .txt file and pass it to infile

	ifstream infile("FarkleRules.txt");

	//this checks if the file fails to open
	if (infile.fail())
	{
		//cerr is an output command for erros
		cerr << "Error opening file" << endl;
		exit(1); //exit the file
	}

	string line;

	//loop the file until the loop reaches the end of file (eof)
	while (!infile.eof())
	{
		getline(infile, line);
		cout << line << endl;
	}

	//close the file
	infile.close();
}