using Application;
using Domain;
using Domain.Model;

internal class Program
{
    private static void Main(string[] args)
    {   
        Cliente cliente;

        do
        {
            Console.Clear();
            Console.WriteLine("Seja bem vindo ao banco Framework");
            Console.WriteLine("Por favor, identifique-se");
            Console.WriteLine("");

            cliente = Identificacao();

            if (cliente.Validacoes.Count > 0)
            {
                Console.WriteLine();

                foreach (var validacao in cliente.Validacoes)
                    Console.WriteLine(validacao);

                Console.ReadKey();
            }

        } while (cliente.Validacoes.Count > 0);

        Console.Clear();
        ExibirMenu(cliente);
    }

    static Cliente Identificacao()
    {
        var cliente = new Cliente();

        Console.WriteLine("Seu número de identificação:");
        cliente.SetId(Console.ReadLine());

        Console.WriteLine("Seu nome:");
        cliente.Nome = Console.ReadLine();

        Console.WriteLine("Seu CPF:");
        cliente.SetCpf(Console.ReadLine());

        Console.WriteLine("Seu saldo:");
        cliente.SetSaldoInicial(Console.ReadLine());

        return cliente;
    }

    static void ExibirMenu(Cliente cliente)
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

            Console.WriteLine($"Saldo atual é {cliente.Saldo}\n");

            ExibirMenu(cliente);
        }

        return;
    }

    static string SelecionarOpcao(Cliente cliente)
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