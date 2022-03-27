using Microsoft.Extensions.DependencyInjection;
using Principal.Entidades;
using Principal.Enums;
using Principal.Interfaces;
using Sistema;

Console.WriteLine("Modulo 2 - Projeto 1!");
Console.WriteLine("----------------------------------------");
#region Resolvendo Injeção de Dependencia

var serviceCollection = new ServiceCollection();
serviceCollection.AddScoped<ICategoriaRepository, CategoriaRepository>();
serviceCollection.AddScoped<IMovimentacaoContaRepository, MovimentacaoContaRepository>();
serviceCollection.AddScoped<IMovimentacaoContaInvestimentoRepository, MovimentacaoContaInvestimentoRepository>();
var serviceProvider = serviceCollection.BuildServiceProvider();
var _movimentacaoContaRepository = serviceProvider.GetService<IMovimentacaoContaRepository>();
var _movimentacaoContaInvestimentoRepository = serviceProvider.GetService<IMovimentacaoContaInvestimentoRepository>();
var _categoriaRepository = serviceProvider.GetService<ICategoriaRepository>();

var _aplicacaoFinanceira = new AplicacaoFinanceira(
                _movimentacaoContaRepository,
                _movimentacaoContaInvestimentoRepository,
                _categoriaRepository);

#endregion
#region Funcionalidades Categoria

Console.WriteLine("Criação de Categoria");
Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarCategoria("1", "Depósito", TipoCategoriaEnum.Receita);

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarCategoria("2", "Internet", TipoCategoriaEnum.Despesa);

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarCategoria("3", "Água", TipoCategoriaEnum.Despesa);

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarCategoria("4", "Luz", TipoCategoriaEnum.Despesa);

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarCategoria("5", "IPTU", TipoCategoriaEnum.Despesa);

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarCategoria("6", "Financiamento", TipoCategoriaEnum.Despesa);

Console.WriteLine("----------------------------------------");

#endregion
#region Funcionalidades Conta Poupança
Console.WriteLine("Criação da Conta Poupança");
Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarContaPoupanca("1", "Alex", "51703936019", "Rua Dev Front", 3000, 123456, Principal.Enums.AgenciaEnum.Biguaçu, 1000);
Console.WriteLine("----------- Saldo da Conta Poupança criada 1 -----------");
_aplicacaoFinanceira.RetornarSaldoConta("1", DateOnly.FromDateTime(DateTime.Now));

#endregion
#region Funcionalidades Conta Investimento
Console.WriteLine("----------------------------------------");
Console.WriteLine("Criação da Conta Investimento");
Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarContaInvestimento("1", "Alex", "51703936019", "Rua Dev Front", 3000, 123456, Principal.Enums.AgenciaEnum.Biguaçu, 1000, Principal.Enums.TipoInvestimentoEnum.LCA);
Console.WriteLine("----------- Saldo da Conta Investimento criada 1 -----------");
_aplicacaoFinanceira.RetornarSaldoConta("1", DateOnly.FromDateTime(DateTime.Now));
Console.WriteLine("----------------------------------------");
Console.WriteLine("Simulação de Investimento");
Console.WriteLine("----------------------------------------");
Console.WriteLine("--------------- LCI --------------");
_aplicacaoFinanceira.SimularInvestimentoLCI("1", 1000, 7,0.10);
Console.WriteLine("--------------- LCA --------------");
_aplicacaoFinanceira.SimularInvestimentoLCA("1", 1000, 13, 0.10);
Console.WriteLine("--------------- CDB --------------");
_aplicacaoFinanceira.SimularInvestimentoCDB("1", 1000, 37);

#endregion
#region Funcionalidades Conta
Console.WriteLine("----------------------------------------");
Console.WriteLine("Criação da Conta Corrente");
Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarConta("1", "Alex", "51703936019", "Rua Dev Front", 3000, 123456, Principal.Enums.AgenciaEnum.Biguaçu, 1000);
Console.WriteLine("----------- Saldo da Conta criada 1 -----------");
_aplicacaoFinanceira.RetornarSaldoConta("1", DateOnly.FromDateTime(DateTime.Now));
Console.WriteLine("----------- Simula Rendimento na Conta -----------");
_aplicacaoFinanceira.SimularRendimento("1", DateOnly.FromDateTime(DateTime.Now),2,0.005);

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.CriarConta("2", "Dariel", "91994671009","Rua Dev Back", 5000, 654321, Principal.Enums.AgenciaEnum.Florianópolis, 2000);
Console.WriteLine("----------- Saldo da Conta criada 2 -----------");
_aplicacaoFinanceira.RetornarSaldoConta("2", DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("----------------------------------------");
_aplicacaoFinanceira.CriarConta("3", "Raffa", "36599908098", "Rua Dev Full", 4000, 159753, Principal.Enums.AgenciaEnum.São_José, 2340);
Console.WriteLine("----------- Saldo da Conta criada 3 -----------");
_aplicacaoFinanceira.RetornarSaldoConta("3", DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("----------------------------------------");
Console.WriteLine("---------- Transações para conta -------");

_aplicacaoFinanceira.AdicionarTransacaoConta("1", "Cobro salário", 1500, DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), "1", "1");

_aplicacaoFinanceira.RetornarSaldoConta("1", DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.AdicionarTransacaoConta("2", "Pagamento aluguel", 500, DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), "2", "1");

_aplicacaoFinanceira.RetornarSaldoConta("1", DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.AdicionarTransacaoConta("3", "Compra mercado", 100, DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), "3", "1");

_aplicacaoFinanceira.RetornarSaldoConta("1", DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.AdicionarTransacaoConta("4", "Compra mercado", 250, DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), "3", "1");

_aplicacaoFinanceira.RetornarSaldoConta("1", DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.AdicionarTransacaoConta("5", "Guardando dinheiro", 1500, DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), "3", "2");

_aplicacaoFinanceira.RetornarSaldoConta("2", DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("----------------------------------------");

Console.WriteLine("Funcionalidades Transação");
Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.RetornarTransacoesPorCategorias("1", DateOnly.FromDateTime(DateTime.Now));

Console.WriteLine("----------------------------------------");

Console.WriteLine("Simular Rendimento");
Console.WriteLine("----------------------------------------");

_aplicacaoFinanceira.SimularRendimento("1", DateOnly.FromDateTime(DateTime.Now),5,000.5);

Console.WriteLine("----------------------------------------");

#endregion
