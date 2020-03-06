template <typename T>
void Tree<T>::Add(const T& value)
{
	Tree<T>::Count++;
	if (Head == nullptr)
	{
		Head = new Node<T>(value);
		return;
	}
	Node<T>* current = Head;

	while (current != nullptr)
	{
		if (current->value < value)
		{	
			if (current->left == nullptr)
			{
				current->left = new Node<T>(value);
				break;
			}
			else
			{
				current = current->left;
			}
		}
		else if (current->value > value)
		{
			if(current->right == nullptr)
			{
				current->right = new Node<T>(value);
				break;
			}
			else
			{
				current = current->right;
			}
		}
		else
		{
			Tree<T>::Count--;
			return;
		}
	}
	return;
}