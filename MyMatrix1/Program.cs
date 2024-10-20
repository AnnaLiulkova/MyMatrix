using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMatrix1
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Створення матриць за допомогою різних конструкторів

            // 1. Створення матриці з двовимірного масиву
            double[,] array1 = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
            MyMatrix matrix1 = new MyMatrix(array1);
            Console.WriteLine("Matrix1 (from double[,]):");
            Console.WriteLine(matrix1);

            // 2. Створення матриці із зубчастого масиву
            double[][] jaggedArray = {
            new double[] { 1, 2, 3 },
            new double[] { 4, 5, 6 },
            new double[] { 7, 8, 9 }
        };
            MyMatrix matrix2 = new MyMatrix(jaggedArray);
            Console.WriteLine("Matrix2 (from jagged array):");
            Console.WriteLine(matrix2);

            // 3. Створення матриці з масиву рядків
            string[] lines = {
            "1 2 3",
            "4 5 6",
            "7 8 9"
        };
            MyMatrix matrix3 = new MyMatrix(lines);
            Console.WriteLine("Matrix3 (from string array):");
            Console.WriteLine(matrix3);

            // 4. Створення матриці з рядка
            string matrixString = "1 2 3\n4 5 6\n7 8 9";
            MyMatrix matrix4 = new MyMatrix(matrixString);
            Console.WriteLine("Matrix4 (from string):");
            Console.WriteLine(matrix4);

            // Використання властивостей Height та Width
            Console.WriteLine($"Matrix1 Height: {matrix1.Height}, Width: {matrix1.Width}");

            // Використання індексаторів для зміни елемента
            matrix1[0, 0] = 10;
            Console.WriteLine("Matrix1 after changing element [0,0] to 10:");
            Console.WriteLine(matrix1);

            // Використання getter-а та setter-а для окремого елемента
            double element = matrix1.GetElement(0, 1);
            Console.WriteLine($"Element at (0,1) in Matrix1: {element}");
            matrix1.SetElement(0, 1, 20);
            Console.WriteLine("Matrix1 after setting element [0,1] to 20:");
            Console.WriteLine(matrix1);

            // Додавання матриць
            try
            {
                MyMatrix resultAdd = matrix1 + matrix2;
                Console.WriteLine("Result of Matrix1 + Matrix2:");
                Console.WriteLine(resultAdd);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Множення матриць
            try
            {
                MyMatrix resultMul = matrix1 * matrix2;
                Console.WriteLine("Result of Matrix1 * Matrix2:");
                Console.WriteLine(resultMul);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Транспонування матриці
            Console.WriteLine("Matrix1 before transposing:");
            Console.WriteLine(matrix1);

            matrix1.TransponeMe();
            Console.WriteLine("Matrix1 after transposing:");
            Console.WriteLine(matrix1);

            // Отримання транспонованої копії матриці
            MyMatrix transposedCopy = matrix1.GetTransponedCopy();
            Console.WriteLine("Transposed copy of Matrix1:");
            Console.WriteLine(transposedCopy);
        }
    }
}
