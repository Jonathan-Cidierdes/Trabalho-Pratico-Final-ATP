using System;
using System.IO;

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
        for (int i = 0; i < tamanhoLista; i++)
        {
            escritor.WriteLine(listaDeAlunos[i]);
        }
        escritor.Close();

        Console.WriteLine("\n--- Arquvo salvo com sucesso! ---");
    }
    public static void carregarArquivo()
    {
        StreamReader leitor = new StreamReader(nomeArquivo);
        for (int i = 0; i < tamanhoLista; i++)
        {
            listaDeAlunos[i] = leitor.ReadLine();
        }
        leitor.Close();
        Console.WriteLine("\n--- Arquvo carregado com sucesso! ---");
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
            Console.WriteLine("\n» Lista de Alunos registrados:");
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

    }
    public static void listarAniversariantes()
    {

    }
    public static void excluirPorCpf()
    {

    }
    public static void excluirTodosAlunos()
    {

    }
}

class Aluno
{
    private string nome;
    private string cpf;
    private Data nascimento = new Data();
    private Data cadastro = new Data();
    //private double nota = 0;
    public static int qtAlunos = 0;

    public Aluno() { qtAlunos++; }
    public Aluno(string nome, int dia, int mes, int ano)
    {
        setNome(nome);
        nascimento.setData(dia, mes, ano);
        setCadastro(dia, mes, ano);
        qtAlunos++;
    }
    public void setNome(string nome)
    {
        this.nome = nome;
    }
    public string getNome()
    {
        return nome;
    }

    public bool setNascimento(int dia, int mes, int ano)
    {
        nascimento.setData(dia, mes, ano);
        return nascimento.dataValida();
    }
    public Data getNascimento()
    {
        return nascimento;
    }

    public void setCadastro(int dia,int mes,int ano)
    {
        cadastro.setData(dia, mes, ano);
    }
    public Data getCadastro()
    {
        return cadastro;
    }

    public void setCpf(string cpf)
    {
        this.cpf = cpf;
    }
    public string getCpf()
    {
        return cpf;
    }

    public void leiaNome()
    {
        Console.Write("\nDigite o nome do aluno: ");
        setNome(Console.ReadLine());
    }
    public void escrevaNome()
    {
        Console.Write(getNome());
    }

    public void leiaAluno()
    {
        leiaNome();
        Console.WriteLine("Digite o CPF: ");
        setCpf(Console.ReadLine());
        Console.WriteLine("\nPara inserir a data de nascimento...");
        nascimento.leiaData();
        Console.WriteLine("\nPara inserir a data de cadastro...");
        cadastro.leiaData();
        Console.WriteLine("\n=== Aluno cadastrado com sucesso! ===");
    }
    public void escrevaAluno()
    {
        Console.Write("Nome: ");
        escrevaNome();
        Console.Write("\nNascimento: ");
        nascimento.escrevaData();
        Console.Write("\nCadastro: ");
        cadastro.escrevaData();
        Console.Write("\nCPF: ");
        Console.WriteLine(getCpf());
        Console.WriteLine();
    }
}

class Data
{
    private int dia;
    private int mes;
    private int ano;

    public bool setDia(int dia)
    {
        bool diaValido = true;

        if (dia >= 0 && dia <= 31) this.dia = dia;
        else diaValido = false;

        return diaValido;
    }
    public bool setMes(int mes)
    {
        bool mesValido = true;

        if (mes >= 0 && mes <= 12) this.mes = mes;
        else mesValido = false;

        return mesValido;
    }
    public void setAno(int ano)
    {
        this.ano = ano;
    }

    public bool setData(int dia, int mes, int ano)
    {
        setDia(dia);
        setMes(mes);
        setAno(ano);
        return dataValida();
    }

    public int getDia()
    {
        return dia;
    }
    public int getMes()
    {
        return mes;
    }
    public int getAno()
    {
        return ano;
    }

    public bool dataValida()
    {
        bool valida = false;
        if ((getDia() >= 0 && getDia() <= 31) && (getMes() >= 0 && getMes() <= 12)) valida = true;
        return valida;
    }
    public string mesExtenso()
    {
        string[] nomeMes = { "janeiro", "fevereiro", "março", "abril", "maio", "junho", "julho", "agosto", "setembro", "outubro", "novembro", "dezembro" };
        return nomeMes[getMes() - 1];
    }
    public int diasMes()
    {
        int[] qtDias = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        if ((getMes() == 2) && (getAno() % 4 == 0) && ((getAno() % 100 != 0) || (getAno() % 400 == 0)))
            qtDias[1] = 29;
        return qtDias[getMes() - 1];
    }

    public void escrevaData()
    {
        Console.Write(getDia() + "/" + getMes() + "/" + getAno());
    }
    public void leiaData()
    {
        Console.Write("Digite o dia: ");
        setDia(int.Parse(Console.ReadLine()));
        Console.Write("Digite o mês:" );
        setMes(int.Parse(Console.ReadLine()));
        Console.Write("Digite o ano:" );
        setAno(int.Parse(Console.ReadLine()));
    }
}