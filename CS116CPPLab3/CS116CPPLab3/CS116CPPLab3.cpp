#include <iostream>
using namespace std;

int main()
{
	char package;
	float numOfHours;
	float perMonth, hoursAllowed, extraHours, billTotal;
	float extraHoursUsed = 0;

	cout << "What package did you buy, enter A, B, C" << endl;
	cin >> package;
	package = toupper(package); // make everything uppercase to make sure that all the inputs are the same
	while (package != 'A' && package != 'B' && package != 'C')
	{
		cout << "Please enter a valid package" << endl;
		cin >> package;
	}

	cout << "How many hours did you use" << endl;
	cin >> numOfHours;

	if (numOfHours > 200 || numOfHours < 0)
	{
		cout << "Number of hours used cannot exceed 200 and cannot be less than 0" << endl;
		return(0);
	}

	else if (package == 'A')
	{
		perMonth = 9.95;
		hoursAllowed = 10;
		extraHours = 2;
		billTotal = 9.95;
		if (numOfHours > hoursAllowed)
		{
			extraHoursUsed = numOfHours - hoursAllowed;
		}
		billTotal += extraHoursUsed * extraHours;
		if (numOfHours == 30)
		{
			cout << "If you use 30 hours, you would save $25 by switching to Package B, and save $30  by swtiching to Package C" << endl;
		}
	}

	else if (package == 'B')
	{
		perMonth = 14.95;
		hoursAllowed = 20;
		extraHours = 1;
		billTotal = 14.95;
		if (numOfHours > hoursAllowed)
		{
			extraHoursUsed = numOfHours - hoursAllowed;
		}
		billTotal += extraHoursUsed * extraHours;

	}
	else
	{
		perMonth = 19.95;
		billTotal = 19.95;

	}

	cout << "Your total is $" << billTotal << endl;
	cout << "You chose Package " << package << endl;
	cout << "You used " << numOfHours << " hours, the base charge was " << perMonth << endl;
}

/*
What package did you buy, enter A, B, C
a
How many hours did you use       
12
Your total is $13.95
You chose Package A
You used 12 hours, the base charge was 9.95

What package did you buy, enter A, B, C
a
How many hours did you use
30
If you use 30 hours, you would save $25 by switching to Package B, and save $30  by swtiching to Package C
Your total is $49.95
You chose Package A
You used 30 hours, the base charge was 9.95*/