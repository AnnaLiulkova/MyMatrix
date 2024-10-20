using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMatrix1
{
    public partial class MyMatrix
    {
        // Оператор додавання
        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            if (a.Height != b.Height || a.Width != b.Width)
                throw new InvalidOperationException("Matrix sizes do not match for addition.");

            MyMatrix result = new MyMatrix(new double[a.Height, a.Width]);

            for (int i = 0; i < a.Height; i++)
            {
                for (int j = 0; j < a.Width; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }

        // Оператор множення
        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            if (a.Width != b.Height)
                throw new InvalidOperationException("Matrix sizes do not match for multiplication.");

            MyMatrix result = new MyMatrix(new double[a.Height, b.Width]);

            for (int i = 0; i < a.Height; i++)
            {
                for (int j = 0; j < b.Width; j++)
                {
                    for (int k = 0; k < a.Width; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return result;
        }

        // GetTransponedArray
        private double[,] GetTransponedArray()
        {
            double[,] transposed = new double[Width, Height];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    transposed[j, i] = matrix[i, j];
                }
            }
            return transposed;
        }

        // GetTransponedCopy
        public MyMatrix GetTransponedCopy()
        {
            return new MyMatrix(GetTransponedArray());
        }

        // TransponeMe
        public void TransponeMe()
        {
            matrix = GetTransponedArray();
        }
    }
}
