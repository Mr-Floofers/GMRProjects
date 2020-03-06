using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void AddTest()
        {
            var tree = new RBTree.Tree<int>();
            tree.Add(10);
            tree.Add(15);
            tree.Add(5);
            tree.Add(20);

            Assert.Equal(10, tree.Root.Value);//jk prank it works
        }

        [Fact]
        public void RemoveTest()
        {
            var tree = new RBTree.Tree<int>();
            tree.Add(10);
            tree.Add(15);
            tree.Add(5);
            tree.Add(20);
            tree.Add(1);
            tree.Add(7);
            tree.Add(12);
            tree.Remove(12);
            tree.Remove(5);

            Assert.Equal(1, tree.Root.Left.Left.Value);
        }
    }
}
