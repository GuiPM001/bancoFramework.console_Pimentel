using Dapper;
using Domain.Model;
using System.Data;
using System.Data.SqlClient;

namespace Repository
{
    public static class ClienteRepository
    {
        private readonly static string connectionString = "Server=localhost,1433;Database=master;User Id=sa;Password=1q2w3e4r@#$;";

        private readonly static string OBTER_CLIENTE_PELO_ID = @"
            SELECT
                Id,
                Nome,
                NumeroCpf,
                Saldo
            FROM dbo.Clientes
            WHERE Id = @Id";

        private readonly static string SALVAR_CLIENTE = @"
            INSERT INTO dbo.Clientes (Id, Nome, NumeroCpf, Saldo)
            VALUES (@Id, @Nome, @NumeroCpf, @Saldo)";

        private readonly static string ATUALIZAR_SALDO = @"
            UPDATE dbo.Clientes
            SET Saldo = @NovoSaldo
            WHERE Id = @Id";

        public static Cliente ObterClientePeloId(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Id", id, DbType.Int32);

                var cliente = sqlConnection.QuerySingleOrDefault<Cliente>(OBTER_CLIENTE_PELO_ID, parametros);
                return cliente;
            }
        }

        public static void SalvarCliente(Cliente cliente)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Id", cliente.Id, DbType.Int32);
                parametros.Add("@Nome", cliente.Nome, DbType.String);
                parametros.Add("@NumeroCpf", cliente.NumeroCpf, DbType.StringFixedLength);
                parametros.Add("@Saldo", cliente.Saldo, DbType.Double);

                sqlConnection.Execute(SALVAR_CLIENTE, parametros);
            }
        }

        public static void AtualizarSaldo(int id, float saldo)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Id", id, DbType.Int32);
                parametros.Add("@NovoSaldo", saldo, DbType.Double);

                sqlConnection.Execute(ATUALIZAR_SALDO, parametros);
            }
        }
    }
}