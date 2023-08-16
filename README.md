# Projeto base para bancoframework.console

Meu primeiro projeto PDI(bancoframework.console) - c#

## Script BD

- Obter cliente pelo ID
```
SELECT
    Id,
    Nome,
    NumeroCpf,
    Saldo
FROM dbo.Clientes
WHERE Id = @Id
```

- Cadastrar novo cliente
```
INSERT INTO dbo.Clientes (Id, Nome, NumeroCpf, Saldo)
VALUES (@Id, @Nome, @NumeroCpf, @Saldo)
```

- Atualizar saldo
```
UPDATE dbo.Clientes
SET Saldo = @NovoSaldo
WHERE Id = @Id
```