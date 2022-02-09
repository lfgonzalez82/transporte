using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class Agendamento {


    public Agendamento()
    {
        this.Status = true;
    }
    
    [Required]
    public int Id { get; set; }

    [Required]
    [BindProperty, DataType(DataType.Date)]
    //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime DataAgendameto { get; set; }

    [Required]
    public int HorarioId { get; set; }

    public Horario Horario {get;set;}

    [Required]
    public int TipoAgendamentoId { get; set; }

    public TipoAgendamento TipoAgendamento { get; set; }

    [Required]
    public int TipoTransporteId { get; set; }

    public TipoTransporte TipoTransporte {get; set;}


    [Required]
    public int TipoCargaId { get; set; }

    public TipoCarga TipoCarga { get; set; }


    [Required]
    public int QuantidadeAgendada { get; set; }

    [Required]
    public bool Status { get;set; }



}