using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

public class MatrixMultiplier
{
    private static Random random = new Random();
    private static int[,] resultMatrix;
    private static readonly object locker = new object();

    // Funkcja do generowania macierzy o zadanych wymiarach
    public static int[,] GenerateRandomMatrix(int rows, int columns)
    {
        int[,] matrix = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = random.Next(1, 10); // Losowe liczby z zakresu 1-9
            }
        }
        return matrix;
    }

   public static int[,] MultiplyParallel(int[,] matrixA, int[,] matrixB, int maxThreads)
{
    int rowsA = matrixA.GetLength(0);
    int columnsA = matrixA.GetLength(1);
    int columnsB = matrixB.GetLength(1);
    int[,] result = new int[rowsA, columnsB];

    // Określamy liczbę wątków, ograniczając ją do liczby rdzeni lub maxThreads
    int tasksCount = Math.Min(rowsA, maxThreads); // Ograniczamy liczbę wątków do liczby rdzeni lub wierszy

    // Ustawienie opcji równoległego przetwarzania z odpowiednią liczbą wątków
    ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = tasksCount };

    // Podział na wiersze, aby każdy wątek przetwarzał inny wiersz
    Parallel.For(0, tasksCount, options, i =>
    {
        int rowStart = i * (rowsA / tasksCount);
        int rowEnd = (i == tasksCount - 1) ? rowsA : (i + 1) * (rowsA / tasksCount); // Gwarancja, że ostatni wątek obejmuje wszystkie pozostałe wiersze

        // Każdy wątek oblicza swój zakres wierszy
        for (int row = rowStart; row < rowEnd; row++)
        {
            for (int col = 0; col < columnsB; col++)
            {
                int sum = 0;
                for (int k = 0; k < columnsA; k++)
                {
                    sum += matrixA[row, k] * matrixB[k, col];
                }
                result[row, col] = sum;
            }
        }
    });

    return result;
}


    public static void MultiplyWithThreads(int[,] matrixA, int[,] matrixB, int rowsA, int columnsA, int columnsB, int Threads)
    {
        resultMatrix = new int[rowsA, columnsB];

        // Określamy liczbę wątków

        int tasksCount = Threads; 
        Thread[] threads = new Thread[tasksCount];

        int rowsPerThread = rowsA / tasksCount; 
        int remainingRows = rowsA % tasksCount; 

        int rowStart = 0; 

       
        for (int i = 0; i < tasksCount; i++)
        {
            
            int rowsToProcess = rowsPerThread + (i < remainingRows ? 1 : 0);

           
            int currentRowStart = rowStart;
            int currentRowEnd = rowStart + rowsToProcess;

            threads[i] = new Thread(() =>
                CalculateRows(matrixA, matrixB, currentRowStart, currentRowEnd, columnsA, columnsB)
            );
            threads[i].Start();

            
            rowStart = currentRowEnd;
        }

       
        foreach (Thread t in threads)
        {
            t.Join();
        }
    }

    // Funkcja obliczająca segment wierszy macierzy
    private static void CalculateRows(int[,] matrixA, int[,] matrixB, int startRow, int endRow, int columnsA, int columnsB)
    {
        for (int i = startRow; i < endRow; i++)
        {
            for (int j = 0; j < columnsB; j++)
            {
                int sum = 0;
                for (int k = 0; k < columnsA; k++)
                {
                    sum += matrixA[i, k] * matrixB[k, j];
                }
                resultMatrix[i, j] = sum;
            }
        }
    }




    // Pomiar czasu wykonywania zadania
    public static long MeasureTime(Action action)
    {
        var stopwatch = Stopwatch.StartNew();
        action();
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    // Funkcja do wyświetlania wyników
    public static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
