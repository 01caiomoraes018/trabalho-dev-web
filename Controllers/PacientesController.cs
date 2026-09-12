using Microsoft.AspNetCore.Mvc;
using Trabalho1DevWebNet.Data;

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
}
