using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class TipoTransporteService : ITipoTransporteService {

    private readonly TransporteContext _contexto;

    public TipoTransporteService(TransporteContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<TipoTransporte>> RetornaTiposTransporte(bool status) {
        return await _contexto.TiposTransportes
                                  .Where(tt => tt.Status == status)
                                  .ToListAsync();
    }

    public async Task<int>  InserirTipoTransporte(TipoTransporte _tipoTransporte) {
        
        _tipoTransporte.Tipo = _tipoTransporte.Tipo.ToUpper();
        _contexto.TiposTransportes.Add(_tipoTransporte);
        return await _contexto.SaveChangesAsync();
    }

    public async Task<TipoTransporte> RetornaTipoTransportePorId(int? id) {
        return await _contexto.TiposTransportes.SingleOrDefaultAsync(tt => tt.Id == id);
    }

    public async Task<int> AtualizarTipoTransporte(TipoTransporte _tipoTransporte) {
        _tipoTransporte.Tipo = _tipoTransporte.Tipo.ToUpper();
        _contexto.TiposTransportes.Update(_tipoTransporte);
        return await _contexto.SaveChangesAsync();
    }

    public async Task<int> InativarTipoTransporte(TipoTransporte _tipoTransporte)
    {
        _tipoTransporte.Status = false;
        _contexto.TiposTransportes.Update(_tipoTransporte);
        return await _contexto.SaveChangesAsync();
    }
}