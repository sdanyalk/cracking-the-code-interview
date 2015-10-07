using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 
 * Design an algorithm to figure out if someone has won a game of tic-tac-toe.
 */
namespace CrackingTheCodeInterview
{
    class C17Q2_TicTacToe
    {
        static void Main(string[] args)
        {
            char[,] board = new char[3, 3] { {' ', ' ', ' '},
                                             {'X', 'X', '0'},
                                             {'0', '0', 'X'} };

            Console.WriteLine("Winner is: " + findWinner(board));
            Console.ReadLine();
        }

        static char findWinner(char[,] board)
        {
            int N = board.GetLength(0);
            int r, c = 0;

            //Check winner rows.
            for (r = 0; r < N; r++)
            {
                if (board[r, 0] != ' ')
                {
                    for (c = 1; c < N; c++)
                    {
                        if (board[r, c] != board[r, c - 1])
                            break;
                    }

                    if (c == N)
                        return board[r, 0];
                }
            }

            //Check winner columns.
            for (c = 0; c < N; c++)
            {
                if (board[0, c] != ' ')
                {
                    for (r = 1; r < N; r++)
                    {
                        if (board[r, c] != board[r - 1, c])
                            break;
                    }

                    if (r == N)
                        return board[0, c];
                }
            }

            //Check diagonal - Right to Left.
            if (board[0, 0] != ' ')
            {
                for (r = 1; r < N; r++)
                {
                    if (board[r, r] != board[r - 1, r - 1])
                        break;
                }
                if (r == N)
                    return board[0, 0];
            }

            //Check diagonal - Left to Right.
            if (board[0, N - 1] != ' ')
            {
                c = N;
                for (r = 0; r < N - 1; r++)
                {
                    c--;
                    if (board[r, c] != board[r + 1, c - 1])
                        break;
                }
                if (r == N - 1)
                    return board[r, 0];
            }

            return '-';
        }
    }
}
