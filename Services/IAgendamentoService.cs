
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IAgendamentoService {


    public Task<List<Agendamento>> RetornaAgendamentos(bool status);

    public Task<int> InserirAgendamentos(Agendamento _agendamento);

    public Task<Agendamento> RetornaAgendamentoPorId(int? id);

    public Task<int> AtualizarAgendamentos(Agendamento _agendamento);

    public Task<int> InativarAgendamento(Agendamento _agendamento);

    public Task<List<IGrouping<string, Agendamento>>> RetornaAgendamentosAgrupadosPorTipoTransporte();

    public Task<List<IGrouping<string,Agendamento>>> RetornaAgendamentosAgrupadosPorData();

    public Task<List<IGrouping<string,Agendamento>>> RetornaAgendamentosAgrupadosPorPeriodo();

    public Task<List<IGrouping<string,Agendamento>>> RetornaAgendamentosAgrupadosPorTipoCarga();

    public Task<List<IGrouping<string,Agendamento>>> RetornaAgendamentosAgrupadosPorTipoAgendamento();


}