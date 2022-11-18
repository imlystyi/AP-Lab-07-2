/* Lab_07_2_Iterative.cs
 * Якубовський Владислав
 * Лабораторна робота № 7.2
 * Опрацювання багатовимірних масивів ітераційним і рекурсивним способами (ітераційний спосіб)
 * Варіант 24 */
namespace AP_Lab_07_2_Iterative
{
    public class Lab_07_2_Iterative
    {
        readonly static Random random = new();

        public static void GetIndexOfMaxFromMinInEvenCols(int[,] matrix, int minLimit, out int firstIndexToReturn, out int secondIndexToReturn, out int maxFromMinsInEvenCols)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1), minInEvenCol, firstIndexOfComparable = 0, secondIndexOfComparable = 0;
            maxFromMinsInEvenCols = minLimit - 2; firstIndexToReturn = 0; secondIndexToReturn = 0;

            for (int jj = 0; jj < cols; jj += 2)
            {
                minInEvenCol = matrix[0, jj];

                for (int ii = 0; ii < rows; ii++)
                {
                    if (matrix[ii, jj] <= minInEvenCol)
                    {
                        minInEvenCol = matrix[ii, jj];

                        firstIndexOfComparable = ii; secondIndexOfComparable = jj;
                    }                    
                }

                if (minInEvenCol > maxFromMinsInEvenCols)
                {
                    maxFromMinsInEvenCols = matrix[firstIndexOfComparable, secondIndexOfComparable];

                    firstIndexToReturn = firstIndexOfComparable;
                    secondIndexToReturn = secondIndexOfComparable;
                }
            }
        }

        public static void GetIndexOfMinFromMaxInOddCols(int[,] matrix, int maxLimit, out int firstIndexToReturn, out int secondIndexToReturn, out int minFromMaxInOddCols)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1), maxInOddCol, firstIndexOfComparable = 0, secondIndexOfComparable = 0;
            minFromMaxInOddCols = maxLimit + 2; firstIndexToReturn = 0; secondIndexToReturn = 0;

            for (int jj = 1; jj < cols; jj += 2)
            {
                maxInOddCol = matrix[0, jj];

                for (int ii = 0; ii < rows; ii++)
                {
                    if (matrix[ii, jj] >= maxInOddCol)
                    {
                        maxInOddCol = matrix[ii, jj];

                        firstIndexOfComparable = ii; secondIndexOfComparable = jj;
                    }
                }

                if (maxInOddCol < minFromMaxInOddCols)
                {
                    minFromMaxInOddCols = matrix[firstIndexOfComparable, secondIndexOfComparable];

                    firstIndexToReturn = firstIndexOfComparable;
                    secondIndexToReturn = secondIndexOfComparable;
                }
            }
        }

        static void ChangeElements(ref int[,] matrix, int firstIndexOfFirstElement, int secondIndexOfFirstElement, int firstIndexOfSecondElement, int secondIndexOfSecondElement)
        {
            (matrix[firstIndexOfFirstElement, secondIndexOfFirstElement], matrix[firstIndexOfSecondElement, secondIndexOfSecondElement]) =
                (matrix[firstIndexOfSecondElement, secondIndexOfSecondElement], matrix[firstIndexOfFirstElement, secondIndexOfFirstElement]);
        }            
        
        static int[,] GenerateMatrix(int rows, int cols, int minLimit, int maxLimit)
        {
            int[,] generatedMatrix = new int[rows, cols];

            for (int ii = 0; ii < rows; ii++)
                for (int jj = 0; jj < cols; jj++)
                    generatedMatrix[ii, jj] = random.Next(minLimit, maxLimit);

            return generatedMatrix;
        }

        static void DisplayMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);

            for (int ii = 0; ii < rows; ii++)
                for (int jj = 0; jj < cols; jj++)
                    Console.Write((jj == 0 ? "||" : "") + $" {matrix[ii, jj]} ".PadRight(6) + (jj == cols - 1 ? "||\n" : ""));
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

            int[,] matrix = GenerateMatrix(k, n, minLimit, maxLimit);

            Console.WriteLine("Згенерована матриця: "); DisplayMatrix(matrix);

            GetIndexOfMaxFromMinInEvenCols(matrix, minLimit, out int firstIndexOfMaxFromMinInEvenCols, out int secondIndexOfMaxFromMinInEvenCols, out int maxFromMinInEvenCols);
            GetIndexOfMinFromMaxInOddCols(matrix, maxLimit, out int firstIndexOfMinFromMaxInOddCols, out int secondIndexOfMinFromMaxInOddCols, out int minFromMaxInOddCols);            

            Console.WriteLine($"\nНайбільше серед мінімальних: [{firstIndexOfMaxFromMinInEvenCols}], [{secondIndexOfMaxFromMinInEvenCols}]: {maxFromMinInEvenCols}\n" +
                $"Найменше серед максимальних: [{firstIndexOfMinFromMaxInOddCols}], [{secondIndexOfMinFromMaxInOddCols}]: {minFromMaxInOddCols}");

            ChangeElements(ref matrix, firstIndexOfMaxFromMinInEvenCols, secondIndexOfMaxFromMinInEvenCols, firstIndexOfMinFromMaxInOddCols, secondIndexOfMinFromMaxInOddCols);

            Console.WriteLine("\nОбчислена матриця: "); DisplayMatrix(matrix);
        }
    }
}
