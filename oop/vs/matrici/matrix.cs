using System.Runtime.CompilerServices;

namespace matrici
{
    internal class matrix
    {
        private int rows, cols;
        private int[,] m;

        public matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            m = new int[rows, cols];
        }

        public void scalar_product(int mul)
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    m[i, j] *= mul;
        }

        public void dot_product(matrix m2)
        {
            if (rows != m2.rows || cols != m2.cols) return;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < m2.rows; k++)
                    {
                        sum += m[i, j] * m[k, j];

                    }

                    m[i, j] = sum;
                }
            }

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
