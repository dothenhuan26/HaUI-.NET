namespace BaiTap1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int d, r, cv, dt;
            Console.WriteLine("Nhap vao chieu dai: ");
            d = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap vao chieu rong: ");
            r = int.Parse(Console.ReadLine());
            result(d, r, out cv, out dt);
            Console.WriteLine($"Chu vi la: {cv}, Dien tich la: {dt}");


        }

        public static void result(int d, int r, out int cv, out int dt)
        {
            cv = (d + r) * 2;
            dt = d * r;
        }

    }
}