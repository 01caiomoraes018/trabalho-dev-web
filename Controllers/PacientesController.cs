using Microsoft.AspNetCore.Mvc;
using Trabalho1DevWebNet.Data;
using Trabalho1DevWebNet.Models;

namespace Trabalho1DevWebNet.Controllers;

public class PacientesController : Controller
{
    private readonly AppDbContext _context;

    public PacientesController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var pacientes = _context.Pacientes.OrderBy(p => p.Nome).ToList();
        return View(pacientes);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Nome,Cpf,Telefone,Endereco,DataNascimento")] Paciente paciente)
    {
        if (!ModelState.IsValid)
        {
            return View(paciente);
        }

        _context.Pacientes.Add(paciente);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
