#pragma once
#include "Node.h"
class SingleLinkedList
{
public:
	void AddFirst(int value);
	void AddLast(int value);
	void AddBefore(int value, int searchValue);
	void AddAfter(int value, int searchValue);
	void RemoveFirst();
	void RemoveLast();
	void RemoveAt(int value);
private:
	Node* Head;
	int length;
};
void SingleLinkedList::AddFirst(int value)
{
	length++;
	if (Head == nullptr)
	{
		Head = new Node(value);
		return;
	}
	Node* newNode = new Node(value);
	newNode->next = Head;
	Head = newNode;
}

void SingleLinkedList::AddLast(int value)
{
	length++;
	if (Head == nullptr)
	{
		Head = new Node(value);
		return;
	}
	Node* newNode = new Node(value);
	Node* current = Head;
	for (int i = 0; i < length - 2; i++)
	{
		current = current->next;
	}
	current->next = newNode;
}

void SingleLinkedList::AddBefore(int value, int searchValue)
{
	length++;
	if (Head == nullptr)
	{
		Head = new Node(value);
		return;
	}
	Node* newNode = new Node(value);
	Node* current = Head;
	while (current->next->value != searchValue)
	{
		current = current->next;
	}
	newNode->next = current->next;
	current->next = newNode;
}

void SingleLinkedList::AddAfter(int value, int searchValue)
{
	length++;
	if (Head == nullptr)
	{
		Head = new Node(value);
		return;
	}
	Node* newNode = new Node(value);
	Node* current = Head;
	while (current->value != searchValue)
	{
		current = current->next;
	}
	newNode->next = current->next;
	current->next = newNode;
}

void SingleLinkedList::RemoveFirst()
{
	if (Head == nullptr)
	{
		throw "There are no nodes. Cannot remove.";
	}
	length--;
	Node* deleteMe = Head;
	Head = Head->next;
	delete deleteMe;
}

void SingleLinkedList::RemoveLast()
{
	if (Head == nullptr)
	{
		throw "There are no nodes. Cannot remove.";
	}
	length--;
	Node* current = Head;
	while (current->next->next != nullptr)
	{
		current = current->next;
	}
	Node* deleteMe = current->next;
	current->next = nullptr;
	delete deleteMe;
}

void SingleLinkedList::RemoveAt(int value)
{
	if (Head == nullptr)
	{
		throw "There are no nodes. Cannot remove.";
	}
	length--;
	Node* current = Head;
	bool valueExist = false;
	while (current->next->value != value && current->next != nullptr)
	{
		current = current->next;
	}

	if (current->next == nullptr)
	{
		throw "There are no nodes of this value. Cannot remove.";
	}

	Node* deleteMe = current->next;
	current->next = current->next->next;
	delete deleteMe;
}


