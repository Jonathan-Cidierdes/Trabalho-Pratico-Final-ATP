using System;

namespace Cadastro_Alunos
{
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
        public bool setAno(int ano)
        {
            bool valido = false;
            if (ano > 1900 || ano == 0)
            {
                this.ano = ano;
                valido = true;
            }
            return valido;
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
            if ((getDia() >= 0 && getDia() <= 31) && (getMes() >= 0 && getMes() <= 12) && (getAno() > 1900 || getAno() == 0)) valida = true;
            return valida;
        }
        public bool dataValida(int dia, int mes, int ano)
        {
            bool valida = false;
            if ((dia >= 1 && dia <= 31) && (mes >= 1 && mes <= 12) && (ano > 1900)) valida = true;
            return valida;
        }
        public string mesExtenso()
        {
            string[] nomeMes = { "janeiro", "fevereiro", "março", "abril", "maio", "junho", "julho", "agosto", "setembro", "outubro", "novembro", "dezembro" };
            return nomeMes[getMes() - 1];
        }
        public string mesExtenso(int mes)
        {
            string[] nomeMes = { "janeiro", "fevereiro", "março", "abril", "maio", "junho", "julho", "agosto", "setembro", "outubro", "novembro", "dezembro" };
            return nomeMes[mes - 1];
        }
        public int diasMes()
        {
            int[] qtDias = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if ((getMes() == 2) && (getAno() % 4 == 0) && ((getAno() % 100 != 0) || (getAno() % 400 == 0)))
                qtDias[1] = 29;
            return qtDias[getMes() - 1];
        }
        public int diasMes(int mes, int ano)
        {
            int[] qtDias = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if ((mes == 2) && (ano % 4 == 0) && ((ano % 100 != 0) || (ano % 400 == 0)))
                qtDias[1] = 29;
            return qtDias[mes - 1];
        }

        public void escrevaData()
        {
            Console.Write(getDia() + "/" + getMes() + "/" + getAno());
        }
        public void leiaData()
        {
            bool valida = false;
            do
            {
                Console.Write("Digite o dia: ");
                dia = int.Parse(Console.ReadLine());
                Console.Write("Digite o mês:");
                mes = int.Parse(Console.ReadLine());
                Console.Write("Digite o ano:");
                ano = int.Parse(Console.ReadLine());
                valida = (dataValida(dia, mes, ano)) && (dia <= diasMes(mes, ano));
                if (!valida) Console.WriteLine("\n\n--- Data inválida! ---\nPor favor insira uma data válida:");
            } while (!valida);
            setData(dia, mes, ano);
        }
    }
}