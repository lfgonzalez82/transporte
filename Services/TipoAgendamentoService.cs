using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class TipoAgendamentoService : ITipoAgendamentoService {

    private readonly TransporteContext _contexto;

    public TipoAgendamentoService(TransporteContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<TipoAgendamento>> RetornaTiposAgendamento(bool status) {
        return await _contexto.TiposAgendamento
                                  .Where(tt => tt.Status == status)
                                  .ToListAsync();
    }

    public async Task<int>  InserirTipoAgendamento(TipoAgendamento _tipoAgendamento) {
        
        _tipoAgendamento.Descricao = _tipoAgendamento.Descricao.ToUpper();
        _contexto.TiposAgendamento.Add(_tipoAgendamento);
        return await _contexto.SaveChangesAsync();
    }

    public async Task<TipoAgendamento> RetornaTipoAgendamentoPorId(int? id) {
        return await _contexto.TiposAgendamento.SingleOrDefaultAsync(tt => tt.Id == id);
    }

    public async Task<int> AtualizarTipoAgendamento(TipoAgendamento _tipoAgendamento) {
        _tipoAgendamento.Descricao = _tipoAgendamento.Descricao.ToUpper();
        _contexto.TiposAgendamento.Update(_tipoAgendamento);
        return await _contexto.SaveChangesAsync();
    }

    public async Task<int> InativarTipoAgendamento(TipoAgendamento _tipoAgendamento)
    {
        _tipoAgendamento.Status = false;
        _contexto.TiposAgendamento.Update(_tipoAgendamento);
        return await _contexto.SaveChangesAsync();
    }
}