using System;
using System.Collections.Generic;

namespace WebAPI_20240905_Marjorie_Falcone.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Actividades = new HashSet<Actividade>();
            Certificados = new HashSet<Certificado>();
            Cursos = new HashSet<Curso>();
            Inscripciones = new HashSet<Inscripcione>();
            Notificaciones = new HashSet<Notificacione>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Apellido { get; set; }
        public string Email { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public DateTime? FechaRegistro { get; set; }

        public virtual ICollection<Actividade> Actividades { get; set; }
        public virtual ICollection<Certificado> Certificados { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual ICollection<Inscripcione> Inscripciones { get; set; }
        public virtual ICollection<Notificacione> Notificaciones { get; set; }
    }
}
