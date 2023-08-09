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
        var pessoa = Identificacao();
        ExibirMenu(pessoa);
    }

    static Pessoa Identificacao()
    {
        var pessoa = new Pessoa();

        Console.WriteLine("Seu número de identificação:");
        pessoa.Id = int.Parse(Console.ReadLine());

        Console.WriteLine("Seu nome:");
        pessoa.Nome = Console.ReadLine();

        Console.WriteLine("Seu CPF:");
        pessoa.Cpf = Console.ReadLine();
        Console.Clear();
        
        return pessoa;
    }

    static void ExibirMenu(Pessoa pessoa)
    {
        var opcaoSelecionada = SelecionarOpcao(pessoa);

        if (opcaoSelecionada == "3")
            return;

        Console.WriteLine(Constantes.Opcoes.Where(x => x.Key == opcaoSelecionada).First().Value);
    }

    static string SelecionarOpcao(Pessoa pessoa)
    {
        var opcaoSelecionada = "";

        while (!Constantes.Opcoes.ContainsKey(opcaoSelecionada))
        {
            Console.Clear();
            Console.WriteLine($"Como posso ajudar {pessoa.Nome}?");

            foreach (var opcao in Constantes.Opcoes)
                Console.WriteLine($"{opcao.Key} - {opcao.Value}");

            Console.WriteLine("----------");
            Console.WriteLine("Selecione uma opção:");

            opcaoSelecionada = Console.ReadLine();
        }

        return opcaoSelecionada;
    }
}