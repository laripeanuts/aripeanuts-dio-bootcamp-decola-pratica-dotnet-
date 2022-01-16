using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;
            string opcaoUsuario = Pega();

            while (opcaoUsuario.ToUpper() != "X")
            {

                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException("Valor deve ser decimal.");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;
                    case "2":
                        foreach (var a in alunos)
                        {
                            if (string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"Nome: {a.Nome}. Nota: {a.Nota}.");
                            }
                        }
                        break;
                    case "3":
                        decimal nrNotaTotal = 0;
                        var nrAlunosTotal = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                             if (string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                nrNotaTotal = nrNotaTotal + alunos[i].Nota;
                                nrAlunosTotal++;
                            }
                        }

                        var mediaGeral = nrNotaTotal / nrAlunosTotal;
                        Conceito conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        } else if (mediaGeral < 4) {
                            conceitoGeral = Conceito.D;
                        } else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;    
                        } else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        } else if (mediaGeral < 10)
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"Média geral: {mediaGeral}. Conceito: {conceitoGeral}.");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = Pega();
            }
        }

        public static string Pega()
        {
            Console.WriteLine();
            Console.WriteLine("Indique, uma das opções:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar Alunos");
            Console.WriteLine("3 - Calcular média");
            Console.WriteLine("X para sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
