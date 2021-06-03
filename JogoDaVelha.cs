using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projOldLadysGame
{
    class Program
    {
        static string[,] tab = new string[3, 3];
        static bool p1phase = true, finish = false, draw = false;
        static int phases = 1;
        static string player = "";

        static void Main(string[] args)
        {
            do
            {
                int linha = 0, coluna = 0;
                WriteTab();

                if (!finish)
                {
                    if (p1phase)
                    {
                        player = "X";
                        p1phase = false;
                    }
                    else
                    {
                        player = "O";
                        p1phase = true;
                    }
                    Console.WriteLine("É a vez do {0}! Escreva a coluna e escreva a linha!", player);
                    Console.Write("Coluna: ");
                    coluna = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Write("Linha: ");
                    linha = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (tab[linha, coluna] == null)
                        tab[linha, coluna] = player;

                    if (phases >= 5)
                    {
                        if (phases <= 9)
                        {
                            if (CheckLinesAndColumns(player) || CheckDiagonal(player))
                            {
                                finish = true;
                                draw = false;
                            }

                        }

                        if (phases == 9)
                        {
                            finish = true;
                            draw = true;
                        }
                    }

                    phases++;
                    Console.Clear();
                }
                else
                {
                    if (!draw)
                        Console.WriteLine("{0} ganhou!", player);
                    else
                        Console.WriteLine("O jogo empatou.");

                    Console.ReadKey();
                    break;
                }
            }
            while (phases != 11);
        }

        static void WriteTab()
        {
            Console.WriteLine("Jogo Da Velha\n");
            for (int l = 0; l < 3; l++)
            {
                Console.WriteLine("\t \t|\t \t|\t \t");
                for (int c = 0; c < 3; c++)
                {
                    Console.Write("\t{0}\t", tab[l, c]);
                    if (c != 2)
                        Console.Write("|");
                }
                Console.WriteLine("\n\t \t|\t \t|\t \t");
                if (l != 2)
                    Console.WriteLine("________________|_______________|________________");
            }

            Console.WriteLine();
        }

        static bool CheckLinesAndColumns(string player)
        {
            Console.WriteLine(player);
            for (int i = 0; i < 3; i++)
            {
                if (tab[i, 0] == player && tab[i, 1] == player && tab[i, 2] == player)
                    return true;
                else if (tab[0, i] == player && tab[1, i] == player && tab[2, i] == player)
                    return true;
            }

            return false;
        }

        static bool CheckDiagonal(string player)
        {
            if (tab[0, 0] == player && tab[1, 1] == player && tab[2, 2] == player)
                return true;
            else if (tab[0, 2] == player && tab[1, 1] == player && tab[2, 0] == player)
                return true;
            else
                return false;
        }
    }
}
