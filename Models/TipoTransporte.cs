using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class TipoTransporte {
    
    public TipoTransporte()
    {
        this.Status = true;
    }
    
    [Required]
    public int Id { get; set; }
    
    [Required]
    [Display(Name = "Tipo Transporte")]
    [StringLength(200, ErrorMessage = "Número máximo de caracteres permitidos: 200")]
    public string Tipo { get; set; }

    [Required]
    public bool Status { get; set; }

    public List<Agendamento> Agendamentos { get; set; }
}