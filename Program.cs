using System.Numerics;
using System.Text;


namespace BinaryClock
{
    internal class Program
    {
        
        static DateTime date = DateTime.Now;
       
        static int[] binarySeconds = new int [6];
        static int[] binaryMinutes=new int[6];
        static int[] binaryHours= new int[5];
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            InfiniteLoop();
        }

        private static void GetBinaryVectors(int[] VectorSecunde, int[] VectorMinute,int[] VectorOre) 
        {
            date = DateTime.Now;
            int secunde = date.Second;
            int minute = date.Minute;
            int ore = date.Hour;
            int i = 0;
            int aux;
            Array.Clear(VectorOre);
            Array.Clear(VectorSecunde);
            Array.Clear(VectorMinute);
            while(secunde != 0)
            {
                aux = secunde % 2;
                VectorSecunde[i] = aux;
                secunde /= 2;
                i++;
            }
            i = 0;
            while (minute != 0)
            {
                aux = minute % 2;
                VectorMinute[i] = aux;
                minute /= 2;
                i++;
            }
            i = 0;
            while (ore != 0)
            {
                aux = ore % 2;
                VectorOre[i] = aux;
                ore /= 2;
                i++;
            }

        }
        private static void ShowConsoleWithDates()
        {
            Console.WriteLine("Binary Clock");
            Console.WriteLine();
            Console.WriteLine($"{date.ToString("hh:mm:ss")}");
            Console.WriteLine();
            Console.Write("Hours: ");
            for(int i = 4;i>=0;i--)
            {
                if (binaryHours[i] == 1)
                    Console.Write('●');
                else Console.Write('○');
            }
            Console.WriteLine();
            Console.Write("Minutes: ");
            for (int i = 5; i >= 0; i--)
            {
                if (binaryMinutes[i] == 1)
                    Console.Write("●");
                else Console.Write("○");
            }
            Console.WriteLine();
            Console.Write("Seconds: ");
            for (int i = 5; i >= 0; i--)
            {
                if (binarySeconds[i] == 1)
                    Console.Write('●');
                else Console.Write('○');
            }

        }
        private static async void InfiniteLoop()
        {
            while (true)
            {
                GetBinaryVectors(binarySeconds, binaryMinutes, binaryHours);
                ShowConsoleWithDates();
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        
    }
}