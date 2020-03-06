using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{

    public class Program
    {
        public static void ListSwap(int IndexA, int IndexB, List<int> data)
        {
            int temp = data[IndexA];
            data[IndexA] = data[IndexB];
            data[IndexB] = temp;
        }

        public static void InsertionSort(List<int> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                for (int k = i; k > 0; k--)
                {
                    if (data[k] < data[k - 1])
                    {
                        int temp = data[k];
                        data[k] = data[k - 1];
                        data[k - 1] = temp;
                    }
                }
            }
        }

        public static void MergeSort(List<int> data)
        {
            if (data.Count() <= 1)
            {
                return;
            }
            int mid = data.Count() / 2;
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < mid; i++)
            {
                left.Add(data[i]);
            }

            for (int i = 0; i < data.Count() - mid; i++)
            {
                right.Add(data[i + mid]);
            }

            MergeSort(right);
            MergeSort(left);

            Merge(right, left, data);

            
        }

        public static void Merge(List<int> leftData, List<int> rightData, List<int> originalData)
        {
            int right = 0;
            int left = 0;
            int middle = 0;

            while(right < rightData.Count() && left < leftData.Count())
            {
                if(rightData[right] < leftData[left])
                {
                    originalData[middle] = rightData[right];
                    right++;
                }
                else
                {
                    originalData[middle] = leftData[left];
                    left++;
                }
                middle++;
            }
            while(right < rightData.Count())
            {
                originalData[middle] = rightData[right];
                middle++;
                right++;
            }
            while(left < leftData.Count())
            {
                originalData[middle] = leftData[left];
                middle++;
                right++;
            }
        }

        public static void QuickSort(List<int> data, int start, int end)
        {
            if (start < end)
            {
                int i = LomutoPartion(data, start, end);
                QuickSort(data, start, i-1);
                QuickSort(data, i + 1, end);
            }
        }

        public static int LomutoPartion(List<int> data, int start, int end)
        {
            int pivotIndex = end;
            int wall = start - 1;

            for(int i = start; i < end; i++)
            {
                if(data[i] < data[pivotIndex])
                {
                    wall++;
                    //ListSwap(i, wall, data);
                    int temp = data[i];
                    data[i] = data[wall];
                    data[wall] = temp;
                }
            }

            //ListSwap(wall+1, pivotIndex, data);
            int temp2 = data[wall + 1];
            data[wall + 1] = data[pivotIndex];
            data[pivotIndex] = temp2;

            return wall+1;
        }

        public static void Main(string[] args)
        {

        }
    }
}

//(^>^)
//  ˠ
//  Ʌ
//  |
//this is happy person, make your code work to make them stay happy