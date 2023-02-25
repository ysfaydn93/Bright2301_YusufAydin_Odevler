namespace Odev02_16_02_2023
{
    internal class Program
    {              /* 2) ekrana çarpım tablosu yazdıran*/
        static void Main(string[] args)
        {
            //for
            //for (int i = 1; i <= 10; i++)
            //    {
            //        for (int j = 1; j <= 10; j++)
            //        {
            //            Console.WriteLine($"{i}x{j}={i * j}");
            //        }
            //    }

            //while 

            //int i = 1;
            //int j = 1;
            //while (i <= 10)
            //{

            //    while (j <= 10)
            //    {
            //        Console.WriteLine($"{i}x{j}={i * j}");
            //        j++;
            //    }
            //    Console.WriteLine();
            //    j = 1;
            //    i++;
            //}

            // do-while
            int i = 1;
            int j = 1;
            do
            {
                j = 1;
              do  {

                    
                        Console.WriteLine($"{i}x{j}={i * j}");
                        j++;
                    } while (j <= 10) ;
                    i++;

                Console.WriteLine();
                } while (i <= 10);
        } 

        } } 