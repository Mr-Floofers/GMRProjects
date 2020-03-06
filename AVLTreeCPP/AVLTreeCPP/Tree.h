#pragma once
#include "Node.h"

class AVLTree
{
public:
	std::unique_ptr<Node> Root;

	std::unique_ptr<Node> RightRotate(std::unique_ptr<Node> node)
	{
		std::unique_ptr<Node> temp = std::move(node->leftNode);
		node->leftNode = std::move(temp->rightNode);
		temp->rightNode = std::move(node);
		return std::move(temp);
	}

	std::unique_ptr<Node> LeftRotate(std::unique_ptr<Node> node)
	{
		std::unique_ptr<Node> temp = std::move(node->rightNode);
		node->rightNode = std::move(temp->leftNode);
		temp->leftNode = std::move(node);
		return std::move(temp);
	}

	std::unique_ptr<Node> Balance(std::unique_ptr<Node> node)
	{
		if (node->BalanceValue() > 1)
		{
			if (node->rightNode->BalanceValue() < -1)
			{
				node->rightNode = RightRotate(std::move(node->rightNode));
			}
			node = LeftRotate(std::move(node));
		}
		if (node->BalanceValue() < -1)
		{
			if (node->leftNode->BalanceValue() > 1)
			{
				node->leftNode = (std::move(node->leftNode));
			}
			node = RightRotate(std::move(node));
		}

		return std::move(node);
	}

	void Insert(int value)
	{
		if (Root == nullptr)
		{
			Root = std::make_unique<Node>(value);
			return;
		}

		Root = insert(std::move(Root), value);

	}

	void Delete(int value)
	{
		if (Root == nullptr)
		{
			return;
		}
		Root = remove(std::move(Root), value);
	}

private:
	std::unique_ptr<Node> insert(std::unique_ptr<Node> current, int value)
	{

		if (current == nullptr)
		{
			current = std::make_unique<Node>(value);
			return current;
		}

		if (current->value < value)
		{
			current->rightNode = insert(std::move(current->rightNode), value);
		}
		else if (current->value >= value)
		{
			current->leftNode = insert(std::move(current->leftNode), value);
		}

		return Balance(std::move(current));
	}
	std::unique_ptr<Node> remove(std::unique_ptr<Node> node, int value)
	{
		if (node == nullptr)
		{
			return nullptr;
		}
		if (node->value < value)
		{
			node->rightNode = remove(std::move(node->rightNode), value);
		}
		else if (node->value > value)
		{
			node->leftNode = remove(std::move(node->leftNode), value);
		}
		else
		{
			if (node->ChildCount() == 2)
			{
				std::unique_ptr<Node> tempNode = min(std::move(node->rightNode));
				node->value = tempNode->value;
				node->rightNode = remove(std::move(node->rightNode), tempNode->value);
			}
			else
			{
				return std::move(node->Child());
			}
		}

		
		return Balance(std::move(node));
	}

	std::unique_ptr<Node> min(std::unique_ptr<Node> node)
	{
		if (node->leftNode == nullptr)
		{
			return node;
		}
		return min(std::move(node->leftNode));
	}
};