using Application;
using Domain;
using Domain.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");
        var cliente = Identificacao();
        ExibirMenu(cliente);
    }

    static Cliente Identificacao()
    {
        var cliente = new Cliente();

        Console.WriteLine("Seu número de identificação:");
        cliente.Id = int.Parse(Console.ReadLine());

        Console.WriteLine("Seu nome:");
        cliente.Nome = Console.ReadLine();

        Console.WriteLine("Seu CPF:");
        cliente.Cpf = Console.ReadLine();

        Console.WriteLine("Seu saldo:");
        cliente.Saldo = float.Parse(Console.ReadLine());
        Console.Clear();

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

            cliente.Saldo = opcaoSelecionada == "1"
                ? Calculo.Soma(cliente.Saldo, valor)
                : Calculo.Subracao(cliente.Saldo, valor);

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