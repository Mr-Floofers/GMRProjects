#pragma once
#include "Node.h"

template <typename T>
class Tree
{
public:
	Node<T>* Head;
	int Count = 0;

	void Add(const T& value);
	void Remove(const T& value);
	
private:
};

#include "Tree.tpp"