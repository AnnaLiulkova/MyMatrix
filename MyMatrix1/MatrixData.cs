using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMatrix1
{
    public partial class MyMatrix
    {
        private double[,] matrix;

        //копіюючий з іншого примірника цього самого класу MyMatrix;
        public MyMatrix(MyMatrix other)
        {
            matrix = (double[,])other.matrix.Clone();
        }

        //з двовимірного масиву типу double[,];
        public MyMatrix(double[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            matrix = new double[rows, cols];
            Array.Copy(array, matrix, array.Length);
        }

        //з «зубчастого» масиву double-ів, якщо він фактично прямокутний;
        public MyMatrix(double[][] jaggedArray)
        {
            int rows = jaggedArray.Length;
            int cols = jaggedArray[0].Length;

            for (int i = 1; i < rows; i++)
            {
                if (jaggedArray[i].Length != cols)
                    throw new ArgumentException("Зубчастий масив не є прямокутним.");
            }

            matrix = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = jaggedArray[i][j];
                }
            }
        }

        //з масиву рядків, якщо фактично ці рядки містять записані через пробіли та/або
        //числа, а кількість цих чисел у різних рядках однакова.
        public MyMatrix(string[] lines)
        {
            int rows = lines.Length;
            string[] firstRowElements = lines[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int cols = firstRowElements.Length;

            matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] elements = lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (elements.Length != cols)
                    throw new ArgumentException("Ряди мають різну довжину.");

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = double.Parse(elements[j]);
                }
            }
        }

        // з рядка, що містить як пробіли та/або табуляції
        public MyMatrix(string data)
        {
            string[] lines = data.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = lines.Length;
            string[] firstRowElements = lines[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int cols = firstRowElements.Length;

            matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] elements = lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (elements.Length != cols)
                    throw new ArgumentException("Ряди мають різну довжину.");

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = double.Parse(elements[j]);
                }
            }
        }

        // властивості 

        //public int Height => matrix.GetLength(0);
        //public int Width => matrix.GetLength(1);
        public int Height 
        { 
            get 
            { 
                return matrix.GetLength(0); 
            } 
        }
        public int Width 
        { 
            get 
            {
                return matrix.GetLength(1); 
            }
        }

        // Java-style getters

        //public int getHeight() => Height;
        //public int getWidth() => Width;
        public int getHeight()
        { return matrix.GetLength(0); }
        public int getWidth()
        { return matrix.GetLength(1); }

        //індексатор 
        public double this[int row, int col]
        {
            get
            {
                if (row >= Height || col >= Width || row < 0 || col < 0)
                    throw new IndexOutOfRangeException();
                return matrix[row, col];
            }
            set
            {
                if (row >= Height || col >= Width || row < 0 || col < 0)
                    throw new IndexOutOfRangeException();
                matrix[row, col] = value;
            }
        }

        // Getter and setter

        public double GetElement(int row, int col) => this.matrix[row, col];
        public void SetElement(int row, int col, double value) => this.matrix[row, col] = value;
        //public double GetElement(int row, int col)
        //{
        //    if (row >= Height || col >= Width)
        //        throw new IndexOutOfRangeException();
        //    return this.matrix[row, col]; // або matrix[row, col], або просто  this[row, col];
        //}

        //public void SetElement(int row, int col, double value)
        //{
        //    if (row >= Height || col >= Width)
        //        throw new IndexOutOfRangeException();
        //    this.matrix[row, col] = value; // або matrix[row, col] = value, або просто  this[row, col] = value;
        //}

        // ToString override
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    result += matrix[i, j] + "\t";
                }
                result = result.TrimEnd() + Environment.NewLine;
            }
            return result;
        }
    }
}
