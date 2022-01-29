using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class HorarioController : Controller {

    private readonly IHorarioService _horarioService;


    public HorarioController(IHorarioService horarioService) => _horarioService = horarioService;

    public IActionResult Index() {
        return View(_horarioService.RetornaHorarios(true).Result);
    }

    public IActionResult Inserir() {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Inserir(Horario _horario) {
        
        if (ModelState.IsValid)
        {
            await _horarioService.InserirHorarios(_horario);
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Editar(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var horario = await _horarioService.RetornaHorarioPorId(id);
        if (horario == null)
        {
            return NotFound();
        }
        return View(horario);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(Horario _horario) 
    {
        if (ModelState.IsValid)
        {
            await _horarioService.AtualizarHorarios(_horario);
            return RedirectToAction("Index");
        }
        return View(_horario);
    }

    public async Task<IActionResult> Deletar(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var horario = await _horarioService.RetornaHorarioPorId(id);
        if (horario == null)
        {
            return NotFound();
        }


        await _horarioService.InativarHorarios(horario);
        return RedirectToAction("Index");
    }







}