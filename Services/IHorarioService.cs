using System.Collections.Generic;
using System.Threading.Tasks;

public interface IHorarioService {

    
    public Task<List<Horario>> RetornaHorarios(bool status);

    public Task<int> InserirHorarios(Horario _horario);

    public Task<Horario> RetornaHorarioPorId(int? id);

    public Task<int> AtualizarHorarios(Horario _horario);

    public Task<int> InativarHorarios(Horario _horario);

}