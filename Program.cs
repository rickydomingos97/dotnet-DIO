using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno: ");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno: ");
                
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno; // aqui joga o dado aluno recebido no terminal para o Array
                        indiceAluno++;
                        break;
                    case "2":
                        //TODO: LISTAR ALUNOS
                        foreach(var student in alunos)
                        {
                            /* if (!student.Nome.Equals("")) */ //Se o nome NAO FOR vazio ai imprime o nome e nota do aluno
                            if (!string.IsNullOrEmpty(student.Nome))
                            {
                                Console.WriteLine($"ALUNO: {student.Nome} - NOTA: {student.Nota}");
                            }
                            
                        }
                        break;
                    case "3":
                        //TODO: Calcular MEDIA GERAL
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++ )
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if ( mediaGeral < 2 )
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if ( mediaGeral < 4 )
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if ( mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if ( mediaGeral < 8 )
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else 
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MEDIA GERAL {mediaGeral} - CONCEITO {conceitoGeral}");
                        
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Digite uma opcao valida");
                }
                Console.WriteLine();

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Informe a opcao desejada: ");
            Console.WriteLine("1- Inserir aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular media geral");
            Console.WriteLine("X- SAIR");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
