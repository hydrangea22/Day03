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
            int a = 3;
            int b = 5;
            float c = 3.5f;
            float d = 2.4f;

            SwapNumber(ref a, ref b);
            SwapNumber(a, b);
            SwapNumber(c, d);

            Console.WriteLine(a);
            Console.WriteLine(b);
        }


        //Call by Reference
        static void SwapNumber(ref int a1, ref int b1)
        {
            int c = 0;

            c = a1;     //main->a
            a1 = b1;    //main->b
            b1 = c;

            Console.WriteLine(a1);
            Console.WriteLine(b1);
        }


        //Call by Value
        static void SwapNumber(int a1, int b1)
        {
            int c = 0;

            c = a1;     //main->a
            a1 = b1;    //main->b
            b1 = c;

            Console.WriteLine(a1);
            Console.WriteLine(b1);
        }


        //Call by Value (float)
        static void SwapNumber(float a1, float b1)
        {
            float c = 0;

            c = a1;     //main->a
            a1 = b1;    //main->b
            b1 = c;

            Console.WriteLine(a1);
            Console.WriteLine(b1);
        }
    }
}
