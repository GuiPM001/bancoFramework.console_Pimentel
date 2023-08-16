using CpfCnpjLibrary;

namespace Domain.Model
{
    public class Pessoa
    {
        public Pessoa()
        {
            Validacoes = new List<string>();
        }

        public int Id { get; private set; }
        public string Nome { get; set; }
        public string NumeroCpf { get; private set; }
        public List<string> Validacoes { get; private set; }

        public void SetId(string id)
        {
            if (int.TryParse(id, out var idConvertido))
                Id = idConvertido;
            else
                Validacoes.Add("Identificador não é valido");
        }

        public void SetCpf(string cpf)
        {
            if (Cpf.Validar(cpf))
                NumeroCpf = cpf;
            else
                Validacoes.Add("CPF digitado não é válido");
        }
    }
}
