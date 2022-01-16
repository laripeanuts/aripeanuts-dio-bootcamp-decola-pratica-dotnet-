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
                            Console.WriteLine($"Nome: {a.Nome}. Nota: {a.Nota}.");
                        }
                        break;
                    case "3":
                        //TODO
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
