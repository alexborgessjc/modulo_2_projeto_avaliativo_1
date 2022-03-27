using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Principal.Entidades;
using Principal.Models;

namespace Principal.Interfaces
{
    public interface IMovimentacaoContaInvestimentoRepository : IBaseRepository<ContaInvestimento>
    {
        void AdicionarTransacao(string id, Transacao transacao);
        decimal RetornarSaldoConta(string id, DateOnly data);
        decimal RetornarTotalDespesas(string id, DateOnly data);
        decimal RetornarTotalReceitas(string id, DateOnly data);
        decimal RetornarSaldoInicial(string id);
        decimal SimularInvestimentoLCI(string id, double valor, int tempo, double cdi);
        decimal SimularInvestimentoCDB(string id, double valor, int tempo);
        decimal SimularInvestimentoLCA(string id, double valor, int tempo, double cdi);
        IEnumerable<TransacoesPorCategoriaModel> RetornarTransacoesAgrupadasPorCategorias(string numeroConta, DateOnly data);
    }
}
