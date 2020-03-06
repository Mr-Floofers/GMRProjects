#pragma once

class Node
{
public:
	int value;
	Node* next;
	Node* pre;
	Node(int nodeValue);
private:

};
Node::Node(int nodeValue)
{
	value = nodeValue;
	next = nullptr;
	pre = nullptr;
}