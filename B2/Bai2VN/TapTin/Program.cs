namespace TapTin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string matran = @"D:\Personal\Documents\University\.NET\B2\Bai2VN\TapTin\matran.txt";
            int row = 0, col = 0;
            int[,] matrix;
            int total = 0;

            try
            {
                StreamReader sr = new StreamReader(matran);
                Console.WriteLine("Nhap vao so hang: ");
                row = int.Parse(sr.ReadLine());
                Console.WriteLine("Nhap vao so cot: ");
                col = int.Parse(sr.ReadLine());
                matrix = new int[row, col];
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        matrix[i, j] = int.Parse(sr.ReadLine());
                        total += matrix[i, j];
                    }
                }
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.Write(matrix[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
                sr.Close();
                StreamWriter sw = new StreamWriter(matran, true);
                sw.WriteLine(total);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



        }
    }
}