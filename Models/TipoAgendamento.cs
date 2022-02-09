using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class TipoAgendamento {


    public TipoAgendamento(){
        this.Status = true;
    }

    [Required]
    public int Id { get; set; }
    
    [Required]
    [Display(Name = "Tipo Agendamento")]
    [StringLength(200, ErrorMessage = "Número máximo de caracteres permitidos: 200")]
    public string Descricao { get; set; }

    [Required]
    public bool Status {get; set;}

    public List<Agendamento> Agendamentos {get;set;}

}