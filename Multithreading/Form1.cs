using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    //private void btnRun_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int rowsA = int.Parse(txtRowsA.Text);
    //        int columnsA = int.Parse(txtColumnsA.Text);
    //        int columnsB = int.Parse(txtColumnsB.Text);

    //        int[,] matrixA = MatrixMultiplier.GenerateRandomMatrix(rowsA, columnsA);
    //        int[,] matrixB = MatrixMultiplier.GenerateRandomMatrix(columnsA, columnsB);

    //        // "Sekwencyjne" obliczenia = Parallel z 1 w¹tkiem
    //        long sequentialTime = MatrixMultiplier.MeasureTime(() =>
    //        {
    //            MatrixMultiplier.MultiplyParallel(matrixA, matrixB, 1); // MaxDegreeOfParallelism = 1
    //        });
    //        lblSequentialTime.Text = $"Czas sekwencyjny (Parallel x1): {sequentialTime} ms";

    //        // W³aœciwe równoleg³e (np. 4 w¹tki)
    //        int threadCount = int.Parse(txtThreads.Text);
    //        long parallelTime = MatrixMultiplier.MeasureTime(() =>
    //        {
    //            MatrixMultiplier.MultiplyParallel(matrixA, matrixB, threadCount);
    //        });
    //        lblParallelTime.Text = $"Czas równoleg³y (Parallel x{threadCount}): {parallelTime} ms";

    //        // Równoleg³e niskopoziomowe (Thread)
    //        long threadTime = MatrixMultiplier.MeasureTime(() =>
    //        {
    //            MatrixMultiplier.MultiplyWithThreads(matrixA, matrixB, rowsA, columnsA, columnsB, threadCount);
    //        });
    //        lblThreadTime.Text = $"Czas równoleg³y (Thread): {threadTime} ms";

    //        // Przyspieszenia
    //        double speedupParallel = (double)sequentialTime / parallelTime;
    //        double speedupThread = (double)sequentialTime / threadTime;
    //        lblSpeedup.Text = $"Przysp. Parallel: {speedupParallel:F2}, Thread: {speedupThread:F2}";
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show($"Wyst¹pi³ b³¹d: {ex.Message}");
    //    }
    //}
    private void btnRun_Click(object sender, EventArgs e)
    {
        try
        {
            txtResults.Clear(); // Czyœcimy pole wyników na start
            int threadCount = int.Parse(txtThreads.Text);
            int[] sizes = { 100, 200, 400, 800, 1000, 2000 };

            foreach (int size in sizes)
            {
                long totalParallelTime = 0;
                long totalThreadTime = 0;

                for (int attempt = 0; attempt < 5; attempt++)
                {
                    int[,] matrixA = MatrixMultiplier.GenerateRandomMatrix(size, size);
                    int[,] matrixB = MatrixMultiplier.GenerateRandomMatrix(size, size);

                    long parallelTime = MatrixMultiplier.MeasureTime(() =>
                    {
                        MatrixMultiplier.MultiplyParallel(matrixA, matrixB, threadCount);
                    });

                    long threadTime = MatrixMultiplier.MeasureTime(() =>
                    {
                        MatrixMultiplier.MultiplyWithThreads(matrixA, matrixB, size, size, size, threadCount);
                    });

                    totalParallelTime += parallelTime;
                    totalThreadTime += threadTime;
                }

                long avgParallel = totalParallelTime / 5;
                long avgThread = totalThreadTime / 5;

                // Dopisujemy wyniki na bie¿¹co
                txtResults.AppendText($"Macierze {size}\r ");
                txtResults.AppendText($"{avgParallel}\r ");
                txtResults.AppendText($"{avgThread} \r\n\r\n");

                // Wymuszamy odœwie¿enie GUI po ka¿dym rozmiarze
                Application.DoEvents();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Wyst¹pi³ b³¹d: {ex.Message}");
        }
    }






    private void txtColumnsB_TextChanged(object sender, EventArgs e)
    {

    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void lblThreadTime_Click(object sender, EventArgs e)
    {

    }

    private void txtResults_TextChanged(object sender, EventArgs e)
    {

    }
}
