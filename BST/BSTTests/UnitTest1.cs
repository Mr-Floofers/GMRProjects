using System;
using Xunit;
using BST;
using System.Collections.Generic;

namespace BSTTests
{
    public class UnitTest1
    {
        [Fact]
        public void AddTest()
        {
            var Tree = new Tree<int>();
            Tree.Add(4);
            Tree.Add(3);
            Tree.Add(5);
            Assert.Equal(4, Tree.Head.Value);
            Assert.Equal(3, Tree.Head.Left.Value);
            Assert.Equal(5, Tree.Head.Right.Value);
        }

        [Fact]
        public void RemoveTest()
        {
            var Tree = new Tree<int>();
            Tree.Add(4);
            Tree.Add(1);
            Tree.Add(10);
            Tree.Add(9);
            Tree.Add(12);
            Tree.Remove(10);
            Assert.Equal(9, Tree.Head.Right.Value);
        }

        //[Fact]
        //public void PreOrderTest()
        //{
        //    var Tree = new Tree<int>();
        //    Tree.Add(4);
        //    Tree.Add(1);
        //    Tree.Add(10);
        //    Tree.Add(9);
        //    Tree.Add(12);

        //    var tree = Tree.PreOrder();
        //    Stack<int> good = new Stack<int>();
        //    good.Push(4);
        //    good.Push(1);
        //    good.Push(10);
        //    good.Push(9);
        //    good.Push(12);

        //    for (int i = 0; i < tree.Count; i++)
        //    {
        //        Assert.Equal(good.Pop(), tree.Pop());
        //    }
            
        //}

        //public void InOrderTest()
        //{
        //    var Tree = new Tree<int>();
        //    Tree.Add(4);
        //    Tree.Add(1);
        //    Tree.Add(10);
        //    Tree.Add(9);
        //    Tree.Add(12);

        //    var tree = Tree.PreOrder();
        //    Stack<int> good = new Stack<int>();
        //    good.Push(1);
        //    good.Push(4);
        //    good.Push(10);
        //    good.Push(9);
        //    good.Push(12);

        //    //for (int i = 0; i < tree.Count; i++)
        //    //{
        //    //    Assert.Equal(good.Pop(), tree.Pop());
        //    //}

        //}

    }
}
