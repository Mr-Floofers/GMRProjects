#include <iostream>
#include <vector>
using namespace std;

void Swap(int& A, int& B)
{
	int temp = A;
	A = B;
	B = temp;
}

void BubbleSort(int* Array, int Length)
{
	bool Done = false;
	for (int i = 0; i < Length; i++)
	{
		for (int k = 0; k < Length - 1; k++)
		{
			if (Array[k] > Array[k + 1])
			{
				Swap(Array[k], Array[k + 1]);
			}
		}
	}
}

void SelectionSort(int* Array, int length)
{
	for (int k = 0; k < length; k++)
	{
		int smallestIndex = k;
		for (int i = k; i < length; i++)
		{
			if (Array[i] < Array[smallestIndex])
			{
				smallestIndex = i;
			}
		}
		Swap(Array[smallestIndex], Array[k]);
	}
}

void InsertionSort(int* Array, int length)
{
	int* ArrayTwo = new int[length];
	for (int i = 1; i < length; i++)
	{
		for (int k = 0; k < length; k++)
		{
			if (Array[k] < Array[k - 1])
			{
				Swap(Array[k], Array[k-1]);
			}
		}
	}
}

int main()
{
	int* Stuff = new int[5]{ 5, 2, 1, 3, 4 };
	for (int i = 0; i < 5; i++)
	{
		cout << Stuff[i] << endl;
	}
	InsertionSort(Stuff, 5);
	cout << endl;
	for (int i = 0; i < 5; i++)
	{
		cout << Stuff[i] << endl;
	}
	return 0;
}