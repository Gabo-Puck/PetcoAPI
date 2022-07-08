using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Publicacion
    {
        public Publicacion()
        {
            Comentarios = new HashSet<Comentario>();
            Mascota = new HashSet<Mascotum>();
        }

        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int ReportesPeso { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Mascotum> Mascota { get; set; }
    }
}
