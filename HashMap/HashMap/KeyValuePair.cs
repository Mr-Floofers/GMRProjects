using System;
using System.Collections.Generic;
using System.Text;

namespace HashMap
{
    class KeyValuePair<T>
    {
        int Key;
        T Value;
        public KeyValuePair(int key, T value)
        {
            Key = key;
            Value = value;
        }
        public int GetKey()
        {
            return Key;
        }
        public T GetValue()
        {
            return Value;
        }
    }
}
