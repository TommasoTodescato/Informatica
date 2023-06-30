using System;
using System.Collections.Generic;
using System.Linq;

namespace Tombola
{
    internal class CCartella
    {
        private CCasella[,] mCartella;
        public CCasella[,] Cartella
        {
            get { return mCartella; }
            set { mCartella = value; }
        }

        public int MaxWin;

        public CCartella()
        {
            MaxWin = 0;
            Cartella = new CCasella[9, 3];
            int[,] r = new int[9, 3];
            for (int i = 0; i < 9; i++)
            {
                int[] temp;
                if (i == 0)
                    temp = GetRandoms(3, 1, 10);
                else
                    temp = GetRandoms(3, 10 * i, (10 * i) + 10);
                for (int j = 0; j < 3; j++)
                {
                    r[i, j] = temp[j];
                }
            }

            for (int j = 0; j < 3; j++)
            {
                int[] tmp = GetRandoms(4, 0, 9);
                for (int i = 0; i < 9; i++)
                    Cartella[i, j] = new CCasella(i, j, r[i, j], !tmp.Contains(i));
            }
        }

        // Generates n random numbers. (start <= x < end)
        public static int[] GetRandoms(int n, int start, int end)
        {
            int[] result = new int[n];
            Random rnd = new Random();
            HashSet<int> AlreadyUsed = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                var range = Enumerable.Range(start, end).Where(k => !AlreadyUsed.Contains(k));
                int index = rnd.Next(0, end - start - AlreadyUsed.Count);
                result[i] = range.ElementAt(index);
                AlreadyUsed.Add(result[i]);
            }
            return result;
        }

    }
}
