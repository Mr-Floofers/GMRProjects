#include <iostream>
#include <memory>
using namespace std;


class Node
{
public:
	int value;
	unique_ptr<Node> leftChild;
	unique_ptr<Node> rightChild;
	Node* parent;

	unique_ptr<Node> child()
	{
		if (leftChild.get() == nullptr)
		{
			return std::move(rightChild);
		}
		else
		{
			return std::move(leftChild);
		}
	}
	bool IsLeft()
	{
		if (parent->leftChild.get() == nullptr)
		{
			return false;
		}
		else if (parent->leftChild.get() == this)
		{
			return true;
		}
		return false;

	}
	bool IsRight()
	{
		if (parent->rightChild.get() == nullptr)
		{
			return false;
		}
		if (parent->rightChild.get() == this)
		{
			return true;
		}
		return false;
	}
	int childCount();
	Node(int value)
	{
		this->value = value;
	}
};
int Node::childCount()
{
	int count = 0;
	if (leftChild != nullptr)
	{
		count++;
	}
	if (rightChild != nullptr)
	{
		count++;
	}
	return count;
}

class BST
{
public:
	unique_ptr<Node> Head;
	int Count = 0;
	Node* Minimum(Node* node);
	void InOrder();
	Node* Maximum(Node* node);
	void Insert(int value);
	void Delete(int value);
	void DeleteOnNode(Node* node);
	int* Values;
};
void BST::Insert(int value)
{
	Count++;
	if (Head == nullptr)
	{
		Head = make_unique<Node>(value);
		Head->parent = nullptr;
		return;
	}
	Node* current = Head.get();
	Node* parent = Head->parent;
	while (current != nullptr)
	{
		if (value >= current->value)
		{
			if (current->rightChild == nullptr)
			{
				current->rightChild = make_unique<Node>(value);
				current->rightChild->parent = current;
				break;
			}
			current = current->rightChild.get();
		}
		else
		{
			if (current->leftChild == nullptr)
			{
				current->leftChild = make_unique<Node>(value);
				current->leftChild->parent = current;
				break;
			}
			current = current->leftChild.get();
		}
	}
}

void BST::DeleteOnNode(Node* node)
{
	Node* current = node;
	if (current->childCount() == 0)
	{
		if (current->IsLeft())
		{
			current->parent->leftChild = nullptr;
			current = nullptr;
			delete current;
		}
		else
		{
			current->parent->rightChild = nullptr;
			current = nullptr;
			delete current;
		}
	}
	else if (current->childCount() == 1)
	{
		current->child()->parent = current->parent;
		current->parent->leftChild = std::move(current->child());
		current = nullptr;
		delete current;
	}
}

void BST::Delete(int value)
{
	if (Head == nullptr)
	{
		return;
	}
	Count--;
	Node* current = Head.get();
	while (current->value != value)
	{
		if (value >= current->value)
		{
			current = current->rightChild.get();
		}
		else
		{
			current = current->leftChild.get();
		}
	}
	if (current->childCount() == 0)
	{
		if (current->IsLeft())
		{
			current->parent->leftChild = nullptr;
			current = nullptr;
			delete current;
		}
		else
		{
			current->parent->rightChild = nullptr;
			current = nullptr;
			delete current;
		}
	}
	else if (current->childCount() == 1)
	{
		if (current->IsLeft())
		{
			current->child()->parent = current->parent;
			current->parent->leftChild = std::move(current->child());
			current = nullptr;
			delete current;
		}
		else if (current->IsRight())
		{
			current->child()->parent = current->parent;
			current->parent->rightChild = std::move(current->child());
			current = nullptr;
			delete current;
		}
	}
	else if (current->childCount() == 2)
	{
		Node* temp = current;
		temp = Maximum(temp->leftChild.get());
		current->value = temp->value;
		current = temp;
		DeleteOnNode(temp);
	}
}



Node* BST::Maximum(Node* node)
{
	while (node->rightChild.get() != nullptr)
	{
		node = node->rightChild.get();
	}
	return node;
}

Node* BST::Minimum(Node* node)
{
	while (node->leftChild != nullptr)
	{
		node = node->leftChild.get();
	}
	return node;
}

void BST::InOrder()
{
	
}

int main()
{
	BST tree = BST();
	tree.Insert(3);
	tree.Insert(2);
	tree.Insert(4);
	tree.Delete(3);
	for (int i = 0; i < tree.Count; i++)
	{

	}
}