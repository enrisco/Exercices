using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projTiroAoAlvo
{
    class Program
    {
        
        static string op;

        static void Main(string[] args)
        {
            do
            {
                int alvoX = CriarPosicaoAleatoria(),
                    alvoY = CriarPosicaoAleatoria(),
                    jogadas = 1;
                bool ganhou = false;

                string[,] b = new string[4, 4]
                {
                    { " ", " ", " ", " " },
                    { " ", " ", " ", " " },
                    { " ", " ", " ", " " },
                    { " ", " ", " ", " " }
                };

                do
                {
                    int tentX, tentY;
                    Console.WriteLine(alvoX + ", " + alvoY);

                    Console.Clear();
                    Console.WriteLine("Tiro ao Alvo");

                    CriarTabuleiro(b);

                    do
                    {
                        tentX = ChequeSeNumeroEstaDentroDoLimite(true);
                        tentY = ChequeSeNumeroEstaDentroDoLimite(false);

                        if (ChequeSeJaEstaAssinalado(b, tentX, tentY))
                        {
                            Console.WriteLine("Você acertou um espaço já acertado, tente novamente.");
                            Console.ReadLine();
                        }
                    } while (ChequeSeJaEstaAssinalado(b, tentX, tentY));

                    if(ChequeSeAcertouAPosicao(alvoX,alvoY,tentX, tentY))
                    {
                        b[alvoX, alvoY] = "O";
                        ganhou = true;

                        Console.Clear();
                        Console.WriteLine("Tiro ao Alvo");

                        CriarTabuleiro(b);

                        Console.WriteLine("Você ganhou! Aperte qualquer botão para continuar!");
                    }
                    else
                    {
                        b[tentX, tentY] = "X";
                        jogadas++;
                        
                        if(jogadas == 4)
                            Console.WriteLine("Você não conseguiu acertar o alvo no número de rodadas permitido.");
                        else
                            Console.WriteLine("Você errou! " + CriarMensagemDeDica(alvoX, alvoY, tentX, tentY));
                        Console.WriteLine("Aperte qualquer botão para continuar.");
                    }
                    Console.ReadKey();
                } while (jogadas < 5 && !ganhou);

                Console.Write("Deseja continuar? (s/n): ");
                op = Console.ReadLine().ToUpper();
            }
            while (op != "N");
        }

        static void CriarTabuleiro(string[,] b)
        {
            
            Console.WriteLine
            (
                "_________________\n" +
                "| {0} | {1} | {2} | {3} |\n" +
                "|___|___|___|___|\n" +
                "| {4} | {5} | {6} | {7} |\n" +
                "|___|___|___|___|\n" +
                "| {8} | {9} | {10} | {11} |\n" +
                "|___|___|___|___|\n" +
                "| {12} | {13} | {14} | {15} |\n" +
                "|___|___|___|___|\n", b[0, 0], b[0, 1],
                b[0, 2], b[0, 3], b[1, 0], b[1, 1], b[1, 2],
                b[1, 3], b[2, 0], b[2, 1], b[2, 2], b[2, 3],
                b[3, 0], b[3, 1], b[3, 2], b[3, 3]
            );
        }

        static int CriarPosicaoAleatoria()
        {
            Random r = new Random();
            return r.Next(0, 5);
        }

        static string CriarMensagemDeDica(int alvoX, int alvoY, int tentX, int tentY)
        {
            string m = "Dica: ";

            if (tentX > alvoX)
                m += "Tente mais para cima e ";
            else if (tentX < alvoX)
                m += "Tente mais para baixo e ";
            else
                m += "Você acertou a linha! Já a coluna, ";

            if (tentY > alvoY)
                m += "tente mais para a esquerda!";
            else if (tentY < alvoY)
                m += "tente mais para a direita!";
            else
                m += "a coluna você já acertou!";

            return m;
        }

        static int ChequeSeNumeroEstaDentroDoLimite(bool linha)
        {
            int tmp = 5;

            do
            {
                if (linha)
                    Console.Write("Digite o número da linha do tiro (1 até 4): ");
                else
                    Console.Write("Digite o número da coluna do tiro (1 até 4): ");

                tmp = Convert.ToInt32(Console.ReadLine()) - 1;

                if (tmp < 0 || tmp > 3)
                {
                    Console.WriteLine("Número inválido. Aperte qualquer tecla para continuar.\n");
                    Console.ReadKey();
                }

            } while (tmp < 0 || tmp > 3);

            return tmp;
        }

        static bool ChequeSeJaEstaAssinalado(string [,] b, int tentX, int tentY)
        {
            return b[tentX, tentY] == "X";
        }

        static bool ChequeSeAcertouAPosicao(int alvoX, int alvoY, int tentX, int tentY)
        {
            return tentX == alvoX && tentY == alvoY;
        }
    }
}
