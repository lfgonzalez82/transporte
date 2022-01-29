
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

        //return await _contexto.Agendamentos.ToListAsync();
        return await _contexto.Agendamentos
                                  .Include(horario => horario.Horario)
                                  .Include(tipoCarga => tipoCarga.TipoCarga)
                                  .Include(tipoTransporte => tipoTransporte.TipoTransporte)
                                  .Where(a => a.Status == status)
                                  .ToListAsync();
    }
}