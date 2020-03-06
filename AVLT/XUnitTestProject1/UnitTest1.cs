using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void AddTest()
        {
            var tree = new AVLT.Tree<int>();
            tree.Add(7);
            tree.Add(16);
            tree.Add(17);

            Assert.Equal(16, tree.Root.Value);
        }

        [Fact]
        public void RemoveTest()
        {
            var tree = new AVLT.Tree<int>();
            tree.Add(10);
            tree.Add(15);
            tree.Add(5);
            tree.Add(20);
            tree.Add(1);
            tree.Add(7);
            tree.Add(12);

            tree.Remove(20);
            tree.Remove(5);

            Assert.Equal(1, tree.Root.LeftNode.Value);
            //Assert.Null(tree.Root.RightNode.RightNode);
        }
    }
}
