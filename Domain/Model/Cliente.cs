namespace Domain.Model
{
    public class Cliente : Pessoa
    {
        public float Saldo { get; private set; }

        public void SetSaldoInicial(string saldo)
        {
            if (float.TryParse(saldo, out var saldoConvertido) && saldoConvertido > 0)
                Saldo = saldoConvertido;
            else
                Validacoes.Add("Saldo não é valido");
        }

        public void SetSaldo(float saldo)
        {
            Saldo = saldo;
        }
    }
}
