using System;

namespace PingPongApp
{
    internal class Program
    {
        public static string Saque(string pontuacao, string vez)
        {
            string pontosA = "";
            string pontosB = "";
            char jogadorvez = vez[0];
            int numerovez = (int)Char.GetNumericValue(vez[1]);

            //Separa a pontuação entre os jogadores
            for (int i = 0; i < pontuacao.Length; i++)
            {
                if (pontuacao[i] == ':')
                {
                    for (int j = i + 1; j < pontuacao.Length; j++)
                    {
                        pontosB += pontuacao[j];
                    }
                    break;
                }
                else
                {
                    pontosA += pontuacao[i];
                }
            }

            //Converte os pontos para INT
            int jogadorA = Int32.Parse(pontosA);
            int jogadorB = Int32.Parse(pontosB);

            //Checa se alguem ganhou
            if (jogadorA >= 21  && jogadorA > jogadorB + 2)
            {
                return "GANHOU A";
            }
            else if (jogadorB <= 21 && jogadorB > jogadorA + 2)
            {
                return "GANHOU B";
            }

            //Chega se as regras estão mudadas
            if (jogadorA >= 20 && jogadorB >= 20)
            {
                if (numerovez >= 2)
                {
                    numerovez = 1;
                    if (jogadorvez == 'A')
                    {
                        jogadorvez = 'B';
                    }
                    else
                    {
                        jogadorvez = 'A';
                    }
                    vez = jogadorvez + numerovez.ToString();
                    return vez;
                }
                else
                {
                    numerovez += 1;
                    vez = jogadorvez + numerovez.ToString();
                    return vez;
                }
            }

            //Convere a vez do jogador
            if (numerovez == 5)
            {
                numerovez = 1;
                if (jogadorvez == 'A')
                {
                    jogadorvez = 'B';
                }
                else
                {
                    jogadorvez = 'A';
                }
                vez = jogadorvez + numerovez.ToString();
                return vez;
            }
            else
            {
                numerovez += 1;
                vez = jogadorvez + numerovez.ToString();
                return vez;
            }
        }

        public static void Main(string[] args)
        {
            bool con = true;
            string vez = "A0";
            while (con)
            {
                string result = Saque(Console.ReadLine(), vez);
                if (result.Contains("GANHOU"))
                {
                    Console.WriteLine(result);
                    con = false;
                }

                else
                {
                    vez = result;
                    Console.WriteLine("É A VEZ " + vez[1] + " DO JOGADOR " + vez[0]);
                }
            }
        }
    }
}