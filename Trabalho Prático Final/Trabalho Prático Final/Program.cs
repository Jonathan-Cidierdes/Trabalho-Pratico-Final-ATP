using System;
using System.IO;
using Cadastro_Alunos;

class Program
{
    public static Aluno[] listaDeAlunos = new Aluno[100];
    public static int tamanhoLista = 0;
    public static string nomeArquivo = "Arquivo de Alunos";

    static void Main()
    {
        int opt = menu();

        while (opt != 0)
        {
            switch (opt)
            {
                case 0:
                    break;
                case 1:
                    salvarArquivo();
                    break;
                case 2:
                    carregarArquivo();
                    break;
                case 3:
                    novoAluno();
                    break;
                case 4:
                    listarAlunos();
                    break;
                case 5:
                    pesquisarPeloNome();
                    break;
                case 6:
                    listarAniversariantes();
                    break;
                case 7:
                    excluirPorCpf();
                    break;
                case 8:
                    excluirTodosAlunos();
                    break;
                default:
                    Console.WriteLine("\n!!! Opção inválida !!!");
                    break;
            }
            opt = menu();
        }
        Console.WriteLine("\n\n[Saindo do programa...]");
    }

    public static int menu()
    {
        Console.Write("\n\n============================\n" +
            "||   Registro de Alunos   ||\n" +
            "============================\n" +
            "Digite a operação desejada:\n\n" +
            "0 – Sair do programa\n" +
            "1 – Salvar os dados dos alunos em um arquivo\n" +
            "2 – Recuperar os dados dos alunos armazenados em um arquivo\n" +
            "3 - Cadastrar um Aluno\n" +
            "4 – Listar todos os alunos\n" +
            "5 – Pesquisar alunos por um nome chave de pesquisa\n" +
            "6 – Listar os alunos aniversariantes de um mês chave de pesquisa\n" +
            "7 – Excluir um aluno a partir de um CPF chave de pesquisa\n" +
            "8 – Excluir todos os alunos\n" +
            "\n -> ");
        return int.Parse(Console.ReadLine());
    }
    public static void salvarArquivo()
    {
        StreamWriter escritor = new StreamWriter(nomeArquivo);
        escritor.WriteLine(tamanhoLista);
        for (int i = 0; i < tamanhoLista; i++)
        {
            escritor.WriteLine(listaDeAlunos[i].getNome());
            escritor.WriteLine(listaDeAlunos[i].getCpf());
            escritor.WriteLine(listaDeAlunos[i].getNascimento().getDia());
            escritor.WriteLine(listaDeAlunos[i].getNascimento().getMes());
            escritor.WriteLine(listaDeAlunos[i].getNascimento().getAno());
            escritor.WriteLine(listaDeAlunos[i].getCadastro().getDia());
            escritor.WriteLine(listaDeAlunos[i].getCadastro().getMes());
            escritor.WriteLine(listaDeAlunos[i].getCadastro().getAno());
            escritor.WriteLine(listaDeAlunos[i].getNota());

        }
        escritor.Close();

        Console.WriteLine($"\n--- Arquivo salvo com sucesso! ---\nQuantidade de alunos salvos: {tamanhoLista}");
    }
    public static void carregarArquivo()
    {

        StreamReader leitor = new StreamReader(nomeArquivo);
        int dia, mes, ano;
        tamanhoLista = int.Parse(leitor.ReadLine());
        for (int i = 0; i < tamanhoLista; i++)
        {
            listaDeAlunos[i] = new Aluno();
            listaDeAlunos[i].setNome(leitor.ReadLine());
            listaDeAlunos[i].setCpf(leitor.ReadLine());
            dia = int.Parse(leitor.ReadLine());
            mes = int.Parse(leitor.ReadLine());
            ano = int.Parse(leitor.ReadLine());
            listaDeAlunos[i].setNascimento(dia, mes, ano);
            dia = int.Parse(leitor.ReadLine());
            mes = int.Parse(leitor.ReadLine());
            ano = int.Parse(leitor.ReadLine());
            listaDeAlunos[i].setCadastro(dia, mes, ano);
            listaDeAlunos[i].setNota(double.Parse(leitor.ReadLine()));
        }
        leitor.Close();
        Console.WriteLine($"\n--- Arquivo carregado com sucesso! ---\nQuantidade de alunos carregados: {tamanhoLista}");
    }
    public static void novoAluno()
    {
        Console.WriteLine($"\n» Cadastro do {tamanhoLista + 1}° aluno: ");
        Aluno novoAluno = new Aluno();
        novoAluno.leiaAluno();
        listaDeAlunos[tamanhoLista] = novoAluno;
        tamanhoLista++;
    }
    public static void listarAlunos()
    {
        if (tamanhoLista > 0)
        {
            Console.WriteLine("\n» Lista de Alunos registrados:\n");
            for (int i = 0; i < tamanhoLista; i++)
            {
                listaDeAlunos[i].escrevaAluno();
                Console.WriteLine();
            }
        }
        else Console.WriteLine("\n--- Nenhum aluno foi registrado! ---");

    }
    public static void pesquisarPeloNome()
    {
        if (tamanhoLista == 0) Console.WriteLine("\n--- Não há nenhum aluno cadastrado! ---");
        else
        {
            Console.Write("Nome a ser pesquisado: ");
            string chave = Console.ReadLine().ToUpper();
            bool achou = false;
            Console.WriteLine($"\nLista de alunos contendo o nome {chave}:");
            for (int i = 0; i < tamanhoLista; i++)
            {
                if (listaDeAlunos[i].getNome().ToUpper().Contains(chave))
                {
                    listaDeAlunos[i].escrevaAluno();
                    achou = true;
                }
            }
            if (!achou) Console.WriteLine("\n--- Nenhum aluno com esse nome foi encontrado! ---");
        }
    }
    public static void listarAniversariantes()
    {
        if (tamanhoLista == 0) Console.WriteLine("\n--- Não há nenhum aluno cadastrado! ---");
        else
        {
            int chave = 0;
            do
            {
                Console.Write("Mês de nascimento a ser pesquisado: ");
                chave = int.Parse(Console.ReadLine());
                if (chave < 1 || chave > 12) Console.WriteLine("\n--- Mês inválido! ---");
            } while (chave < 1 || chave > 12);
            bool achou = false;
            Console.WriteLine($"\nLista de alunos nascidos em {listaDeAlunos[0].getNascimento().mesExtenso(chave)}:");
            for (int i = 0; i < tamanhoLista; i++)
            {
                if (listaDeAlunos[i].getNascimento().getMes() == chave)
                {
                    listaDeAlunos[i].escrevaAluno();
                    achou = true;
                }
            }
            if (!achou) Console.WriteLine($"\n--- Nenhum aluno nascido em {listaDeAlunos[0].getNascimento().mesExtenso(chave)} foi encontrado! ---");
        }
    }

