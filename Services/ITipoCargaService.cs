using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITipoCargaService {

    public Task<List<TipoCarga>> RetornaTiposCarga(bool status);

    public Task<int>  InserirTipoCarga(TipoCarga _tipoCarga);

    public Task<TipoCarga> RetornaTipoCargaPorId(int? id);

    public Task<int> AtualizarTipoCarga(TipoCarga _tipoCarga);

    public Task<int> InativarTipoCarga(TipoCarga _tipoCarga);

}