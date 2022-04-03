using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Principal.Entidades;
using Principal.Models;

namespace Principal.Interfaces
{
    public interface IMovimentacaoContaCorrenteRepository : IBaseRepository<ContaCorrente>
    {
        void AdicionarTransacao(string id, Transacao transacao);
        decimal RetornarSaldoConta(string id, DateOnly data);
        decimal RetornarTotalDespesas(string id, DateOnly data);
        decimal RetornarTotalReceitas(string id, DateOnly data);
        decimal RetornarSaldoInicial(string id);        
        IEnumerable<TransacoesPorCategoriaModel> RetornarTransacoesAgrupadasPorCategorias(string numeroConta, DateOnly data);
    }
}
