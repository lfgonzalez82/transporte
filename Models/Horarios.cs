using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Horario {

    
    
    [Required]
    public int Id { get; set; }
    
    [Required]
    [StringLength(30, ErrorMessage = "Número máximo de caracteres permitido: 30")]
    public string Periodo { get; set; }
    
    [Required]
    
    public bool Status { get; set; }

    public List<Agendamento> Agendamentos { get; set; }

    public Horario()
    {
        this.Status = true;
    }
}