# Trabalho 1 - Gerenciamento de pacientes

Projeto em ASP.NET Core MVC, usando o cadastro de pacientes anterior como base.

## Implementado

- Estrutura MVC e página inicial.
- Classe Paciente com nome, CPF, telefone, endereço e data de nascimento.
- Data Annotations e validações de CPF, telefone e nascimento.
- Entity Framework Core com provedor PostgreSQL.
- AppDbContext com o conjunto Pacientes.
- Migration CriarTabelaPacientes para criar a tabela no banco.

## Executar

Requisitos: SDK .NET 10 e PostgreSQL. Abra o PowerShell na pasta do projeto:

```powershell
dotnet restore
dotnet tool restore
$env:ConnectionStrings__DefaultConnection = 'Host=localhost;Port=5432;Database=trabalho_dev_web;Username=postgres;Password=SUA_SENHA'
dotnet ef database update
dotnet run --project Trabalho1DevWebNet.csproj --urls http://localhost:5080
```

Troque SUA_SENHA pela senha do seu PostgreSQL apenas no terminal local. Não coloque a senha real nos arquivos enviados ao GitHub. A variável vale para essa sessão do PowerShell. O usuário do banco precisa de permissão para criar o banco e a tabela.

Abra http://localhost:5080. A página inicial ainda não consulta pacientes. Em uma nova instalação, aplique a migration com o comando acima após configurar a conexão. A aplicação não altera o banco automaticamente ao iniciar.

## Entendendo esta etapa

Models/Paciente.cs define os dados e as validações. Required indica um campo obrigatório, StringLength limita os textos e Id identifica cada paciente.

Data/AppDbContext.cs representa o acesso ao banco. DbSet<Paciente> permite acessar os pacientes. Program.cs registra esse contexto e UseNpgsql seleciona o PostgreSQL.

A migration descreve a criação da tabela Pacientes: Up cria a tabela e Down desfaz essa operação. O snapshot registra o modelo usado pelo EF Core para comparar alterações futuras. Criar uma migration gera arquivos; database update aplica essas alterações no banco.

## Verificações

```powershell
dotnet build Trabalho1DevWebNet.csproj
dotnet run --project Tests/Validacoes.csproj
dotnet ef migrations has-pending-model-changes
```

As verificações acima não precisam acessar o PostgreSQL. A migration também foi aplicada no PostgreSQL local em 12/09/2026: banco trabalho_dev_web e tabela Pacientes criados. A listagem de migrations confirmou a aplicação. As operações de cadastro serão verificadas quando forem implementadas.

## Próximas etapas

1. Inserir pacientes iniciais com SeedingService.
2. Criar as telas para listar, inserir, editar e remover pacientes.
