using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITipoTransporteService {

    

    public Task<List<TipoTransporte>> RetornaTiposTransporte(bool status);

    public Task<int>  InserirTipoTransporte(TipoTransporte _tipoTransporte);

    public Task<TipoTransporte> RetornaTipoTransportePorId(int? id);

    public Task<int> AtualizarTipoTransporte(TipoTransporte _tipoTransporte);

    public Task<int> InativarTipoTransporte(TipoTransporte _tipoTransporte);

}