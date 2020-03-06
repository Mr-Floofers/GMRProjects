
#include <iostream>
#include <random>
#include <string>
#include <memory>

class Person
{
public:
	const std::string& Name = name;
	Person(std::string name);
private:
	std::string name;
};
Person::Person(std::string name)
{
	this->name = name;
}

class Node
{
public:
	int value;
	std::unique_ptr<Node> next;
	Node(int value);
private:

};
Node::Node(int value)
{
	this->value = value;
}

class List
{
public:
	void AddLast(int value);
	void PrintList();
private:
	std::unique_ptr<Node> Head;
	Node* Tail;
	int length;
};
void List::AddLast(int value)
{
	length++;
	if (Head == nullptr)
	{
		Head = std::make_unique<Node>(value);
		return;
	}
	Tail->next->value = value;
	Tail = Tail->next.get();
}
void List::PrintList()
{
	std::cout << "Length: " << length << std::endl;
	Node* current = Head.get();
	for (int i = 0; i < length; i++)
	{
		std::cout << "Item " << i+1 << ": " << current->value << std::endl;
		current = current->next.get();
	}
}


int main()
{
	/*
	int *x = new int(5);

	// every new needs to have a corresponding delete

	delete x;

	x = nullptr;

	// arrays
	int* numbers = new int[5];

	delete[] numbers;

	numbers = nullptr;


	if (numbers == nullptr)
	{
		// do something
	}
	

	// create an array of 5 numbers, fill a random number into it, print it
	//numbers = new int[5];
	for (int i = 0; i < 5; i++)
	{
		int num = rand() % 100;
		numbers[i] = num;
		std::cout << num << std::endl;
	}

	//delete[] numbers;
	//numbers = nullptr;
	*/
	// create a Person class, instantiate couple Person variable and give them names and print out names

	//Person* me = new Person("dennis");
	//Person* badMan = new Person("prince");

	//std::cout << me->Name << std::endl << "badMan = " << badMan->Name << std::endl;

	//delete badMan;
	//delete me;
	//badMan = nullptr;
	//me = nullptr;


	//std::unique_ptr<Person> badManClone1 = std::make_unique<Person>("prince");
	//std::cout << "Memory address: " << badManClone1 << " ----- " << badManClone1.get() << std::endl; ;


	//std::unique_ptr<Person> badManClone2 = std::make_unique<Person>("prince");
	//std::unique_ptr<Person> badManClone3 = std::make_unique<Person>("prince");
	//std::unique_ptr<Person> badManClone4 = std::make_unique<Person>("prince");
	//std::unique_ptr<Person> badManClone5 = std::make_unique<Person>("prince");


	//std::cout << badManClone1->Name << std::endl;
	//std::cout << badManClone2->Name << std::endl;
	//std::cout << badManClone3->Name << std::endl;
	//std::cout << badManClone4->Name << std::endl;
	//std::cout << badManClone5->Name << std::endl;

	//std::unique_ptr<int> numbers[5];
	//for (int i = 0; i < 5; i++)
	//{
	//	numbers[i] = std::make_unique<int>(rand() % 100);
	//	std::cout << *numbers[i] << std::endl;
	//}


	
	// you cannot assign to badmanclone again

	//badManClone1 = badManClone2;	//cant do this




	std::unique_ptr<Person> test = std::make_unique<Person>("karan");

	std::cout << test->Name << std::endl;

	std::cout << test << std::endl;

	std::unique_ptr<Person> otherPerson = std::move(test);

	std::cout << otherPerson->Name << std::endl;
	std::cout << otherPerson << std::endl;

	if (test == nullptr)
	{
		std::cout << "test is null" << std::endl;
	}

	// create a singly linked list with smartpointers with the following functions: addlast, printlist
	List* list = new List();

	list->AddLast(1);
	list->AddLast(2);
	list->AddLast(3);
	list->AddLast(4);

	list->PrintList();

	return 0;
}

