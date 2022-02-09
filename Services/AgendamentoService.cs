
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class AgendamentoService : IAgendamentoService
{
    private readonly TransporteContext _contexto;

    public AgendamentoService(TransporteContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<int> AtualizarAgendamentos(Agendamento _agendamento)
    {
        _contexto.Agendamentos.Update(_agendamento);
        return await _contexto.SaveChangesAsync();
    }

    public async Task<int> InativarAgendamento(Agendamento _agendamento)
    {
        _agendamento.Status = false;
        _contexto.Agendamentos.Update(_agendamento);
        return await _contexto.SaveChangesAsync();
    }

    public async Task<int> InserirAgendamentos(Agendamento _agendamento)
    {

        _contexto.Agendamentos.Add(_agendamento);
        return await _contexto.SaveChangesAsync();
    }

    public async Task<Agendamento> RetornaAgendamentoPorId(int? id)
    {
        return await _contexto.Agendamentos
                                  .Include(horario => horario.Horario)
                                  .Include(tipoCarga => tipoCarga.TipoCarga)
                                  .Include(tipoTransporte => tipoTransporte.TipoTransporte)
                                  .SingleOrDefaultAsync(ag => ag.Id == id);
    }

    public async Task<List<Agendamento>> RetornaAgendamentos(bool status)
    {

        return await _contexto.Agendamentos
                                  .Include(horario => horario.Horario)
                                  .Include(tipoCarga => tipoCarga.TipoCarga)
                                  .Include(tipoTransporte => tipoTransporte.TipoTransporte)
                                  .Where(a => a.Status == status)
                                  .OrderByDescending(ag => ag.DataAgendameto)
                                  .ToListAsync();
    }

    public async Task<List<IGrouping<string, Agendamento>>> RetornaAgendamentosAgrupadosPorData()
    {
        List<Agendamento> listaAgendamentos = await RetornaAgendamentos(true);

        var dataGrupo = from data in listaAgendamentos
                        group data by data.DataAgendameto.ToShortDateString() into grupoData
                        select grupoData;

        return dataGrupo.ToList();

    
    }

    public async Task<List<IGrouping<string, Agendamento>>> RetornaAgendamentosAgrupadosPorPeriodo()
    {
        List<Agendamento> listaAgendamentos = await RetornaAgendamentos(true);

        var periodoGrupo = from periodo in listaAgendamentos
                           group periodo by periodo.Horario.Periodo into grupoPeriodo
                           select grupoPeriodo;

        return periodoGrupo.ToList();
        
    }

    public async Task<List<IGrouping<string, Agendamento>>> RetornaAgendamentosAgrupadosPorTipoCarga()
    {
        List<Agendamento> listaAgendamentos = await RetornaAgendamentos(true);

        var tipoCargaGrupo = from tipoCarga in listaAgendamentos
                             group tipoCarga by tipoCarga.TipoCarga.Carga into grupoCarga
                             select grupoCarga;

        return tipoCargaGrupo.ToList();
                    
    }

    public async Task<List<IGrouping<string, Agendamento>>> RetornaAgendamentosAgrupadosPorTipoTransporte()
    {
        List<Agendamento> listaAgendamentos = await RetornaAgendamentos(true);

        var tipoTransporteGrupo = from tipoTransporte in listaAgendamentos
                                  group tipoTransporte by tipoTransporte.TipoTransporte.Tipo into grupoTransporte
                                  select grupoTransporte;

        return tipoTransporteGrupo.ToList();

    }

    public async Task<List<IGrouping<string,Agendamento>>> RetornaAgendamentosAgrupadosPorTipoAgendamento() {
        List<Agendamento> listaAgendamentos = await RetornaAgendamentos(true);
        var tipoAgendamentoGrupo = from tipoAgendamento in listaAgendamentos
                                   group tipoAgendamento by tipoAgendamento.TipoAgendamento.Descricao into grupoTipoAgendamento
                                   select grupoTipoAgendamento;
        return tipoAgendamentoGrupo.ToList();
    }

    
}