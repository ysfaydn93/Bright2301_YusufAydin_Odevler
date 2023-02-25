namespace Odev01_04__02_2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.sayiyi giriniz: ");
            int sayi1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("2.sayiyi giriniz: ");
            int sayi2 = Convert.ToInt32(Console.ReadLine());

            decimal ortalama=(sayi1+sayi2)/2;

            if (ortalama>=50)
            {
                Console.WriteLine("geçti");
            }
            else
            {
                Console.WriteLine("kaldı");
            }

        }
    }
}