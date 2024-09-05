using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPP_20240905_Marjorie_Falcone.Models
{
    public partial class Certificado
    {
        
        public int IdCertificado { get; set; }
        public int? IdCurso { get; set; }
        public int? IdEstudiante { get; set; }
        public DateTime? FechaEmision { get; set; }

        public virtual Curso? IdCursoNavigation { get; set; }
        public virtual Usuario? IdEstudianteNavigation { get; set; }
    }
}
