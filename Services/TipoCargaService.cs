using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class TipoCargaService : ITipoCargaService {

    private readonly TransporteContext _contexto;

    public TipoCargaService(TransporteContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<TipoCarga>> RetornaTiposCarga(bool status) {
        return await _contexto.TipoCargas
                                .Where(tc => tc.Status == status)
                                .ToListAsync();
    }

    public async Task<int>  InserirTipoCarga(TipoCarga _tipoCarga) {
        
        _tipoCarga.Carga = _tipoCarga.Carga.ToUpper();
        _contexto.TipoCargas.Add(_tipoCarga);
        return await _contexto.SaveChangesAsync();
    }

    public async Task<TipoCarga> RetornaTipoCargaPorId(int? id) {
        return await _contexto.TipoCargas.SingleOrDefaultAsync(tc => tc.Id == id);
    }

    public async Task<int> AtualizarTipoCarga(TipoCarga _tipoCarga) {
        _tipoCarga.Carga = _tipoCarga.Carga.ToUpper();
        _contexto.TipoCargas.Update(_tipoCarga);
        return await _contexto.SaveChangesAsync();
    }

    public async Task<int> InativarTipoCarga(TipoCarga _tipoCarga)
    {
        _tipoCarga.Status = false;
        _contexto.TipoCargas.Update(_tipoCarga);
        return await _contexto.SaveChangesAsync();

    }
}