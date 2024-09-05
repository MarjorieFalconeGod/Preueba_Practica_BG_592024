using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPP_20240905_Marjorie_Falcone.Models
{
    public partial class Actividad
    {
        
        public int IdActividad { get; set; }
        public int? IdCurso { get; set; }
        public int? IdEstudiante { get; set; }
        public string? Titulo { get; set; }
        public string TipoActividad { get; set; } = null!;
        public decimal? Calificacion { get; set; }
        public string? Retroalimentacion { get; set; }
        public DateTime? FechaEntrega { get; set; }

        public virtual Curso? IdCursoNavigation { get; set; }
        public virtual Usuario? IdEstudianteNavigation { get; set; }
    }
}
