/*This is a little program the converts from pounds to kilograms
Kogan, Dennis
Class# 25982
Lab 1
*/

#include <iostream>
#include <string>
using namespace std;


int main()
{
	string name;
	float pounds, kg;

	cout << "What is your first name: ";
	cin >> name;
	cout << "How many pounds do you weigh? ";
	cin >> pounds;
	kg = pounds / 2.205;
	cout << name << ", you weigh " << kg << " kilograms." << endl;

	return 0;
}

/*
What is your first name: Dennis
How many pounds do you weigh? 115
Dennis, you weigh 52.1542 kilograms.
*/


