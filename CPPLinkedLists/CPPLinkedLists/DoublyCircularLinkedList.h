#pragma once
#include "Node.h"
#include <iostream>
#include ""

class DoublyCircularLinkedList
{
public:
	void AddFirst(int value);
	void AddLast(int value);
	void AddBefore(int value, int nodeValue);
	void AddAfter(int value, int nodeValue);
	void RemoveFirst();
	void RemoveLast();
	void RemoveAt(int value);

	const int& Count = length;
private:
	Node* Head;
	Node* Tail;
	int length;
};

void DoublyCircularLinkedList::AddFirst(int value)
{
	length++;
	if (Head == nullptr)
	{
		Head = new Node(value);
		Tail = Head;
		Tail->next = Head;
		Head->next = Tail;
		Tail->pre = Head;
		Head->pre = Tail;
		return;
	}

	Node* node = new Node(value);
	Tail->next = node;
	Head->pre = node;
	node->next = Head;
	node->pre = Tail;
	Head = node;
	Tail->next = Head;
	Head->pre = Tail;
}

void DoublyCircularLinkedList::AddLast(int value)
{
	length++;
	if (Head == nullptr)
	{
		Head = new Node(value);
		Tail = Head;
		Tail->next = Head;
		Head->next = Tail;
		Tail->pre = Head;
		Head->pre = Tail;
		return;
	}

	Node* node = new Node(value);
	Tail->next = node;
	Tail->next->next = Head;
	Head->pre = node;
	node->pre = Tail;
	Tail = node;
	Tail->next = Head;
	Head->pre = Tail;
}

void DoublyCircularLinkedList::AddBefore(int value, int nodeValue)
{
	length++;
	if (Head == nullptr)
	{
		Head = new Node(value);
		Tail = Head;
		Tail->next = Head;
		Head->next = Tail;
		Tail->pre = Head;
		Head->pre = Tail;
		return;
	}
	Node* current = Head;
	while (current->value != nodeValue)
	{
		current = current->next;
	}
	Node* nodeToAdd = new Node(value);
	current->pre->next = nodeToAdd;
	nodeToAdd->pre = current->pre;
	nodeToAdd->next = current;
	current->pre = nodeToAdd;
}

void DoublyCircularLinkedList::AddAfter(int value, int nodeValue)
{
	length++;
	if (Head == nullptr)
	{
		Head = new Node(value);
		Tail = Head;
		Tail->next = Head;
		Head->next = Tail;
		Tail->pre = Head;
		Head->pre = Tail;
		return;
	}
	Node* current = Head;
	while (current->value != nodeValue)
	{
		current = current->next;
	}
	Node* nodeToAdd = new Node(value);
	current->next->pre = nodeToAdd;
	nodeToAdd->next = current->next;
	nodeToAdd->pre = current;
	current->next = nodeToAdd;
}

void DoublyCircularLinkedList::RemoveFirst()
{
	if (Head == nullptr)
	{
		std::cout << "Stop trying to remove something that doesn't exist" << std::endl << "Ur bad" << std::endl;
		return;
	}
	length--;
	Tail->next = Head->next;
	Head->next->pre = Tail;
	Head = Head->next;
}

void DoublyCircularLinkedList::RemoveLast()
{
	if (Head == nullptr)
	{
		std::cout << "Stop trying to remove something that doesn't exist" << std::endl << "Ur bad" << std::endl;
		return;
	}
	length--;
	Head->pre = Tail->pre;
	Tail->pre->next = Head;
	Tail = Tail->pre;
}

void DoublyCircularLinkedList::RemoveAt(int value)
{
	if (Head == nullptr)
	{
		std::cout << "Stop trying to remove something that doesn't exist" << std::endl  << "Ur bad" << std::endl;
		return;
	}

	Node* nodeToRemove = Head;
	while (nodeToRemove->value != value)
	{
		nodeToRemove = nodeToRemove->next;
	}
	length--;
	nodeToRemove->pre->next = nodeToRemove->next;
	nodeToRemove->next->pre = nodeToRemove->pre;
}

