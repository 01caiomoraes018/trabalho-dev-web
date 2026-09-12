using Trabalho1DevWebNet.Models;

namespace Trabalho1DevWebNet.Data;

public class SeedingService
{
    private readonly AppDbContext _context;

    public SeedingService(AppDbContext context)
    {
        _context = context;
    }

    public void Popula()
    {
        if (_context.Pacientes.Any())
        {
            return;
        }

        // Dados fictícios usados apenas para demonstração.
        var paciente1 = new Paciente
        {
            Nome = "Caio Moraes",
            Cpf = "529.982.247-25",
            Telefone = "(18) 99999-1111",
            Endereco = "Rua de Exemplo, 100",
            DataNascimento = new DateTime(1995, 5, 15)
        };

        var paciente2 = new Paciente
        {
            Nome = "Paciente Exemplo Dois",
            Cpf = "111.444.777-35",
            Telefone = "(18) 3333-4444",
            Endereco = "Rua de Exemplo, 200",
            DataNascimento = new DateTime(1988, 10, 20)
        };

        _context.Pacientes.AddRange(paciente1, paciente2);
        _context.SaveChanges();
    }
}
