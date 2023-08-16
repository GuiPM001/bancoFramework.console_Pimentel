using Application;
using Domain;
using Domain.Model;
using Repository;

internal class Program
{
    private static void Main(string[] args)
    {
        var cliente = Identificacao();

        ExibirMenu(cliente);
    }

    private static Cliente Identificacao()
    {
        Cliente cliente;

        do
        {
            Console.Clear();
            Console.WriteLine("Seja bem vindo ao banco Framework");
            Console.WriteLine("Por favor, identifique-se");
            Console.WriteLine("");

            Console.WriteLine("Seu número de identificação:");
            var id = Console.ReadLine();

            if (int.TryParse(id, out var idConvertido))
            {
                var clienteExistente = ClienteRepository.ObterClientePeloId(idConvertido);

                if (clienteExistente != null)
                {
                    Console.Clear();
                    Console.WriteLine($"Nome: {clienteExistente.Nome}");
                    Console.WriteLine($"CPF: {clienteExistente.NumeroCpf}");
                    Console.WriteLine($"Saldo: {clienteExistente.Saldo}");
                    Console.WriteLine();
                    return clienteExistente;
                }
            }

            cliente = CadastrarNovoCliente(id);

        } while (cliente.Validacoes.Count > 0);

        return cliente;
    }

    private static Cliente CadastrarNovoCliente(string id)
    {
        var cliente = new Cliente();
        cliente.SetId(id);

        Console.WriteLine("Seu nome:");
        cliente.Nome = Console.ReadLine();

        Console.WriteLine("Seu CPF:");
        cliente.SetCpf(Console.ReadLine());

        Console.WriteLine("Seu saldo:");
        cliente.SetSaldoInicial(Console.ReadLine());

        Console.Clear();

        if (cliente.Validacoes.Count == 0)
            ClienteRepository.SalvarCliente(cliente);

        else
        {
            Console.WriteLine();

            foreach (var validacao in cliente.Validacoes)
                Console.WriteLine(validacao);

            Console.ReadKey();
        }

        return cliente;
    }

    private static void ExibirMenu(Cliente cliente)
    {
        var opcaoSelecionada = SelecionarOpcao(cliente);

        if (opcaoSelecionada != "3")
        {
            Console.Clear();
            Console.WriteLine("Digite o valor:");
            var valor = float.Parse(Console.ReadLine());

            var saldoFinal = opcaoSelecionada == "1"
                ? Calculo.Soma(cliente.Saldo, valor)
                : Calculo.Subracao(cliente.Saldo, valor);

            cliente.SetSaldo(saldoFinal);
            ClienteRepository.AtualizarSaldo(cliente.Id, saldoFinal);

            Console.WriteLine($"Saldo atual é {cliente.Saldo}\n");

            ExibirMenu(cliente);
        }

        return;
    }

    private static string SelecionarOpcao(Cliente cliente)
    {
        var opcaoSelecionada = "";

        while (!Constantes.Opcoes.ContainsKey(opcaoSelecionada))
        {
            Console.WriteLine($"Como posso ajudar {cliente.Nome}?");

            foreach (var opcao in Constantes.Opcoes)
                Console.WriteLine($"{opcao.Key} - {opcao.Value}");

            Console.WriteLine("----------");
            Console.WriteLine("Selecione uma opção:");

            opcaoSelecionada = Console.ReadLine();
            Console.Clear();
        }

        return opcaoSelecionada;
    }
}