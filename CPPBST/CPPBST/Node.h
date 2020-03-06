#pragma once
template <typename T>
class Node
{
public:
	Node(const T& value);
	Node(const T& value, Node<T>* currentNode);
	T value;
	Node<T>* right;
	Node<T>* left;
private:
};

#include "Node.tpp"