    public static void excluirPorCpf()
    {
        if (tamanhoLista == 0) Console.WriteLine("\n--- Não há nenhum aluno cadastrado! ---");
        else
        {
            Console.Write("CPF do aluno a ser excluído: ");
            string chave = Console.ReadLine();
            bool achou = false;
            int i = 0;
            while ((!achou) && (i < tamanhoLista))
            {
                if (listaDeAlunos[i].getCpf() == chave) achou = true;
                else i++;
            }
            if (achou)
            {
                Console.WriteLine("Aluno encontrado:");
                listaDeAlunos[i].escrevaAluno();
                Console.WriteLine("Tem certeza de que deseja excluir o aluno acima? [S/N]");
                string confirm = Console.ReadLine().ToUpper();
                while (confirm != "S" && confirm != "N")
                {
                    Console.WriteLine("\n--- Comando inválido! ---\nTem certeza de que deseja excluir o aluno acima? [S/N]");
                    confirm = Console.ReadLine().ToUpper();
                }
                if (confirm == "S")
                {
                    for (int j = i; j < tamanhoLista - 1; j++)
                    {
                        listaDeAlunos[j] = listaDeAlunos[j + 1];
                    }
                    tamanhoLista--;
                    Console.WriteLine("\n--- Aluno excluído com sucesso! ---");
                }
                else Console.WriteLine("\n--- Operação cancelada! ---");
            }
            else Console.WriteLine($"\n--- Nenhum aluno com o CPF {chave} foi encontrado! ---");
        }
    }
    public static void excluirTodosAlunos()
    {
        if (tamanhoLista == 0) Console.WriteLine("\n--- Não há nenhum aluno cadastrado! ---");
        else
        {
            Console.WriteLine("Tem certeza de que deseja excluir TODOS os alunos? [S/N]");
            string confirm = Console.ReadLine().ToUpper();
            while (confirm != "S" && confirm != "N")
            {
                Console.WriteLine("\n--- Comando inválido! ---\nDeseja excluir TODOS os alunos? [S/N]");
                confirm = Console.ReadLine().ToUpper();
            }
            if (confirm == "S")
            {
                tamanhoLista = 0;
                Console.WriteLine("\n--- Todos os alunos foram excluídos com sucesso! ---");
            }
            else Console.WriteLine("\n--- Operação cancelada! ---");
        }
    }
}