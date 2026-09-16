# Trabalho 1 - Gerenciamento de pacientes

Projeto em ASP.NET Core MVC, usando o cadastro de pacientes anterior como base.

## Implementado

- Estrutura MVC e página inicial.
- Classe Paciente com nome, CPF, telefone, endereço e data de nascimento.
- Data Annotations e validações de CPF, telefone e nascimento.
- Entity Framework Core com provedor PostgreSQL.
- AppDbContext com o conjunto Pacientes.
- Migration CriarTabelaPacientes para criar a tabela no banco.
- SeedingService para inserir dois pacientes de exemplo quando a tabela estiver vazia.
- Listagem dos pacientes do banco, acessível pelo menu Pacientes.
- Formulário Novo paciente com validação no servidor e gravação no banco.
- Edição de pacientes pelo link Editar na listagem, com formulário preenchido e validação.
- Exclusão pelo link Excluir, com confirmação antes de remover o paciente.

## Executar

Requisitos: SDK .NET 10 e PostgreSQL. Abra o PowerShell na pasta do projeto:

```powershell
dotnet restore
dotnet tool restore
$env:ConnectionStrings__DefaultConnection = 'Host=localhost;Port=5432;Database=trabalho_dev_web;Username=postgres;Password=SUA_SENHA'
dotnet ef database update
$env:ASPNETCORE_ENVIRONMENT = 'Development'
dotnet run --project Trabalho1DevWebNet.csproj --urls http://localhost:5080
```

Troque SUA_SENHA pela senha do seu PostgreSQL apenas no terminal local. Não coloque a senha real nos arquivos enviados ao GitHub. A variável vale para essa sessão do PowerShell. O usuário do banco precisa de permissão para criar o banco e a tabela.

Abra http://localhost:5080 e clique em Pacientes no menu, ou acesse http://localhost:5080/Pacientes. Em uma nova instalação, aplique a migration com o comando acima após configurar a conexão. A aplicação não aplica migrations automaticamente ao iniciar.

No ambiente Development, a inicialização insere dois pacientes fictícios se a tabela estiver vazia. Se houver qualquer paciente, o seeding não adiciona nem altera registros. Se todos forem removidos, os exemplos serão inseridos novamente na próxima inicialização em Development. Em Production, o seeding não é executado.

## Entendendo esta etapa

Models/Paciente.cs define os dados e as validações. Required indica um campo obrigatório, StringLength limita os textos e Id identifica cada paciente.

Data/AppDbContext.cs representa o acesso ao banco. DbSet<Paciente> permite acessar os pacientes. Program.cs registra esse contexto e UseNpgsql seleciona o PostgreSQL.

A migration descreve a criação da tabela Pacientes: Up cria a tabela e Down desfaz essa operação. O snapshot registra o modelo usado pelo EF Core para comparar alterações futuras. Criar uma migration gera arquivos; database update aplica essas alterações no banco.

Data/SeedingService.cs recebe o contexto pelo construtor. O método Popula usa Any para verificar se já existe algum paciente, AddRange para preparar os exemplos e SaveChanges para gravá-los. Program.cs registra o serviço com AddScoped e cria um escopo para executá-lo em Development, conforme o modelo das aulas.

PacientesController consulta os pacientes ordenados por nome. A action Index envia a lista para Views/Pacientes/Index.cshtml, que usa foreach para montar a tabela. Se não houver pacientes, a página mostra uma mensagem.

O link Novo paciente abre o formulário. A action Create com GET mostra a página; com POST, verifica ModelState, salva os dados válidos e retorna à listagem. Em caso de erro, o formulário mantém os valores e apresenta as mensagens. O formulário usa token antifalsificação.

Um dos exemplos se chama Caio Moraes, com CPF, telefone, endereço e nascimento apenas de demonstração. A alteração também foi feita no exemplo já existente no banco local; o seeding não renomeia registros existentes automaticamente.

O link Editar abre os dados do paciente pelo ID. Ao salvar, a action Edit confere o ID e ModelState, atualiza os campos e retorna à lista. Cancelar volta à listagem sem salvar. Registros inexistentes retornam 404.

O link Excluir abre uma página com os dados do paciente. Apenas o POST de Confirmar exclusão remove o registro; o formulário inclui token antifalsificação. Cancelar volta à lista sem alterar o banco. Se o paciente não existir, a aplicação retorna 404.

## Verificações

```powershell
dotnet build Trabalho1DevWebNet.csproj
dotnet run --project Tests/Validacoes.csproj
dotnet ef migrations has-pending-model-changes
```

As verificações acima não precisam acessar o PostgreSQL. A migration também foi aplicada no PostgreSQL local em 12/09/2026: banco trabalho_dev_web e tabela Pacientes criados. A listagem de migrations confirmou a aplicação.

O seeding foi verificado no PostgreSQL local: tabela vazia antes da execução, dois pacientes após iniciar em Development e os mesmos dois após reiniciar. Em Production, os registros permaneceram inalterados. A página inicial respondeu normalmente nos três testes.

O cadastro foi testado por HTTP com PostgreSQL: dados válidos foram salvos e retornaram à listagem; campos vazios, CPF inválido e data futura foram recusados. O registro temporário de teste foi removido.

A edição foi testada por HTTP com PostgreSQL: alteração dos cinco campos mantendo o ID, formulário preenchido, cancelamento, campos inválidos sem mudança no banco, ID divergente e envio sem token recusados, além de registro inexistente. O registro temporário foi removido e os pacientes anteriores foram preservados.

A exclusão foi testada por HTTP com PostgreSQL usando um paciente temporário. Abrir a confirmação e cancelar preservaram os dados; confirmar removeu apenas esse paciente. Envios sem token ou com token inválido foram recusados e IDs inexistentes retornaram 404. Os pacientes anteriores foram preservados.

## Próximas etapas

1. Revisar navegação, mensagens e apresentação das telas.
2. Conferir o CRUD completo, os requisitos do trabalho e as instruções de execução.
