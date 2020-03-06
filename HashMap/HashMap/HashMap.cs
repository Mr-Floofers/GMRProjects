using System;
using System.Collections.Generic;
using System.Text;

namespace HashMap
{
    class HashMap<T>
    {
        int Size;
        int Count = 0;
        LinkedList<Node<KeyValuePair<T>>>[] Data;
        
        public HashMap(int capacity = 10000)
        {
            Size = capacity;
            Data = new LinkedList<Node<KeyValuePair<T>>>[Size];
        }
        public int Hash(string input)
        {
            int hash = 0;
            for(int i = 0; i < )
        }
        
    }
}
