using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DoublyCircularlyLinkedList;

namespace CLLTest
{
    public class Testing
    {

        [Fact]
        public void EmptyListCountIsZero()
        {
            var list = new DoublyCircularlyLinkedList.LinkedList<int>();

            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void IsHeadGoodFirst()
        {
            var list = new DoublyCircularlyLinkedList.LinkedList<int>();
            list.AddFirst(16);
            Assert.Equal(16, list.Head.value);
        }

        [Fact]
        public void IsTailGoodFirst()
        {
            var list = new DoublyCircularlyLinkedList.LinkedList<int>();
            list.AddFirst(16);
            list.AddFirst(14);
            Assert.Equal(16, list.Tail.value);
        }

        [Fact]
        public void IsHeadGoodLast()
        {
            var list = new DoublyCircularlyLinkedList.LinkedList<int>();
            list.AddLast(16);
            Assert.Equal(16, list.Head.value);
        }

        [Fact]
        public void IsTailGoodLast()
        {
            var list = new DoublyCircularlyLinkedList.LinkedList<int>();
            list.AddLast(16);
            list.AddLast(14);
            Assert.Equal(14, list.Tail.value);
        }

        [Fact]
        public void AddBeforeTest()
        {
            var list = new DoublyCircularlyLinkedList.LinkedList<int>();
            list.AddFirst(16);
            list.AddLast(15);
            list.AddLast(14);
            list.AddLast(13);
            list.AddLast(12);
            list.AddLast(11);
            list.AddLast(10);
            list.AddLast(9);
            list.AddLast(8);
            list.AddLast(7);
            list.AddLast(6);
            list.AddLast(5);
            list.AddBefore(4, 4);
            Assert.Equal(4, list.Head.next.next.next.next.value);
        }

        [Fact]
        public void AddAfterTest()
        {
            var list = new DoublyCircularlyLinkedList.LinkedList<int>();
            list.AddFirst(16);
            list.AddLast(14);
            list.AddAfter(7348, 0);
            Assert.Equal(7348, list.Head.next.value);
        }

        [Fact]
        public void RemoveFirstTest()
        {
            var list = new DoublyCircularlyLinkedList.LinkedList<int>();
            list.AddFirst(0);
            list.AddAfter(1, 0);
            list.AddAfter(2, 1);
            list.AddAfter(3, 2);
            list.RemoveFirst();
            Assert.Equal(1, list.Head.value);
        }

        [Fact]
        public void RemoveLastTest()
        {
            var list = new DoublyCircularlyLinkedList.LinkedList<int>();
            list.AddFirst(0);
            list.AddAfter(1, 0);
            list.AddAfter(2, 1);
            list.AddAfter(3, 2);
            list.RemoveLast();
            Assert.Equal(2, list.Tail.value);
        }

        [Fact]
        public void RemoveTest()
        {
            var list = new DoublyCircularlyLinkedList.LinkedList<int>();
            list.AddFirst(0);
            list.AddAfter(1, 0);
            list.AddAfter(2, 1);
            list.AddAfter(3, 2);
            list.Remove(2);
            Assert.Equal(3, list.Head.next.next.value);
        }
    }

    /*[Fact]
    public void PassingTest()
    {
        Assert.Equal(4, Add(2, 2));
    }

    [Fact]
    public void FailingTest()
    {
        Assert.Equal(5, Add(2, 2));
    }

    [Fact]
    public void WrongSumPasses()
    {
        Assert.False(5 == Add(2, 2));
    }

    int Add(int x, int y)
    {
        return x + y;
    }

    [Theory]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(6)]
    public void MyFirstTheory(int value)
    {
        Assert.True(IsOdd(value));
    }

    bool IsOdd(int value)
    {
        return value % 2 == 1;
    }*/
}

