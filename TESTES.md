# Conferência do trabalho

## Requisitos do Trabalho 1

| Requisito | Onde está |
| --- | --- |
| Classe Paciente com nome, CPF, telefone, endereço e nascimento | Models/Paciente.cs |
| Data Annotations | Models/Paciente.cs e Validation |
| Migration e tabela no banco | Migrations; aplicada no PostgreSQL local |
| Pacientes iniciais | Data/SeedingService.cs |
| Listar, inserir, editar e remover | Controllers/PacientesController.cs e Views/Pacientes |

## Roteiro para testar

Prepare a conexão e execute os comandos do README. Use somente dados de demonstração.

1. Abra a página inicial e clique em Ver pacientes. Confira também o menu Pacientes.
2. Clique em Novo paciente e preencha: nome `Paciente de teste`, CPF `529.982.247-25`, telefone `(18) 99999-1111`, endereço `Rua de teste, 100` e nascimento `15/05/1995`.
3. Salve. O paciente deve aparecer na lista, em ordem por nome.
4. Clique em Editar nesse paciente. Os cinco campos devem estar preenchidos.
5. Troque o CPF por `11111111111` e salve. A página deve mostrar erro; o banco deve manter os dados anteriores. Confira também nome vazio e nascimento no futuro.
6. Corrija os dados, altere o endereço e salve. A lista deve mostrar a alteração sem criar outro paciente.
7. Abra Editar, altere um campo e clique em Cancelar. A mudança não deve ser salva.
8. Clique em Excluir. Confira os dados na confirmação e clique em Cancelar: o paciente deve continuar na lista.
9. Abra Excluir novamente e confirme. Somente o paciente de teste deve ser removido.

O CPF acima é usado apenas para testar o algoritmo de validação, sem consulta de emissão ou titularidade. O projeto não impede CPF repetido; essa regra não faz parte do enunciado fornecido.

## Verificação realizada em 16/09/2026

- Compilação: nenhum erro ou aviso.
- Verificações automáticas de validação: 18 aprovadas.
- Modelo e migration: nenhuma alteração pendente.
- Fluxo HTTP com PostgreSQL: criar, listar, editar e excluir o mesmo paciente temporário.
- Edição inválida: mensagens exibidas, valores preservados no formulário e banco inalterado.
- Cancelamento de edição e exclusão: dados preservados.
- POST sem token ou com token inválido na exclusão: recusado.
- ID inexistente: resposta 404; ID divergente na edição: resposta 400.
- Após os testes, os pacientes que já existiam no banco foram preservados.

## Revisão visual

Conferidas no navegador integrado as páginas inicial, listagem, cadastro, edição e confirmação de exclusão em 1280 × 800 e 375 × 812. Também foi conferida a mensagem de CPF inválido no cadastro em tela pequena, sem gravar o registro.

A tabela mantém CPF, telefone, data e ações sem quebra de linha. Em tela pequena, a rolagem fica dentro da tabela, sem aumentar a largura da página. O CSS usa versão no endereço para evitar exibir estilos antigos após uma atualização. Outros navegadores e aparelhos físicos não foram testados nesta revisão.

## Conferência final - 17/09/2026

Uma cópia limpa do projeto, sem bin e obj, foi restaurada e compilada com os pacotes disponíveis na máquina: nenhum erro ou aviso. As 18 verificações de validação passaram e o EF Core não encontrou diferenças entre o modelo e a migration.

Nessa cópia, foram repetidos os testes HTTP de cadastro, edição e fluxo completo de criação até exclusão no PostgreSQL local, incluindo dados inválidos, cancelamento, IDs inexistentes e token antifalsificação. Todos passaram; os registros temporários foram removidos e os pacientes anteriores foram preservados.

Para executar em outra máquina, extraia o projeto e siga o README: instale os requisitos, restaure os pacotes, configure a conexão local e aplique a migration. O banco de dados e a senha pessoal não fazem parte da entrega.
