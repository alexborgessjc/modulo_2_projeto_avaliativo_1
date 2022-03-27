using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Principal.Entidades;
using Principal.Enums;
using Principal.Interfaces;
using Principal.Models;

namespace Sistema
{
    public class AplicacaoFinanceira
    {
        private readonly IMovimentacaoContaInvestimentoRepository _movimentacaoContaInvestimentoRepository;
        private readonly IMovimentacaoContaRepository _movimentacaoContaRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public AplicacaoFinanceira(IMovimentacaoContaRepository movimentacaoContaRepository,
                                    IMovimentacaoContaInvestimentoRepository movimentacaoContaInvestimentoRepository,
                                   ICategoriaRepository categoriaRepository)
        {
            _movimentacaoContaRepository = movimentacaoContaRepository;
            _movimentacaoContaInvestimentoRepository = movimentacaoContaInvestimentoRepository;
            _categoriaRepository = categoriaRepository;            
        }

        public void CriarCategoria(string id, string descricao, TipoCategoriaEnum tipo)
        {
            Console.WriteLine($"Criando categoria {descricao} do tipo {tipo}");

            Categoria? categoria = new Categoria(id, descricao, tipo);
            _categoriaRepository.AdicionarElemento(categoria);

            Console.WriteLine($"Categoria {descricao} criada com sucesso");
        }

        public void CriarConta(string id, string nome, string cpf, string endereco, double rendamensal, int numerodaconta,
            AgenciaEnum agencia, decimal saldoinicial, double chequeespecial = 0, decimal rendimento = 0)
        {
            Console.WriteLine($"Criando conta corrente numero {numerodaconta}");

            Conta? conta = rendimento > 0 ? new ContaCorrente(id, nome, cpf, endereco, rendamensal, numerodaconta, agencia, saldoinicial, chequeespecial = (rendamensal * 10) / 100, rendimento)
                                       : new Conta(id, nome, cpf, endereco, rendamensal, numerodaconta, agencia, saldoinicial);
            _movimentacaoContaRepository.AdicionarElemento(conta);

            Console.WriteLine($"Conta numero {numerodaconta} criada com sucesso");
        }
        public void CriarContaPoupanca(string id, string nome, string cpf, string endereco, double rendamensal, int numerodaconta,
            AgenciaEnum agencia, decimal saldoinicial)
        {
            Console.WriteLine($"Criando conta poupança número {numerodaconta}");

            Conta? conta = new ContaPoupanca(id, nome, cpf, endereco, rendamensal, numerodaconta, agencia, saldoinicial);
            _movimentacaoContaRepository.AdicionarElemento(conta);

            Console.WriteLine($"Conta poupança número {numerodaconta} criada com sucesso");
        }
        public void CriarContaInvestimento(string id, string nome, string cpf, string endereco, double rendamensal, int numerodaconta,
            AgenciaEnum agencia, decimal saldoinicial, TipoInvestimentoEnum tipoinvestimento)
        {
            Console.WriteLine($"Criando conta investimento numero {numerodaconta}");

            ContaInvestimento? conta = new ContaInvestimento(id, nome, cpf, endereco, rendamensal, numerodaconta, agencia, saldoinicial, tipoinvestimento);
            _movimentacaoContaInvestimentoRepository.AdicionarElemento(conta);

            Console.WriteLine($"Conta investimento número {numerodaconta} criada com sucesso");
        }
        public void SimularInvestimentoLCI(string id, double valor, int tempo, double cdi)
        {
            ContaInvestimento? conta = _movimentacaoContaInvestimentoRepository.RetornarElemento(id);
            decimal valorfinal = _movimentacaoContaInvestimentoRepository.SimularInvestimentoLCI(id, valor, tempo, cdi);

            Console.WriteLine($"A minha conta investimento {conta.NumeroDaConta} tem o valor simulado de investimento de {valorfinal:N2}");
        }
        public void SimularInvestimentoLCA(string id, double valor, int tempo, double cdi)
        {
            ContaInvestimento? conta = _movimentacaoContaInvestimentoRepository.RetornarElemento(id);
            decimal valorfinal = _movimentacaoContaInvestimentoRepository.SimularInvestimentoLCA(id, valor, tempo, cdi);

            Console.WriteLine($"A minha conta investimento {conta.NumeroDaConta} tem o valor simulado de investimento de {valorfinal:N2}");
        }
        public void SimularInvestimentoCDB(string id, double valor, int tempo)
        {
            ContaInvestimento? conta = _movimentacaoContaInvestimentoRepository.RetornarElemento(id);
            decimal valorfinal = _movimentacaoContaInvestimentoRepository.SimularInvestimentoCDB(id, valor, tempo);

            Console.WriteLine($"A minha conta investimento {conta.NumeroDaConta} tem o valor simulado de investimento de {valorfinal:N2}");
        }

        public void AdicionarTransacaoConta(string id, string descricao, decimal valor, DateOnly data, string categoriaId, string contaId)
        {
            Transacao? transacao = AdicionarTransacaoConta(id, descricao, valor, data, categoriaId);

            _movimentacaoContaRepository.AdicionarTransacao(contaId, transacao);
        }

        public void RetornarSaldoConta(string id, DateOnly data)
        {
            Conta? conta = _movimentacaoContaRepository.RetornarElemento(id);
            decimal saldo = _movimentacaoContaRepository.RetornarSaldoConta(id, data);

            Console.WriteLine($"O saldo de minha conta {conta.NumeroDaConta} é de R${saldo:N2}");
        }

        public void RetornarTransacoesPorCategorias(string contaId, DateOnly data)
        {
            IEnumerable<Principal.Models.TransacoesPorCategoriaModel>? transacoesPorCategoria = _movimentacaoContaRepository.RetornarTransacoesAgrupadasPorCategorias(contaId, data);

            foreach (Principal.Models.TransacoesPorCategoriaModel? transacaoPorCategoria in transacoesPorCategoria)
            {
                Console.WriteLine($"A categoria {transacaoPorCategoria.Categoria.Nome} tem {transacaoPorCategoria.Transacoes.Count()} transações");

                foreach (Transacao? transacaoCat in transacaoPorCategoria.Transacoes)
                {
                    Console.WriteLine($"Transação: {transacaoCat.Descricao}, Valor: R${transacaoCat.Valor}");
                }
            }
        }

        private Transacao AdicionarTransacaoConta(string id, string descricao, decimal valor, DateOnly data, string categoriaId)
        {
            Categoria? categoria = _categoriaRepository.RetornarElemento(categoriaId);

            Console.WriteLine($"Criando um {categoria.TipoCategoria} no valor de R${valor:N2} - Descrição: {descricao} ");

            Transacao? transacao = new Transacao(id, descricao, valor, data, categoria);

            Console.WriteLine($"{categoria.TipoCategoria} no valor de R${valor:N2} - Descrição: {descricao} criado com sucesso");

            return transacao;
        }
        public void SimularRendimento(string id, DateOnly data, int meses, double rentabilidade)
        {
            Conta? conta = _movimentacaoContaRepository.RetornarElemento(id);
            decimal saldo = _movimentacaoContaRepository.RetornarSaldoConta(id, data);

            double rendimento = Convert.ToDouble(saldo) * rentabilidade;

            Console.WriteLine($"A rentabilidade da conta {conta.NumeroDaConta} é de {rendimento}");
        }
    }
}
