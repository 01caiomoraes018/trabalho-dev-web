# Trabalho 1 - Gerenciamento de pacientes

Trabalho de Desenvolvimento Web com .NET, feito em ASP.NET Core MVC, Entity Framework Core e PostgreSQL.

Permite cadastrar, listar, editar e excluir pacientes, com validações de nome, CPF, telefone, endereço e data de nascimento. Inclui migration e pacientes de exemplo.

## Como executar

Requisitos: SDK .NET 10 e PostgreSQL em execução. Na pasta do projeto, abra o PowerShell:

```powershell
dotnet restore
dotnet tool restore
$env:ConnectionStrings__DefaultConnection = 'Host=localhost;Port=5432;Database=trabalho_dev_web;Username=postgres;Password=SUA_SENHA'
dotnet ef database update
$env:ASPNETCORE_ENVIRONMENT = 'Development'
dotnet run --project Trabalho1DevWebNet.csproj --urls http://localhost:5080
```

Substitua `SUA_SENHA` somente no terminal, sem salvar a senha real no GitHub. O usuário do PostgreSQL precisa ter permissão para criar o banco e a tabela.

Acesse http://localhost:5080 e clique em **Pacientes**. Em Development, dois exemplos são inseridos quando a tabela está vazia; se todos forem excluídos, voltam na próxima inicialização.

## Testes

```powershell
dotnet build
dotnet run --project Tests/Validacoes.csproj
```

O roteiro de testes e a conferência dos requisitos estão em [TESTES.md](TESTES.md).
