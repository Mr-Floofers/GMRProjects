#pragma once
#include <memory>
class Node
{
public:
	int value;
	std::unique_ptr<Node> rightNode;
	std::unique_ptr<Node> leftNode;

	Node(int value)
	{
		this->value = value;
	}

	int Height()
	{
		int leftH = 0;
		int rightH = 0;

		if (rightNode != nullptr)
		{
			rightH = rightNode.get()->Height();
		}
		if (leftNode != nullptr)
		{
			leftH = leftNode.get()->Height();
		}


		if (leftH > rightH)
		{
			return leftH + 1;
		}
		return rightH + 1;
	}

	int BalanceValue()
	{
		int rightHeight = 0;
		int leftHeight = 0;
		if (rightNode != nullptr)
		{
			rightHeight = rightNode->Height();
		}
		if (leftNode != nullptr)
		{
			leftHeight = leftNode->Height();
		}

		return rightHeight - leftHeight;
	}

	int ChildCount()
	{
		int children = 0;
		if (rightNode != nullptr)
		{
			children++;
		}
		if (leftNode != nullptr)
		{
			children++;
		}
		return children;
	}

	std::unique_ptr<Node> Child()
	{
		if (leftNode != nullptr)
		{
			return std::move(leftNode);
		}
		if (rightNode != nullptr)
		{
			return std::move(rightNode);
		}
		return nullptr;
	}

private:
};

