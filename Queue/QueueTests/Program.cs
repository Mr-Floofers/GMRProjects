using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Queue;

namespace QueueTests
{
    public class Program
    {
        [Fact]
        public void EnTest()
        {
            var q = new Queue.Queue<int>();
            q.Enqueue(6);
            q.Enqueue(7);
            Assert.Equal(6, q.Peek());
        }

        [Fact]
        public void DeTest()
        {
            var q = new Queue.Queue<int>();
            q.Enqueue(6);
            q.Enqueue(7);
            q.Dequeue();
            Assert.Equal(7, q.Peek());
        }

        [Fact]
        public void ClearTest()
        {
            var q = new Queue.Queue<int>();
            q.Enqueue(6);
            q.Enqueue(7);
            q.Clear();
            var d = new Queue.Queue<int>();
            d.Enqueue(6);
            d.Enqueue(7);
            Assert.True(q!=d);
        }
    }
}
