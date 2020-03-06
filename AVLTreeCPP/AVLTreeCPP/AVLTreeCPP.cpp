#include <iostream>	
#include <memory>
#include "Tree.h"

int main()
{
	AVLTree tree;
	tree.Insert(9);
	tree.Insert(8);
	tree.Insert(7);
	tree.Insert(6);
	tree.Insert(5);
	tree.Delete(5);
	tree.Delete(6);
	tree.Delete(8);
}
