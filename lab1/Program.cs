using System;
using System.Collections.Immutable;
using System.Data.Common;
using System.Linq;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("--ВАРИАНТ 1--");
     // ------- ЧАСТЬ 1 -------
        Console.WriteLine("ЧАСТЬ 1");
        
        int N = 10;
        int [] arr = new int[N];
        Random random = new Random();

        // заполнение массива рандомными значениями
        for (int i = 0; i < N; i++)
        {
            arr[i] = random.Next(-10, 10);
        }
        Print(arr);

        Console.WriteLine($"Сумма положительных элементов массива: {SumOfPositive(arr)}");
        Console.WriteLine($"Произведение: {ResBetweenMaxAndMin2(arr)}");
        Array.Sort(arr);
        Array.Reverse(arr);
        Console.WriteLine("Отсортированный по убыванию массив:");
        Print(arr);

        Console.WriteLine();
     // -----------------------


     // ------- ЧАСТЬ 2 -------
        Console.WriteLine("ЧАСТЬ 2");

        // создание матрицы
        int cols = 5; // столбцы
        int rows = 3; // строки
        int[,] matrix = new int[rows, cols];

        // заполнение матрицы рандомными значениями
        MatrixRandom(matrix, rows, cols);
        PrintMatrix(matrix);

        // подсчет количества столбцов без нулевых элементов
        Console.WriteLine($"Количество столбцов матрицы, не содержащих нулей: {NonZeroCols(matrix, rows, cols)}");

        // расставление строк в соответствии с ростом их характеристик
        // характеристика строки - сумма ее положительных четных элементов
        MixMatrixByCharacters(matrix, rows, cols);

     // -----------------------
    }


    // расставление строк в соответствии с ростом их характеристик
    public static void MixMatrixByCharacters(int[,] matrix, int rows, int cols)
    {
        // создание массива с характеристиками строк по порядку
        int[] character = new int[rows];
        for (int i = 0; i < rows; i++)
        {
            character[i] = 0;
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] > 0 && matrix[i, j] % 2 == 0)
                {
                    character[i] += matrix[i, j];
                }
            }
        }
        Console.WriteLine("Характеристики строк:");
        Print(character);

        // создание массива, где значение элемента массива соответствует номеру строки матрицы.
        // по сути это массив, где изображен порядок строк в соответствии с их характеристикой
        var sortedRows = Enumerable.Range(0, rows).OrderBy(i => character[i]).ToArray();
        Console.WriteLine("Порядок строк в соответствии с их характеристикой:");
        Print(sortedRows);

        // расстравление строк матрицы по порядку
        for (int i = 0; i < rows; i++)
        {
            while (sortedRows[i] != i)
            {
                SwapRows(matrix, i, sortedRows[i]);
                SwapValues(sortedRows, i, sortedRows[i]);
            }
        }
        Console.WriteLine("Матрица, где строки расположены в соответствии с ростом характеристик:");
        PrintMatrix(matrix);
        Console.WriteLine("Текущий порядок строк:");
        Print(sortedRows);
    }
    
    
    // заполнение матрицы рандомными значениями
    public static void MatrixRandom(int[,] matrix, int rows, int cols)
    {
        Random rnd = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rnd.Next(-10, 10);
            }
        }
    }


    // подсчет количества столбцов без нулевых элементов
    public static int NonZeroCols(int[,] matrix, int rows, int cols)
    {
        int nonZeroCols = cols;
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                if (matrix[j, i] == 0)
                {
                    nonZeroCols--;
                    break;
                }

            }
        }

        return nonZeroCols;
    }
    
    
    // метод меняет местами значения элементов массива
    private static void SwapValues(int[] arr, int index1, int index2)
    {
        int element = arr[index1];
        arr[index1] = arr[index2];
        arr[index2] = element;
    }

    
    // метод меняет местами строки матрицы
    private static void SwapRows(int[,] matrix, int one, int two)
    {
        int element;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            element = matrix[one, i];
            matrix[one, i] = matrix[two, i];
            matrix[two, i] = element;
        }
    }


    //расчет произведения между максимальным по модулю и минимальным по модулю элементами массива
    public static int ResBetweenMaxAndMin2(int[] arr)
    {

        int index_min = 0;
        int index_max = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            if (Math.Abs(arr[index_min]) > Math.Abs(arr[i]))
                index_min = i;
            if (Math.Abs(arr[index_max]) < Math.Abs(arr[i]))
                index_max = i;
        }
        Console.WriteLine("Минимальное по модулю: " + arr[index_min] + " в позиции " + index_min);
        Console.WriteLine("Максимальное по модулю: " + arr[index_max] + " в позиции " + index_max);

        if (index_min > index_max)
        {
            int i = index_min;
            index_min = index_max;
            index_max = i;
        }

        int res = 1;
        int ii = index_min;
        while (++ii < index_max)
        {
            //Console.WriteLine("Произведение " + index_min);
            res *= arr[ii];
        }

        if (index_min + 1 == index_max)
            return 0;
        else
            return res;
    }


    //расчет суммы положительных элементов массива
    public static int SumOfPositive(int[] arr)
    {
        int sum = 0;
        for (int i = 0; i < arr.Length; i++) 
        {
            if (arr[i] > 0)
                sum += arr[i];        
        }
        return sum;
    }


    //вывод массива
    private static void Print(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }


    // вывод матрицы
    private static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0;  j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }



}