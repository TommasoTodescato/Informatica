
using System.Runtime.ExceptionServices;

namespace matrici
{
    internal class matrix
    {
        private int rows, cols;
        private int[,] m;

        public matrix(int rows, int cols, bool fill, int min, int max)
        {
            this.rows = rows;
            this.cols = cols;
            m = new int[rows, cols];
            if (!fill) return;
         
            Random r = new Random();
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    m[i, j] = r.Next(min, max);
        }
        
        public void print()
        {
            for (int i = 0; i < rows; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < cols; j++)
                    Console.Write(m[i, j] + " ");
                Console.WriteLine("|");
            }
        }

        public void scalar_product(int mul)
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    m[i, j] *= mul;
        }

        public void dot_product(matrix m2)
        {
            if (cols != m2.rows) return;
            
            int[,] res = new int[rows, m2.cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < m2.cols; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < cols; k++)
                        sum += m[i, k] * m2.m[k, j];

                    res[i, j] = sum;
                }
            }
            cols = m2.cols;
            m = res;
        }

        public void sum(matrix m2)
        {
            if (rows != m2.rows || cols != m2.cols) return;

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    m[i, j] += m2.m[i, j];
        }


        public void transpose()
        {
            int[,] tmp = new int[cols, rows];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    tmp[j, i] = m[i, j];

            int tr = rows;
            rows = cols;
            cols = tr;
            m = tmp;
        }

    }
}