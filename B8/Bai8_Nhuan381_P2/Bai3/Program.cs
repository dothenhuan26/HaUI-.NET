namespace Bai3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the money: ");
            int money = int.Parse(Console.ReadLine());
            Action<int> bonus = printf;
            bonus?.Invoke(money);
        }

        public static void printf(int money)
        {
            Console.WriteLine("Bonus: " + (double)money * ((money < 1000 ? 0 : (money > 3000) ? 0.1 : 0.05)));
        }

    }
}