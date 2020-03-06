template <typename T>
Node<T>::Node(const T& value)
{
	this->value = value;
}

template <typename T>
Node<T>::Node(const T& value, Node<T>* current)
{
	this->value = value;
	if(current->value)
}


