# Trabalho 1 - Gerenciamento de pacientes

Primeira etapa do trabalho em ASP.NET Core MVC, usando o projeto anterior de cadastro de pacientes como base.

## Implementado nesta etapa

- Estrutura MVC e página inicial.
- Classe Paciente com nome, CPF, telefone, endereço e data de nascimento.
- Data Annotations para campos obrigatórios, tamanhos e apresentação.
- Validações de CPF, telefone e nascimento reaproveitadas da base.

As validações adicionais ficam em Validation: o CPF é conferido pelos dígitos verificadores e a data não pode ser futura nem vazia. A validação de CPF não consulta emissão ou titularidade.

## Executar

Com o SDK .NET 10 instalado, abra o terminal nesta pasta:

```powershell
dotnet run --project Trabalho1DevWebNet.csproj --urls http://localhost:5080
```

Abra http://localhost:5080. Esta etapa ainda não precisa de PostgreSQL.

Para conferir a compilação e as validações reaproveitadas:

```powershell
dotnet build Trabalho1DevWebNet.csproj
dotnet run --project Tests/Validacoes.csproj
```

## Próximas etapas

1. Configurar Entity Framework Core, PostgreSQL e AppDbContext; criar e aplicar a migration.
2. Inserir pacientes iniciais com SeedingService.
3. Criar as telas para listar, inserir, editar e remover pacientes.

## Entendendo o código

Models/Paciente.cs define os dados e as regras de validação. Required indica um campo obrigatório e StringLength limita o tamanho dos textos. Id identifica cada paciente. Program.cs configura o MVC e a rota inicial; HomeController retorna a página Views/Home/Index.cshtml.

A classe ainda não salva pacientes: essa parte será feita com o contexto e o banco de dados.
