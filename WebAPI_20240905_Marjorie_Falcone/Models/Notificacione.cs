using System;
using System.Collections.Generic;

namespace WebAPI_20240905_Marjorie_Falcone.Models
{
    public partial class Notificacione
    {
        public int IdNotificacion { get; set; }
        public int? IdEstudiante { get; set; }
        public string? Mensaje { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public bool? Leida { get; set; }

        public virtual Usuario? IdEstudianteNavigation { get; set; }
    }
}
