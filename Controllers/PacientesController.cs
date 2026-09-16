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

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var paciente = _context.Pacientes.Find(id);
        if (paciente == null)
        {
            return NotFound();
        }

        return View(paciente);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed([FromRoute] int id)
    {
        var paciente = _context.Pacientes.Find(id);
        if (paciente == null)
        {
            return NotFound();
        }

        _context.Pacientes.Remove(paciente);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var paciente = _context.Pacientes.Find(id);
        if (paciente == null)
        {
            return NotFound();
        }

        return View(paciente);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit([FromRoute] int id,
        [Bind("Id,Nome,Cpf,Telefone,Endereco,DataNascimento")] Paciente paciente)
    {
        if (id != paciente.Id)
        {
            return BadRequest();
        }

        var pacienteSalvo = _context.Pacientes.Find(id);
        if (pacienteSalvo == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(paciente);
        }

        pacienteSalvo.Nome = paciente.Nome;
        pacienteSalvo.Cpf = paciente.Cpf;
        pacienteSalvo.Telefone = paciente.Telefone;
        pacienteSalvo.Endereco = paciente.Endereco;
        pacienteSalvo.DataNascimento = paciente.DataNascimento;
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
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
