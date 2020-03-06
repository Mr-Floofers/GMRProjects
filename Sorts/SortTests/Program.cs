using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Sorts;

namespace SortTests
{
    public class Program
    {
        [Fact]
        public void InsTest()
        {
            var data = new List<int>
            {
                8,
                4,
                10,
                5,
                2
            };

            Sorts.Program.InsertionSort(data);
            var gooddata = new List<int>
            {
                8,
                4,
                10,
                5,
                2
            };
            gooddata.Sort();

            for (int i = 0; i < gooddata.Count(); i++)
            {
                Assert.Equal(gooddata[i], data[i]);
            }
        }

        [Fact]
        public void MergeSortTest()
        {
            var data = new List<int>
            {
                10,
                9,
                8,
                7,
                6,
                5,
                4,
                3,
                2,
                1
            };

            Sorts.Program.MergeSort(data);
            var gooddata = new List<int>
            {
                10,
                9,
                8,
                7,
                6,
                5,
                4,
                3,
                2,
                1
            };
            gooddata.Sort();
            for (int i = 0; i < gooddata.Count(); i++)
            {
                Assert.Equal(gooddata[i], data[i]);
            }
        }

        [Fact]
        public void QuickSortTest()
        {
            var data = new List<int>();
            var gooddata = new List<int>();
            Random rand = new Random();
            int blah;
            for(int i = 0; i < 7; i++)
            {
                blah = rand.Next(0, 15);
                data.Add(blah);
                gooddata.Add(blah);
            }
            
            Sorts.Program.QuickSort(data, 0, data.Count()-1);
            gooddata.Sort();
            for (int i = 0; i < gooddata.Count(); i++)
            {
                Assert.Equal(gooddata[i], data[i]);
            }
        }
    }
}

//(^>^)
//  ˠ
//  Ʌ
//  |
//this is happy person, make your code work to make them stay happy
