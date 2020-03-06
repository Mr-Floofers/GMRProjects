//Kogan, Dennis
//Febuary 27th, 2019, Lab #2
//25982, Tues and Thurs 11:10-1:05

#include <iostream>
#include <iomanip>
#include <string>
using namespace std;

int main()
{
	string Name;
	const float tax = .09f;
	const int laborCharge = 35;
	float numOfHours, parts;

	cout << "Please enter a name" << endl;
	cin >> Name;
	cout << "Please enter the number of hours worked" << endl;
	cin >> numOfHours;
	cout << "Please enter cost of parts" << endl;
	cin >> parts;

	float Tax = parts * tax;

	cout << "Customer name: " << right << setw(22) << Name << endl;
	cout << "Hours of labor: " << right << setw(21) << fixed << showpoint << setprecision(2) << numOfHours << endl;
	cout << "Cost for labor: " << right << setw(21) << fixed << showpoint << setprecision(2) << numOfHours * laborCharge << endl;
	cout << "Parts and Supplies: " << right << setw(17) << fixed << showpoint << setprecision(2) << parts << endl;
	cout << "Tax: " << right << setw(32) << fixed << showpoint << setprecision(2) << Tax << endl;
	cout << "Total Amount Due: " << right << setw(19) << fixed << showpoint << setprecision(2) << parts + (numOfHours * laborCharge) + Tax << endl;
}

/* Program Output
Please enter a name
John
Please enter the number of hours worked
4.5
Please enter cost of parts
97
Customer name:                   John
Hours of labor:                  4.50
Cost for labor:                157.50
Parts and Supplies:             97.00
Tax:                             8.73
Total Amount Due:              263.23

Please enter a name
Smith
Please enter the number of hours worked
2.25
Please enter cost of parts
200
Customer name:                  Smith
Hours of labor:                  2.25
Cost for labor:                 78.75
Parts and Supplies:            200.00
Tax:                            18.00
Total Amount Due:              296.75
*/