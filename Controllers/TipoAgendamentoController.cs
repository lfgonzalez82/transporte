using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class TipoAgendamentoController : Controller {

    private readonly ITipoAgendamentoService _tipoAgendamentoService;


    public TipoAgendamentoController(ITipoAgendamentoService tipoAgendamentoService) => _tipoAgendamentoService = tipoAgendamentoService;

    public IActionResult Index() {

        return View(_tipoAgendamentoService.RetornaTiposAgendamento(true).Result);
    }

    public IActionResult Inserir() {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Inserir(TipoAgendamento _tipoAgendamento) {
        
        if (ModelState.IsValid)
        {
            await _tipoAgendamentoService.InserirTipoAgendamento(_tipoAgendamento);
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

        var tipoAgendamento = await _tipoAgendamentoService.RetornaTipoAgendamentoPorId(id);
        if (tipoAgendamento == null)
        {
            return NotFound();
        }
        return View(tipoAgendamento);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(TipoAgendamento _tipoAgendamento) 
    {
        if (ModelState.IsValid)
        {
            await _tipoAgendamentoService.AtualizarTipoAgendamento(_tipoAgendamento);
            return RedirectToAction("Index");
        }
        return View(_tipoAgendamento);
    }


    public async Task<IActionResult> Deletar(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tipoAgendamento = await _tipoAgendamentoService.RetornaTipoAgendamentoPorId(id);
        if (tipoAgendamento == null)
        {
            return NotFound();
        }

        await _tipoAgendamentoService.InativarTipoAgendamento(tipoAgendamento);
        return RedirectToAction("Index");
    }




}