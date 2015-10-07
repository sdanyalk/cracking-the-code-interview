using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 
 * Write an algorithm which computes the number of trailing zeros in n factorial.
 */
namespace CrackingTheCodeInterview.Chapter17
{
    class C17Q3_TrailingZerosInFactorial
    {
        static void Main(string[] args)
        {
            Console.Write("Enter factorial number: ");
            Console.WriteLine(countNumberOfTrailingZeros(int.Parse(Console.ReadLine())));
            Console.ReadLine();
        }
        static int countNumberOfTrailingZeros(int num)
        {
            int count = 0;

            if (num < 0)
                return 0;

            //Every multiple of 5 adds a zero.
            //Every multiple of 25 (5 x 5) adds an additional zero.
            //Every multiple of 125 (5 x 5 x 5) adds an additional zero.
            //and so on...
            for (int i = 5; num / i > 0; i *= 5)
                count += num / i;

            return count;
        }
    }
}
