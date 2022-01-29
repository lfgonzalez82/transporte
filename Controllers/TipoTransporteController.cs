using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class TipoTransporteController : Controller {

    private readonly ITipoTransporteService _tipoTransporteService;


    public TipoTransporteController(ITipoTransporteService tipoTransporteService) => _tipoTransporteService = tipoTransporteService;

    public IActionResult Index() {

        return View(_tipoTransporteService.RetornaTiposTransporte(true).Result);
    }

    public IActionResult Inserir() {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Inserir(TipoTransporte _tipoTransporte) {
        
        if (ModelState.IsValid)
        {
            await _tipoTransporteService.InserirTipoTransporte(_tipoTransporte);
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

        var tipoTransporte = await _tipoTransporteService.RetornaTipoTransportePorId(id);
        if (tipoTransporte == null)
        {
            return NotFound();
        }
        return View(tipoTransporte);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(TipoTransporte _tipoTransporte) 
    {
        if (ModelState.IsValid)
        {
            await _tipoTransporteService.AtualizarTipoTransporte(_tipoTransporte);
            return RedirectToAction("Index");
        }
        return View(_tipoTransporte);
    }


    public async Task<IActionResult> Deletar(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tipoTransporte = await _tipoTransporteService.RetornaTipoTransportePorId(id);
        if (tipoTransporte == null)
        {
            return NotFound();
        }

        await _tipoTransporteService.InativarTipoTransporte(tipoTransporte);
        return RedirectToAction("Index");
    }




}