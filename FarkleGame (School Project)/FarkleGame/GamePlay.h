// Alexander Sufran
// Alex's Farkle Game - Final Project
// IT-312 
// 12/10/2022


#ifndef GAMEPLAY_H
#define GAMEPLAY_H

#include <iostream>
#include <string>

using namespace std;

class GamePlay
{
private:
	int dice[6];
	std::string players[5];
	bool rollAgainPos[6] = { false };
	int score, totalDice, rerollDice, firstScore, totalScore;

public:

	GamePlay();
	~GamePlay();

	int getDice(int index);

	std::string getPlayers(int index);

	bool getRollAgainPos(int index);

	void setScore(int newScore);
	int getScore();

	void setTotalDice(int newTotalDice);
	int getTotalDice();

	void setFirstScore(int newFirstScore);
	int getFirstScore();

	void setTotalScore(int newTotalScore);
	int getTotalScore();

	int* rollDice();
	int* rollAgain();
	void displayRoll();
	std::string* collectNames(int numPlayers);
	int calculateScore(int* playerScore);
	int eachPlayerTurn(int numPlayers, int* playerScore);
	int initialTurn(int* playerScore);
	int RunGame();
};

#endif


