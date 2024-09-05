using System;
using System.Collections.Generic;

namespace WebAPI_20240905_Marjorie_Falcone.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Actividades = new HashSet<Actividade>();
            Certificados = new HashSet<Certificado>();
            Inscripciones = new HashSet<Inscripcione>();
            Materiales = new HashSet<Materiale>();
        }

        public int IdCurso { get; set; }
        public int? IdInstructor { get; set; }
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int Duracion { get; set; }
        public string? Cronograma { get; set; }

        public virtual Usuario? IdInstructorNavigation { get; set; }
        public virtual ICollection<Actividade> Actividades { get; set; }
        public virtual ICollection<Certificado> Certificados { get; set; }
        public virtual ICollection<Inscripcione> Inscripciones { get; set; }
        public virtual ICollection<Materiale> Materiales { get; set; }
    }
}
