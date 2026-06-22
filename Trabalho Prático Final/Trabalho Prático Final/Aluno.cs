using System;

namespace Cadastro_Alunos
{
    class Aluno
    {
        private string nome;
        private string cpf;
        private Data nascimento = new Data();
        private Data cadastro = new Data();
        private double nota = 0;
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

        public void setCadastro(int dia, int mes, int ano)
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

        public bool setNota(double nota)
        {
            bool valido = false;
            if (nota >= 0 && nota <= 100)
            {
                this.nota = nota;
                valido = true;
            }
            return valido;
        }
        public double getNota()
        {
            return nota;
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

            Console.Write("\nDigite o CPF: ");
            setCpf(Console.ReadLine());

            Console.WriteLine("\nPara inserir a data de nascimento...");
            nascimento.leiaData();

            Console.WriteLine("\nPara inserir a data de cadastro...");
            cadastro.leiaData();

            Console.Write("\nDigite a nota do aluno [0...100]: ");
            double nota = double.Parse(Console.ReadLine());
            bool valido = setNota(nota);
            while (!valido)
            {
                Console.Write("\n--- Nota inválida! ---\nDigite a nota do aluno [0...100]: ");
                nota = double.Parse(Console.ReadLine());
                valido = setNota(nota);
            }
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
            Console.WriteLine($"\nCPF: {getCpf()}");
            Console.WriteLine($"Nota: {getNota()}\n");
        }
    }
}