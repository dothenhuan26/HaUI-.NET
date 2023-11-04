namespace CPFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string source = @"D:\Personal\Documents\University\.NET\B2\source\test.txt";
            string target = @"D:\Personal\Documents\University\.NET\B2\target\res.txt";
            string target2 = @"D:\Personal\Documents\University\.NET\B2\target\res2.txt";
            try
            {
                File.Copy(source, target, true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            StreamReader sr = new StreamReader(source);
            StreamWriter sw = new StreamWriter(target2, true);

            try
            {
                string ln;
                while ((ln = sr.ReadLine()) != null)
                {
                    sw.WriteLine(ln);
                }

            } catch (Exception e) { 
                Console.WriteLine(e.ToString());
            }
            sr.Close();
            sw.Close();
            Console.WriteLine("Ket thuc chuong trinh");

        }
    }
}