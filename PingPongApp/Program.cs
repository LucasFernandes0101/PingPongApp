using System;

namespace PingPongApp
{
    internal class Program
    {
        public static string Saque(string pontuacao, string vez)
        {
            string pontosA = "";
            string pontosB = "";

            //A letra do jogador da vez
            char jogadorvez = vez[0];
            //O número da vez do jogador
            int numerovez = (int)Char.GetNumericValue(vez[1]);

            //Separa a pontuação entre os jogadores
            for (int i = 0; i < pontuacao.Length; i++)
            {
                //Após o ":" todos os digitos serão passados ao jogador B
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

            //Converte todos os pontos para INT
            int jogadorA = Int32.Parse(pontosA);
            int jogadorB = Int32.Parse(pontosB);

            //Checa se alguém ganhou a rodada
            if (jogadorA >= 21  && jogadorA > jogadorB + 2)
            {
                return "GANHOU A";
            }
            else if (jogadorB <= 21 && jogadorB > jogadorA + 2)
            {
                return "GANHOU B";
            }

            //Checa se as regras estão mudadas
            if (jogadorA >= 20 && jogadorB >= 20)
            {
                //Se a vez do jogador está na segunda, troca o saque
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
                    //Se não está na segunda vez, mantém o saque e aumenta a vez
                    numerovez += 1;
                    vez = jogadorvez + numerovez.ToString();
                    return vez;
                }
            }

            //Convere a vez do jogador
            //Se a vez do jogador está na quinta, troca o saque
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
                //Se não está na quinta vez, mantém o saque e aumenta a vez
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

                //Se o retorno for a vitória, para a aplicação
                if (result.Contains("GANHOU"))
                {
                    Console.WriteLine(result);
                    con = false;
                }

                //Se o retorno for a vez de saque, continua
                else
                {
                    vez = result;
                    Console.WriteLine("É A VEZ DO JOGADOR " + vez[0]);
                }
            }
        }
    }
}