using System;
using System.Collections.Generic;

namespace WebAPP_20240905_Marjorie_Falcone.Models
{
    public partial class Inscripcione
    {
        public int IdInscripcion { get; set; }
        public int? IdCurso { get; set; }
        public int? IdEstudiante { get; set; }
        public DateTime? FechaInscripcion { get; set; }
        public double? Progreso { get; set; }

        public virtual Curso? IdCursoNavigation { get; set; }
        public virtual Usuario? IdEstudianteNavigation { get; set; }
    }
}
