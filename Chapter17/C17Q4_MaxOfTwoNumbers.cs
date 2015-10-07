using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 
 * Write a method which finds the maximum of two numbers. You should not use if-else or any other comparison operator.
 */

/* NOTES:
 * 2147483647 [(2^31)-1] is max value of int.
 * 01111111111111111111111111111111 = 2^31 - 1  =  2147483647
 * 10000000000000000000000000000001 = 	        = -2147483647
 * 10000000000000000000000000000000 = 2^31      = -2147483648
 * overflow value is calculated as follows:
 *  2147483647 = 01111111111111111111111111111111
 * +2          = 00000000000000000000000000000010
 *             = 10000000000000000000000000000001 (since MSB is set, it means it is a negative number)
 * To get the real value of negative number:
 *  10000000000000000000000000000001
 *  01111111111111111111111111111110 - flip the bits
 * +00000000000000000000000000000001 - add one
 *  01111111111111111111111111111111 - 2147483647 (this is the negative number: -2147483647)
 */
namespace CrackingTheCodeInterview.Chapter17
{
    class C17Q4_MaxOfTwoNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number 1: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter number 2: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Max of two numbers is                    : " + findMaxOfTwoNumbers(a, b));
            Console.WriteLine("Max of two numbers is (avoiding overflow): " + findMaxOfTwoNumbersAvoidOverflow(a, b));
            Console.ReadLine();
        }

        static int findMaxOfTwoNumbers(int a, int b)
        {
            int c = a - b;
            int i = getSign(c);
            int j = switchSign(i);

            return i * a + j * b;
        }

        static int findMaxOfTwoNumbersAvoidOverflow(int a, int b)
        {
            int signOfa = getSign(a);
            int signOfb = getSign(b);
            int signOfc = getSign(a - b);

            //Overflow occurs only when numbers have different signs.
            //If the signs are different then only use sign of a.
            int useSignOfa = signOfa ^ signOfb;

            //If the signs are same then use sign of a-b. In this case overflow is not possible.
            int useSignOfc = switchSign(useSignOfa);

            int i = useSignOfa * signOfa + useSignOfc * signOfc;
            int j = switchSign(i);

            return i * a + j * b;
        }

        //right shift number by 3 will bring out the MSB. For negative number MSB is 1.
        //Assuming that '1' represents positive number and '0' represents negative numbers, hence the switchSign.
        static int getSign(int num)
        {
            return switchSign((num >> 31) & 1);
        }

        static int switchSign(int num)
        {
            return (1 ^ num);
        }
    }
}
