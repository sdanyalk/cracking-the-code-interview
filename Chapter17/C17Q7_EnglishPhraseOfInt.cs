using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Given any integer, print an English phrase that describes the integer (e.g., "OneThousand, Two Hundred Thirty Four").
 */
namespace CrackingTheCodeInterview.Chapter17
{
    class C17Q7_EnglishPhraseOfInt
    {
        static string[] ones = new string[] { "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
        static string[] teen = new string[] { "Eleven ", "Twelve ", "Thirteen ", "Forteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Ninteen " };
        static string[] tens = new string[] { "Ten ", "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
        static string[] bigs = new string[] { "", "Thousand ", "Million ", "Billion " };

        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            Console.WriteLine("English phrase: " + convertIntegerToEnglishPhrase(int.Parse(Console.ReadLine())));
            Console.ReadLine();
        }

        static string convertIntegerToEnglishPhrase(int number)
        {
            string str = string.Empty;
            int count = 0;

            if (number == 0)
                return "Zero";
            else if (number < 0)
                return "Negative " + convertIntegerToEnglishPhrase(number * -1);

            while(number > 0)
            {
                str = convertHundred(number % 1000) + bigs[count] + str;
                number /= 1000;
                count++;
            }

            return str;
        }

        static string convertHundred(int number)
        {
            string str = string.Empty;

            /*Convert hundred*/
            if (number >= 100)
            {
                str = ones[number / 100 - 1] + "Hundred ";
                number %= 100;
            }

            /*Convert tens*/
            if(number > 0)
            {
                if(number > 10 && number < 20)
                    return str += teen[number - 11];
                else if (number < 10)
                    return str += ones[number - 1];
                else if (number == 10 || number >= 20)
                {
                    str += tens[number / 10 - 1];
                    number %= 10;
                }
            }

            /*Convert ones*/
            if (number > 0)
            {
                str += ones[number - 1];
            }

            return str;
        }
    }
}
