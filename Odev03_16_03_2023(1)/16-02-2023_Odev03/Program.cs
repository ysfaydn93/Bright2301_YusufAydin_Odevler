namespace _16_02_2023_Odev03
{
    internal class Program
    {
        //    3) kalvyeden girilen herhangi bir ifadeyi ilk harfinden başlayıp sırasıyla  ve satır satır birer harf arttırarak alt alta yzdırır
        //B
        //br
        //BRİ
        //BRİGH
        //BRİGHT  
        static void Main(string[] args)
        {
            // Console.WriteLine("kelime girin:");
            // string kelime=Console.ReadLine();
            //string mesaj = "";   
            // for (int i = 0; i < kelime.Length; i++)
            // {
            //     mesaj+= kelime[i];
            //     Console.WriteLine(mesaj);

            // }

            // Console.WriteLine("kelime girin:");
            // string kelime=Console.ReadLine();
            // string mesaj = "";
            //int i = 0;
            // while (i<kelime.Length)
            // {
            //     mesaj += kelime[i];
            //     Console.WriteLine(mesaj);
            //     i++;
            // }
            Console.WriteLine("kelime girin:");
            string kelime = Console.ReadLine();
            string mesaj = "";
            int i = 0;
            do
            {
                mesaj += kelime[i];
                Console.WriteLine(mesaj);
                i++;
            } while (i < kelime.Length);

        }
    }
}