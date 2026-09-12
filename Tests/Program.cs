using System.ComponentModel.DataAnnotations;
using Trabalho1DevWebNet.Models;

var casos = new (string Nome, Action<Paciente> Alterar, string? Campo)[]
{
    ("Cadastro válido", p => { }, null),
    ("CPF sem pontuação", p => p.Cpf = "52998224725", null),
    ("Segundo CPF de demonstração", p => p.Cpf = "111.444.777-35", null),
    ("CPF com letras", p => p.Cpf = "abcdefghijk", "Cpf"),
    ("CPF repetido", p => p.Cpf = "11111111111", "Cpf"),
    ("CPF com dígito incorreto", p => p.Cpf = "52998224724", "Cpf"),
    ("CPF vazio", p => p.Cpf = "", "Cpf"),
    ("CPF com quebra de linha", p => p.Cpf = "52998224725\n", "Cpf"),
    ("Telefone fixo", p => p.Telefone = "(18) 3333-4444", null),
    ("Celular sem pontuação", p => p.Telefone = "18999991111", null),
    ("Telefone com letras", p => p.Telefone = "abcdefghij", "Telefone"),
    ("Telefone sem DDD", p => p.Telefone = "99999-1111", "Telefone"),
    ("DDD inválido", p => p.Telefone = "(00) 99999-1111", "Telefone"),
    ("Nascimento amanhã", p => p.DataNascimento = DateTime.Today.AddDays(1), "DataNascimento"),
    ("Nascimento hoje", p => p.DataNascimento = DateTime.Today, null),
    ("Nascimento padrão", p => p.DataNascimento = default, "DataNascimento"),
    ("Nome vazio", p => p.Nome = "", "Nome"),
    ("Endereço vazio", p => p.Endereco = "", "Endereco")
};

var falhas = 0;
foreach (var caso in casos)
{
    var paciente = new Paciente
    {
        Nome = "Paciente de teste", Cpf = "529.982.247-25",
        Telefone = "(18) 99999-1111", Endereco = "Rua de teste, 100",
        DataNascimento = new DateTime(1995, 5, 15)
    };
    caso.Alterar(paciente);
    var erros = new List<ValidationResult>();
    var valido = Validator.TryValidateObject(paciente, new ValidationContext(paciente), erros, true);
    var passou = caso.Campo is null ? valido : !valido && erros.Any(e => e.MemberNames.Contains(caso.Campo));
    Console.WriteLine($"{(passou ? "OK" : "FALHOU")}: {caso.Nome}");
    if (!passou) falhas++;
}
Console.WriteLine($"{casos.Length - falhas}/{casos.Length} verificações passaram.");
return falhas == 0 ? 0 : 1;
