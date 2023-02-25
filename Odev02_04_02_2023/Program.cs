namespace Odev02_04_02_2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("vize notunu giriniz: ");
            int vize= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("final notunu giriniz: ");
            int final = Convert.ToInt32(Console.ReadLine());

            double basari = (vize * 0.4) + (final * 0.6);
            if (vize<0|| vize>100|| final<0|| final>100)
            {
                Console.WriteLine("Notlarda hata var tekrar girin");
                Console.WriteLine("vize notunu giriniz: ");
              vize = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("final notunu giriniz: ");
              final = Convert.ToInt32(Console.ReadLine());
                basari = (vize * 0.4) + (final * 0.6);
            }
            
            if(0<=vize||vize <=100 || 0<=final|| final<=100)
            {
                Console.WriteLine(basari);
            }
            Console.ReadLine();
        }
    }
}