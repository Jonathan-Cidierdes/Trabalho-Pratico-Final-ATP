class Program
{
    public int tamanhoLista = 0;
    static void Main()
    {
        Aluno[] listaDeAlunos = new Aluno[100];
        
        Console.WriteLine("Digite a operação desejada:\n0 – Sair do programa\n1 - Cadastrar um aluno\n2 – Listar todos os alunos");
        int digito = int.Parse(Console.ReadLine());

        while (digito != 0)
        {
            switch (digito)
            {
                case 0:
                    Console.WriteLine("Saindo do programa...");
                    break;
                case 1:
                    novoAluno();
                    break;
                case 2:
                    listarAlunos();
                    break;
                default:
                    Console.WriteLine("Valor inválido!");
                    break;
            }
        }
    }
    void novoAluno()
    {

    }
    void listarAlunos()
    {

    }
}

class Aluno
{
    private string nome;
    private Data nascimento;
    public static int qtAlunos = 0;

    public Aluno() { qtAlunos++; }
    public Aluno(string nome, int dia, int mes, int ano)
    {
        setNome(nome);
        nascimento.setData(dia, mes, ano);
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
    public void leiaNome()
    {
        Console.WriteLine("Digite o nome:");
        setNome(Console.ReadLine());
    }
    public void escrevaNome()
    {
        Console.Write(getNome());
    }
    public void leiaAluno()
    {
        leiaNome();
        Console.WriteLine("\nPara inserir a data de nascimento:");
        nascimento.leiaData();
    }
    public void escrevaAluno()
    {
        escrevaNome();
        Console.WriteLine("Nascimento: ");
        nascimento.escrevaData();
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
        string[] nomeMes = { "janeiro", "fevereiro", "março", "abril", "maio", "junho", "julho", "agosto", "setembro", "outubro", "novembro", "dezembro" }
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
        Console.WriteLine("Digite o dia:");
        setDia(int.Parse(Console.ReadLine()));
        Console.WriteLine("Digite o mês:");
        setMes(int.Parse(Console.ReadLine()));
        Console.WriteLine("Digite o ano:");
        setAno(int.Parse(Console.ReadLine()));
    }
}