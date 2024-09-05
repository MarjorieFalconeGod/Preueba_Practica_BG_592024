using System;
using System.Collections.Generic;

namespace WebAPI_20240905_Marjorie_Falcone.Models
{
    public partial class Materiale
    {
        public int IdMaterial { get; set; }
        public int? IdCurso { get; set; }
        public string TipoMaterial { get; set; } = null!;
        public string UrlMaterial { get; set; } = null!;
        public string? Descripcion { get; set; }

        public virtual Curso? IdCursoNavigation { get; set; }
    }
}
