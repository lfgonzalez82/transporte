using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class HorarioService : IHorarioService {

    private readonly TransporteContext _contexto;

    public HorarioService(TransporteContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<Horario>> RetornaHorarios(bool status) {
        return await _contexto.Horarios
                                 .Where(h => h.Status == status)
                                 .ToListAsync();
                                 
    }

    public async Task<int>  InserirHorarios(Horario _horario) {
        
        _contexto.Horarios.Add(_horario);
        return await _contexto.SaveChangesAsync();
    }

    public async Task<Horario> RetornaHorarioPorId(int? id) {
        return await _contexto.Horarios.SingleOrDefaultAsync(h => h.Id == id);
    }

    public async Task<int> AtualizarHorarios(Horario _horario) {
        _contexto.Horarios.Update(_horario);
        return await _contexto.SaveChangesAsync();
    }

    public async Task<int> InativarHorarios(Horario _horario)
    {
        _horario.Status = false;
        _contexto.Horarios.Update(_horario);
        return await _contexto.SaveChangesAsync();
    }
}