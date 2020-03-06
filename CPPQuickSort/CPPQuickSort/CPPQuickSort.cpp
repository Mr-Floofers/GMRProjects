#include <iostream>
#include <random>

void Swap(int& ValueA, int& ValueB)
{
	int temp = ValueA;
	ValueA = ValueB;
	ValueB = temp;
}

int LomutoPartioning(int*& data, int start, int end)
{
	int pivotIndex = end - 1;
	int wall = start - 1;

	for (int i = start; i < end; i++)
	{
		if (data[i] < data[pivotIndex])
		{
			wall++;
			Swap(data[wall], data[i]);
		}
	}

	Swap(data[wall + 1], data[pivotIndex]);

	return pivotIndex;
}

void QuickSort(int*& data, int start, int end)
{
	
	for (int i = start; i < end; i++)
	{
		std::cout << "Data " << i + 1 << ": " << data[i] << std::endl;
	}
	std::cout << std::endl;
	if (start < end)
	{
		int i = LomutoPartioning(data, start, end);
		QuickSort(data, start, i);
		QuickSort(data, i + 1, end);
	}
}

int main()
{

	int* data = new int[7];
	data[0] = 7;
	data[1] = 4;
	data[2] = 3;
	data[3] = 6;
	data[4] = 2;
	data[5] = 1;
	data[6] = 5;

	/*for (int i = 0; i < 5; i++)
	{
		data[i] = rand()%100;
		std::cout << "Data " << i + 1 << ": " << data[i] << std::endl;
	}*/
	QuickSort(data, 0, 7);
	for (int i = 0; i < 7; i++)
	{
		std::cout << "Data " << i + 1 << ": " << data[i] << std::endl;
	}
}
