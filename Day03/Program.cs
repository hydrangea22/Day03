using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            string input = Console.ReadLine();
            count = int.Parse(input);

            for (int y = 0; y < count; ++y)
            {
                PrintLine(y);
            }

            for (int y = count; y >= 0; --y)
            {
                PrintLine(y);
            }
        }

        /// <summary>
        /// 한줄에 지정한 만큼 "*"출력 후 줄 바꿈
        /// </summary>
        /// <param name="count"></param>
        static void PrintLine(int count)
        {
            for (int x = 0; x <= count; ++x)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}
