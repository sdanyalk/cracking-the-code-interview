using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * The Game of Master Mind is played as follows:
 * The computer has four slots, and each slot will contain a ball that is red (R), yellow (Y), green (G) or blue (B).
 * For example, the computer might have RGGB {Slot #1 is red, Slots #2 and #3 are green, Slot #4 is blue).
 * You, the user, are trying to guess the solution. You might, for example, guess YRGB.
 * When you guess the correct color for the correct slot, you get a "hit." If you guess a color that exists but is in the wrong slot,
 * you get a "pseudo-hit." Note that a slot that is a hit can never count as a pseudo-hit.
 * For example, if the actual solution is RGBY and you guess GGRR, you have one hit and one pseudo-hit.
 * Write a method that, given a guess and a solution, returns the number of hits and pseudo-hits.
 */
namespace CrackingTheCodeInterview.Chapter17
{
    public class Result
    {
        int hit;
        int pseudoHit;

        public int Hit
        {
            get { return hit; }
            set { hit = value; }
        }

        public int PseudoHit
        {
            get { return pseudoHit; }
            set { pseudoHit = value; }
        }

        public string toString()
        {
            return ("Number of hits: " + hit + "\nNumber of pseudo hits: " + pseudoHit);
        }
    }

    class C17Q5_GameOfMasterMind
    {
        static void Main(string[] args)
        {
            string solution = "RRGB";
            Console.Write("Enter guess: ");
            Result result = getResult(Console.ReadLine().ToUpper(), solution);
            if (result != null)
                Console.WriteLine(result.toString());
            else
                Console.WriteLine("Invalid input");
            Console.Read();
        }

        public static Result getResult(string guess, string solution)
        {
            if (guess.Length != solution.Length || guess.Length < 4 || solution.Length < 4)
                return null;

            Result result = new Result();
            int[] frequency = new int[4];

            //Get number of hits.
            for (int i = 0; i < solution.Length; i++)
            {
                if (guess[i] == solution[i])
                {
                    result.Hit++;
                }
                else
                {
                    frequency[convertCode(solution[i])]++;
                }
            }

            //Get number of pseudo hits.
            for (int i = 0; i < guess.Length; i++)
            {
                int numCode = convertCode(guess[i]);
                if (guess[i] != solution[i] && numCode >= 0 && frequency[numCode] > 0)
                {
                    result.PseudoHit++;
                    frequency[numCode]--;
                }
            }

            return result;
        }

        public static int convertCode(char code)
        {
            int numCode = -1;

            switch (code)
            {
                case 'R':
                    numCode = 0;
                    break;

                case 'Y':
                    numCode = 1;
                    break;

                case 'G':
                    numCode = 2;
                    break;

                case 'B':
                    numCode = 3;
                    break;

                default:
                    numCode = -1;
                    break;
            }

            return numCode;
        }
    }
}
