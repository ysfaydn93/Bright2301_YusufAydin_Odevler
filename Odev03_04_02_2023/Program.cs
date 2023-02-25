namespace Odev03_04_02_2023
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("sayi giriniz: ");
            int sayi = Convert.ToInt32(Console.ReadLine());
            double kare=0;
            double kup=0;
            Console.WriteLine("lütfen işlem türünü seçiniz:");
            Console.WriteLine("kare=1,kup=2");
            int islem = Int32.Parse(Console.ReadLine());


            switch (islem)
            {
                case 1: Console.WriteLine(sayi*sayi); break; 
                case 2: Console.WriteLine(sayi * sayi * sayi);break;
                default: Console.WriteLine("Hata böyle bir işlem bulunamadı"); break;
            }
            Console.ReadLine();
        }
    }
}