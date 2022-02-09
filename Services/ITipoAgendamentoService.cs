using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITipoAgendamentoService {

    

    public Task<List<TipoAgendamento>> RetornaTiposAgendamento(bool status);

    public Task<int>  InserirTipoAgendamento(TipoAgendamento _tipoAgendamento);

    public Task<TipoAgendamento> RetornaTipoAgendamentoPorId(int? id);

    public Task<int> AtualizarTipoAgendamento(TipoAgendamento _tipoAgendamento);

    public Task<int> InativarTipoAgendamento(TipoAgendamento _tipoAgendamento);

}