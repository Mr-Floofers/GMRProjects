using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind
{
    class UnionFind
    {
        public int[] Sets;
        Dictionary<string, int> stuffs;
        public UnionFind(string[] data)
        {
            int amount = int.Parse(data[0]);
            Sets = new int[14];
            for (int i = 0; i < Sets.Length; i++)
            {
                Sets[i] = -1;
            }
            stuffs = new Dictionary<string, int>();
            for (int i = 0; i < amount; i++)
            {
                stuffs.Add(data[i + 1], i);
            }
        }

        public void Union(string p, string q)
        {
            stuffs.TryGetValue(p, out int pVal);
            stuffs.TryGetValue(q, out int qVal);

            Sets[pVal] = pVal;
            Sets[qVal] = pVal;
            for (int i = 0; i < Sets.Length; i++)
            {
                if (Sets[i] == qVal)
                {
                    Sets[i] = pVal;

                }
            }
            stuffs[q] = pVal;

            //for(int i = 0; i < Sets.Length; i++)
            //{
            //    if(i == pVal)
            //    {
            //        Sets[i] = pVal;
            //        Sets[qVal] = pVal;
            //    }
            //}

            //for (int i = 0; i < Sets.Length; i++)
            //{
            //    if (i == pVal)
            //    {
            //        Sets[i] = pVal;
            //        for (int k = 0; k < Sets.Length; k++)
            //        {
            //            if (Sets[k] == qVal)
            //            {
            //                Sets[k] = pVal
            //            }
            //        }
            //    }
            //}

            //int pPos;
            //stuffs.TryGetValue(p, out pPos);
            //int qPos;
            //stuffs.TryGetValue(q, out qPos);

            //for (int i = 0; i < Sets.Length; i++)
            //{
            //    if (Sets[i] == Sets[pPos])
            //    {
            //        Sets[i] = Sets[qPos];
            //    }
            //}
        }

        public bool Connected(int p, int q)
        {
            return Sets[p] == Sets[q];
        }

        public int Find(int pos)
        {
            return Sets[pos];
        }

    }
}
