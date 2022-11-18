/* Lab_07_2_Recursive.cs
 * Якубовський Владислав
 * Лабораторна робота № 7.2
 * Опрацювання багатовимірних масивів ітераційним і рекурсивним способами (рекурсивний спосіб)
 * Варіант 24 */
namespace AP_Lab_07_2_Recursive
{
    public class Lab_07_2_Recursive
    {
        readonly static Random random = new();

        public static void GetIndexOfMaxFromMinInEvenCols(int[,] matrix, int rows, int cols, ref int maxFromMinsInEvenCols, ref int minInEvenCol, ref int firstIndexToReturn,
            ref int secondIndexToReturn, int firstIndexOfComparable = 0, int secondIndexOfComparable = 0, int jj = 0, int ii = 0)
        {
            if (jj < cols)
            {
                if (ii == 0)
                    minInEvenCol = matrix[0, jj];

                if (ii < rows)
                {
                    if (matrix[ii, jj] <= minInEvenCol)
                    {
                        minInEvenCol = matrix[ii, jj];

                        firstIndexOfComparable = ii; secondIndexOfComparable = jj;
                    }

                    GetIndexOfMaxFromMinInEvenCols(matrix, rows, cols, ref maxFromMinsInEvenCols, ref minInEvenCol, ref firstIndexToReturn, ref secondIndexToReturn,
                        firstIndexOfComparable, secondIndexOfComparable, jj, ++ii);
                }

                if (minInEvenCol > maxFromMinsInEvenCols)
                {
                    maxFromMinsInEvenCols = matrix[firstIndexOfComparable, secondIndexOfComparable];

                    firstIndexToReturn = firstIndexOfComparable;
                    secondIndexToReturn = secondIndexOfComparable;
                }

                GetIndexOfMaxFromMinInEvenCols(matrix, rows, cols, ref maxFromMinsInEvenCols, ref minInEvenCol, ref firstIndexToReturn, ref secondIndexToReturn,
                    firstIndexOfComparable, secondIndexOfComparable, jj += 2, 0);
            }
        }

        public static void GetIndexOfMinFromMaxInOddCols(int[,] matrix, int rows, int cols, ref int minFromMaxInOddCols, ref int maxInOddCol, ref int firstIndexToReturn,
            ref int secondIndexToReturn, int firstIndexOfComparable = 0, int secondIndexOfComparable = 0, int jj = 1, int ii = 0)
        {
            if (jj < cols)
            {
                if (ii == 0)
                    maxInOddCol = matrix[0, jj];

                if (ii < rows)
                {
                    if (matrix[ii, jj] >= maxInOddCol)
                    {
                        maxInOddCol = matrix[ii, jj];

                        firstIndexOfComparable = ii; secondIndexOfComparable = jj;
                    }

                    GetIndexOfMinFromMaxInOddCols(matrix, rows, cols, ref minFromMaxInOddCols, ref maxInOddCol, ref firstIndexToReturn, ref secondIndexToReturn,
                        firstIndexOfComparable, secondIndexOfComparable, jj, ++ii);
                }

                if (maxInOddCol < minFromMaxInOddCols)
                {
                    minFromMaxInOddCols = matrix[firstIndexOfComparable, secondIndexOfComparable];

                    firstIndexToReturn = firstIndexOfComparable;
                    secondIndexToReturn = secondIndexOfComparable;
                }

                GetIndexOfMinFromMaxInOddCols(matrix, rows, cols, ref minFromMaxInOddCols, ref maxInOddCol, ref firstIndexToReturn, ref secondIndexToReturn,
                    firstIndexOfComparable, secondIndexOfComparable, jj += 2, 0);
            }
        }

        static void ChangeElements(ref int[,] matrix, int firstIndexOfFirstElement, int secondIndexOfFirstElement,
            int firstIndexOfSecondElement, int secondIndexOfSecondElement)
        {
            (matrix[firstIndexOfFirstElement, secondIndexOfFirstElement], matrix[firstIndexOfSecondElement, secondIndexOfSecondElement]) =
                (matrix[firstIndexOfSecondElement, secondIndexOfSecondElement], matrix[firstIndexOfFirstElement, secondIndexOfFirstElement]);
        }            

        static void GenerateMatrix(ref int[,] matrix, int rows, int cols, int minLimit, int maxLimit, int ii = 0, int jj = 0)
        {
            if (ii < rows)
            {
                if (jj < cols)
                {
                    matrix[ii, jj] = random.Next(minLimit, maxLimit);
                    GenerateMatrix(ref matrix, rows, cols, minLimit, maxLimit, ii, ++jj);
                }

                else GenerateMatrix(ref matrix, rows, cols, minLimit, maxLimit, ++ii, 0);
            }
        }

        static void DisplayMatrix(int[,] matrix, int rows, int cols, int ii = 0, int jj = 0)
        {
            if (ii < rows)
            {
                if (jj < cols)
                {
                    Console.Write((jj == 0 ? "||" : "") + $" {matrix[ii, jj]} ".PadRight(6) + (jj == cols - 1 ? "||\n" : ""));

                    DisplayMatrix(matrix, rows, cols, ii, ++jj);
                }

                else DisplayMatrix(matrix, rows, cols, ++ii, 0);
            }
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            Console.Write("Введіть розмір матриці (через кому \"k\", \"n\"): ");

            string[] varArray = Console.ReadLine()!.Split(';');

            int k = int.Parse(varArray[0]), n = int.Parse(varArray[1]);

            Console.Write("Введіть найменші та найбільші можливі значення масиву через крапку з комою: ");

            varArray = Console.ReadLine()!.Split(';');

            int minLimit = int.Parse(varArray[0]), maxLimit = int.Parse(varArray[1]);

            int[,] matrix = new int[k, n];
            
            GenerateMatrix(ref matrix, k, n, minLimit, maxLimit);

            Console.WriteLine("Згенерована матриця: "); DisplayMatrix(matrix, k, n);

            int maxFromMinsInEvenCols = minLimit - 2, minInEvenCol = 0, firstIndexOfMaxFromMinInEvenCols = 0, secondIndexOfMaxFromMinInEvenCols = 0,
                minFromMaxInOddCols = maxLimit + 2, maxInOddCol = 0, firstIndexOfMinFromMaxInOddCols = 0, secondIndexOfMinFromMaxInOddCols = 0;

            GetIndexOfMaxFromMinInEvenCols(matrix, k, n, ref maxFromMinsInEvenCols, ref minInEvenCol, ref firstIndexOfMaxFromMinInEvenCols, ref secondIndexOfMaxFromMinInEvenCols);

            GetIndexOfMinFromMaxInOddCols(matrix, k, n, ref minFromMaxInOddCols, ref maxInOddCol, ref firstIndexOfMinFromMaxInOddCols, ref secondIndexOfMinFromMaxInOddCols);

            Console.WriteLine($"\nНайбільше серед мінімальних: [{firstIndexOfMaxFromMinInEvenCols}], [{secondIndexOfMaxFromMinInEvenCols}]: {maxFromMinsInEvenCols}\n" +
                $"Найменше серед максимальних: [{firstIndexOfMinFromMaxInOddCols}], [{secondIndexOfMinFromMaxInOddCols}]: {minFromMaxInOddCols}");

            ChangeElements(ref matrix, firstIndexOfMinFromMaxInOddCols, secondIndexOfMinFromMaxInOddCols, firstIndexOfMaxFromMinInEvenCols, secondIndexOfMaxFromMinInEvenCols);

            Console.WriteLine("\nОбчислена матриця: "); DisplayMatrix(matrix, k, n);
        }
    }
}
