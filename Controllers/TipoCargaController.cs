using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class TipoCargaController : Controller {

    private readonly ITipoCargaService _tipoCargaService;


    public TipoCargaController(ITipoCargaService tipoCargaService) => _tipoCargaService = tipoCargaService;

    public IActionResult Index() {
        return View(_tipoCargaService.RetornaTiposCarga(true).Result);
    }

    public IActionResult Inserir() {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Inserir(TipoCarga _tipoCarga) {
        
        if (ModelState.IsValid)
        {
            await _tipoCargaService.InserirTipoCarga(_tipoCarga);
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

        var tipoCarga = await _tipoCargaService.RetornaTipoCargaPorId(id);
        if (tipoCarga == null)
        {
            return NotFound();
        }
        return View(tipoCarga);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(TipoCarga _tipoCarga) 
    {
        if (ModelState.IsValid)
        {
            await _tipoCargaService.AtualizarTipoCarga(_tipoCarga);
            return RedirectToAction("Index");
        }
        return View(_tipoCarga);
    }

    public async Task<IActionResult> Deletar(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tipoCarga = await _tipoCargaService.RetornaTipoCargaPorId(id);
        if (tipoCarga == null)
        {
            return NotFound();
        }

        await _tipoCargaService.InativarTipoCarga(tipoCarga);
        return RedirectToAction("Index");
    }







}