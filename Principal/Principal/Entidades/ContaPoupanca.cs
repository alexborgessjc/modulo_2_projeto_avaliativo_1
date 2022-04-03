using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Principal.Enums;

namespace Principal.Entidades
{
    public class ContaPoupanca : Conta
    {        
        public ContaPoupanca(string id, string nome, string cpf, string endereco, double rendamensal, int numerodaconta,
            AgenciaEnum agencia, decimal saldoinicial)
                      : base(id, nome, cpf, endereco, rendamensal, numerodaconta, agencia, saldoinicial) { }

        public virtual decimal SimularRendimento(int meses, double rentabilidade)
        {
            double valordorendimento = meses * rentabilidade;

            return (decimal)valordorendimento;
        }
    }
}
