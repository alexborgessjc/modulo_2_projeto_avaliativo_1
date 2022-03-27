using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Principal.Enums;

namespace Principal.Entidades
{
    public class Conta : EntidadeBase
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Endereco { get; private set; }
        public double RendaMensal { get; private set; }
        public int NumeroDaConta { get; private set; }
        public AgenciaEnum Agencia { get; private set; }
        public decimal SaldoInicial { get; private set; }
        public IList<Transacao> Transacoes { get; private set; }

        public Conta(string id, string nome, string cpf, string endereco, double rendamensal,
            int numerodaconta, AgenciaEnum agencia, decimal saldoinicial) : base(id)
        {
            Nome = nome;
            if (IsCpf(cpf))
            {
                Cpf = cpf;
            }
            else
            {
                throw new InvalidOperationException("CPF inválido!");
            }            
            Endereco = endereco;
            RendaMensal = rendamensal;
            NumeroDaConta = numerodaconta;
            Agencia = agencia;
            SaldoInicial = saldoinicial;

            Transacoes = new List<Transacao>();
        }               

        public decimal CalcularTotal(TipoCategoriaEnum tipoCategoria, DateOnly data)
            => Transacoes
                .Where(trans => trans.Data <= data && trans.Categoria.TipoCategoria == tipoCategoria)
                .Sum(trans => trans.Valor);

        public virtual decimal CalcularSaldo(DateOnly data)
        {
            IEnumerable<Transacao>? transacoes = Transacoes.Where(trans => trans.Data <= data);

            return SaldoInicial +
                transacoes.Where(trans => trans.Categoria.TipoCategoria == TipoCategoriaEnum.Receita).Sum(trans => trans.Valor) -
                transacoes.Where(trans => trans.Categoria.TipoCategoria == TipoCategoriaEnum.Despesa).Sum(trans => trans.Valor);
        }
        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
