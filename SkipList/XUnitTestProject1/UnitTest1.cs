using System;
using Xunit;
using SkipList;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void AddTest()
        {
            var Thing = new Tree<int>();
            Thing.Add(1);
            Thing.Add(2);
            Thing.Add(6);
            Thing.Add(5);
            Assert.Equal(5, Thing.Head[0][0][0].Value);
        }
        
        [Fact]
        public void RemoveTest()
        {
            var Thing = new Tree<int>();
            Thing.Add(1);
            Thing.Add(2);
            Thing.Add(6);
            Thing.Add(5);
            Thing.Remove(6);
            Thing.Remove(2);
            Assert.Equal(5, Thing.Head[0][0].Value);
        }
    }
}
