namespace Odev_15_02_2023
{
    internal class Program
    {
        //kullanıcı klavyeden bir sayı girsin ardından bu sayının kaçıncı kuvvetinin bulma istediğini girsin.uygulama bu işlemin sonucunu bulsun.(math.pow yok)
        static void Main(string[] args)
        {
            Console.WriteLine("taban sayi gir: ");
            int taban = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("kaçıncı kuvveti girmek istersin?");
            int us = Convert.ToInt32(Console.ReadLine());

            int sonuc = 1;

            for (int i = 1; i <= us; i++)
            {
                sonuc = sonuc * taban;
            }

            Console.WriteLine("Tabanı {0} ve kuvveti {1} olan sayının değeri = {2}", taban, us, sonuc);

        }
    }
}