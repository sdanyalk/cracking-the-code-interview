using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Write a function to swap a number in place (that is, without temporary variables).
 */
namespace CrackingTheCodeInterview
{
    class C17Q1_SwapNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number 1: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Enter number 2: ");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine("Before swap:");
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);

            Console.WriteLine("After swap:");
            swapNumbers(a, b);

            Console.WriteLine("Using Bit Operation to swap:");
            swapNumberUsingBitOp(a, b);

            Console.ReadLine();
        }

        static void swapNumbers(int a, int b)
        {
            a = b - a;
            b = b - a;
            a = a + b;

            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
        }

        static void swapNumberUsingBitOp(int a, int b)
        {
            a = a ^ b; //New value in a.
            b = a ^ b; //This has value of a.
            a = a ^ b; //This has value of b.

            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
        }
    }
}
