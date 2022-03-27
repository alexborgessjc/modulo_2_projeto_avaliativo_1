using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Principal.Enums;

namespace Principal.Entidades
{
    public class ContaInvestimento : Conta
    {  

        public ContaInvestimento(string id, string nome, string cpf, string endereco, double rendamensal, int numerodaconta,
            AgenciaEnum agencia, decimal saldoinicial, TipoInvestimentoEnum tipoinvestimento)
                      : base(id, nome, cpf, endereco, rendamensal, numerodaconta, agencia, saldoinicial) { }
        public virtual decimal SimularInvestimentoLCI(double valor,int tempo,double cdi)
        {
            double rendimento;

            if (tempo < 6)
            {
                throw new InvalidOperationException("O Tempo mínimo é de 6 meses!");
            }
            else
            {
                rendimento = (valor * (tempo + cdi * (double)TipoInvestimentoEnum.LCI));                
            }

            return (decimal)rendimento;

        }
        public virtual decimal SimularInvestimentoCDB(double valor, int tempo)
        {
            double rendimento;

            if (tempo < 36)
            {
                throw new InvalidOperationException("O Tempo mínimo é de 36 meses!");
            }
            else
            {
                rendimento = (valor * (tempo * (double)TipoInvestimentoEnum.LCI));
            }
            return (decimal)rendimento;
        }
        public virtual decimal SimularInvestimentoLCA(double valor, int tempo, double cdi)
        {
            double rendimento;

            if (tempo < 12)
            {
                throw new InvalidOperationException("O Tempo mínimo é de 12 meses!");
            }
            else
            {
                rendimento = (valor * (tempo + cdi * (double)TipoInvestimentoEnum.LCA));
            }
            return (decimal)rendimento;            
        }
    }   
}
