namespace SwinAdventure
{
    public class Program
    {
        public static string ToBinary(int n)
        {
            if (n < 2) return n.ToString();

            var divisor = n / 2;
            var remainder = n % 2;

            return ToBinary(divisor) + remainder;
        }

        public static void Main(string[] args)
        {
            Int16 signedInt = -128;
            Console.WriteLine(ToBinary(signedInt));
        }
    }
}