using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Principal.Enums;

namespace Principal.Entidades
{
    public class ContaCorrente : Conta
    {
        public decimal Rendimento { get; private set; }
        public double ChequeEspecial { get; private set; }

        public ContaCorrente(string id, string nome, string cpf, string endereco, double rendamensal, int numerodaconta, 
            AgenciaEnum agencia, decimal saldoinicial, double chequeespecial, decimal rendimento)
                      : base(id, nome, cpf, endereco, rendamensal, numerodaconta, agencia, saldoinicial)
            => Rendimento = rendimento;

        public override decimal CalcularSaldo(DateOnly data)
        {
            decimal saldo = base.CalcularSaldo(data);

            return saldo + (saldo * Rendimento / 100);
        }
    }
}
