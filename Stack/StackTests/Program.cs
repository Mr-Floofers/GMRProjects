using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Stack;

namespace StackTests
{
   public class Program
    {
        [Fact]
        public void PushTest()
        {
            var stack = new Stack.Stack<int>();
            stack.Push(7);
            stack.Push(8);
            Assert.Equal(8, stack.data[stack.count-1]);
        }

        [Fact]
        public void PopTest()
        {
            var stack = new Stack.Stack<int>();
            stack.Push(7);
            stack.Push(8);
            stack.Pop();
            Assert.Equal(7, stack.data[stack.count-1]);
        }

        [Fact]
        public void PeekTest()
        {
            var stack = new Stack.Stack<int>();
            stack.Push(7);
            stack.Push(8);
            Assert.Equal(8, stack.peek());
        }

        [Fact]
        public void ClearTest()
        {
            var stack = new Stack.Stack<int>();
            stack.Push(7);
            stack.Push(8);
            stack.clear();
            Assert.Equal(0, stack.data[0]);
        }
    }
}
