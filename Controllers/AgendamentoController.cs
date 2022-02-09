
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class AgendamentoController : Controller {
    private readonly IAgendamentoService _agendamentoService;
    private readonly IHorarioService _horarioService;
    private readonly ITipoCargaService _tipoCargaService;
    private readonly ITipoTransporteService _tipoTransporteService;

    public AgendamentoController(IAgendamentoService agendamentoService, 
                                 IHorarioService horarioService,
                                 ITipoCargaService tipoCargaService,
                                 ITipoTransporteService tipoTransporteService)
    {
        _agendamentoService = agendamentoService;
        _horarioService = horarioService;
        _tipoCargaService = tipoCargaService;
        _tipoTransporteService = tipoTransporteService;
    }

    public IActionResult Index() {

        
        return View(_agendamentoService.RetornaAgendamentos(true).Result);
    }

    public IActionResult Inserir() {
        
        ViewBag.Horarios = _horarioService.RetornaHorarios(true)
                                                    .Result
                                                    .Select(h => new SelectListItem(){ 
                                                        Text= h.Periodo.ToString(), Value=h.Id.ToString()
                                                    }).ToList();
        ViewBag.TiposCarga = _tipoCargaService.RetornaTiposCarga(true)
                                                .Result
                                                .Select(tc => new SelectListItem() {
                                                    Text = tc.Carga, Value=tc.Id.ToString()
                                                }).ToList();
        ViewBag.TiposTransporte = _tipoTransporteService.RetornaTiposTransporte(true)
                                                        .Result
                                                        .Select(tt => new SelectListItem() {
                                                            Text = tt.Tipo, Value= tt.Id.ToString()
                                                        });
        
        
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Inserir(Agendamento _agendamento) {
        
        if (ModelState.IsValid)
        {
            await _agendamentoService.InserirAgendamentos(_agendamento);
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Editar(int? id)
    {
        
        ViewBag.Horarios = _horarioService.RetornaHorarios(true)
                                                    .Result
                                                    .Select(h => new SelectListItem(){ 
                                                        Text= h.Periodo.ToString(), Value=h.Id.ToString()
                                                    }).ToList();
        ViewBag.TiposCarga = _tipoCargaService.RetornaTiposCarga(true)
                                                .Result
                                                .Select(tc => new SelectListItem() {
                                                    Text = tc.Carga, Value=tc.Id.ToString()
                                                }).ToList();
        ViewBag.TiposTransporte = _tipoTransporteService.RetornaTiposTransporte(true)
                                                        .Result
                                                        .Select(tt => new SelectListItem() {
                                                            Text = tt.Tipo, Value= tt.Id.ToString()
                                                        });

        if (id == null)
        {
            return NotFound();
        }

        var agendamento = await _agendamentoService.RetornaAgendamentoPorId(id);

        

        if (agendamento == null)
        {
            return NotFound();
        }

        
        return View(agendamento);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(Agendamento _agendamento) 
    {
        if (ModelState.IsValid)
        {
            await _agendamentoService.AtualizarAgendamentos(_agendamento);
            return RedirectToAction("Index");
        }
        return View(_agendamento);
    }

    [HttpGet]
    public async Task<IActionResult> Deletar(int? id) {
        
        if (id == null)
        {
            return NotFound();
        }

        var agendamento = await _agendamentoService.RetornaAgendamentoPorId(id);

        

        if (agendamento == null)
        {
            return NotFound();
        }

        await _agendamentoService.InativarAgendamento(agendamento);

        return RedirectToAction("Index");
    }

    public IActionResult GrupoTipoTransporteAgendamento() {
        
        return View(_agendamentoService.RetornaAgendamentosAgrupadosPorTipoTransporte().Result);
    }

    public IActionResult GrupoDataAgendamento() {
        
        return View(_agendamentoService.RetornaAgendamentosAgrupadosPorData().Result);
    }

    public IActionResult GrupoPeriodoAgendamento() {
        
        return View(_agendamentoService.RetornaAgendamentosAgrupadosPorPeriodo().Result);
    }

    public IActionResult GrupoTipoCargaAgendamento() {
        return View(_agendamentoService.RetornaAgendamentosAgrupadosPorTipoCarga().Result);
    }

    public IActionResult GrupoTipoAgendamento() {
        return View(_agendamentoService.RetornaAgendamentosAgrupadosPorTipoAgendamento().Result);
    }
}