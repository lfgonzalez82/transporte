
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAgendamentoService {


    public Task<List<Agendamento>> RetornaAgendamentos(bool status);

    public Task<int> InserirAgendamentos(Agendamento _agendamento);

    public Task<Agendamento> RetornaAgendamentoPorId(int? id);

    public Task<int> AtualizarAgendamentos(Agendamento _agendamento);

    public Task<int> InativarAgendamento(Agendamento _agendamento);


}