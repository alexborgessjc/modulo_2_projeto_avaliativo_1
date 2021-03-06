using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Principal.Interfaces;
using Principal.Repositories;
using Principal.Models;
using Principal.Enums;

namespace Principal.Entidades
{
    public class MovimentacaoContaRepository : BaseRepository<Conta>, IMovimentacaoContaRepository
    {
        #region Funcionalidades Conta
        
        public void AdicionarTransacao(string id, Transacao transacao)
            => RetornarElemento(id).Transacoes.Add(transacao);
        public decimal RetornarTotalDespesas(string id, DateOnly data)
            => RetornarElemento(id).CalcularTotal(TipoCategoriaEnum.Despesa, data);
        public decimal RetornarTotalReceitas(string id, DateOnly data)
            => RetornarElemento(id).CalcularTotal(TipoCategoriaEnum.Receita, data);
        public decimal RetornarSaldoInicial(string id)
            => RetornarElemento(id).SaldoInicial;
        public decimal RetornarSaldoConta(string id, DateOnly data)
            => RetornarElemento(id).CalcularSaldo(data);
        public IEnumerable<TransacoesPorCategoriaModel> RetornarTransacoesAgrupadasPorCategorias(string id, DateOnly data)
           => RetornarElemento(id).Transacoes.GroupBy(trans => trans.Categoria)
                .Select(g => new TransacoesPorCategoriaModel()
                {
                    Categoria = g.Key,
                    Transacoes = g.ToList()
                });    
        #endregion          
    }
}
