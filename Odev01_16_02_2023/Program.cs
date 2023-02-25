namespace Odev01_16_02_2023
{ 
    //1) 1 İLE 100 arasındaki sayılardan hangilerinin kullanıcının gireceği bir sayıya tam olarak bölünebildiğini
    //yazdıran
    internal class Program
    {
        static void Main(string[] args)
        { // for 

            //Console.WriteLine("sayi giriniz: ");
            //int sayi=Convert.ToInt32(Console.ReadLine());
            //int sayac = 0;
            //for (int i = 1; i <= 100; i++)
            //{
            //    if (i % sayi == 0)
            //    {
            //        Console.WriteLine(i);
            //        sayac++;
            //    }
            //}
            //Console.WriteLine($"Toplam kaç sayının bölünebildiği {sayac}");
            //Console.ReadKey();

            // while

            // Console.WriteLine("sayi giriniz: ");
            // int sayi = Convert.ToInt32(Console.ReadLine());
            // int sayac = 0;
            //int i = 1;
            // while (i <= 100)
            // {
            //     if (i % sayi == 0)
            //     {
            //         Console.WriteLine(i);
            //         sayac++;
            //     }
            //     i++;
            // }
            // Console.WriteLine($"Toplam kaç sayının bölünebildiği {sayac}");
            // Console.ReadKey();

            //do-while 
            //deneme

            Console.WriteLine("sayi giriniz: ");
            int sayi = Convert.ToInt32(Console.ReadLine());
            int sayac = 0;
            int i = 1;

            do
            {
                if (i % sayi == 0)
                {
                    Console.WriteLine(i);
                    sayac++;
                }
                i++;
            }
            while (i <= 100);
            Console.WriteLine($"Toplam kaç sayının bölünebildiği {sayac}");
            Console.ReadKey();
        }
    }
}