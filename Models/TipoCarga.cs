using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class TipoCarga {

    public TipoCarga()
    {
        this.Status = true;
    }

    [Required]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Tipo Carga")]
    public string Carga { get; set; }

    [Required]
    public bool Status { get; set; }

    public List<Agendamento> Agendamentos { get; set; }
}