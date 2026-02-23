using System;
using System.ComponentModel.DataAnnotations;

namespace ReservationWeb.Mvc.Models
{
    // ViewModel para CREAR y EDITAR una reserva
    public class ReservationFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del paciente es obligatorio.")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [Display(Name = "Paciente")]
        public string Paciente { get; set; }

        [Required(ErrorMessage = "El nombre del médico es obligatorio.")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [Display(Name = "Médico")]
        public string Medico { get; set; }

        [Required(ErrorMessage = "La especialidad es obligatoria.")]
        [Display(Name = "Especialidad")]
        public string Especialidad { get; set; }

        [Required(ErrorMessage = "La fecha de la cita es obligatoria.")]
        [Display(Name = "Fecha de Cita")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; } = DateTime.Now.AddDays(1);
    }

    // ViewModel para LISTAR y VER DETALLE
    public class ReservationListViewModel
    {
        public int Id { get; set; }
        public string Paciente { get; set; }
        public string Medico { get; set; }
        public string Especialidad { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}