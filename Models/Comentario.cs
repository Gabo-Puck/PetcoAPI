using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Comentario
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha_Envio { get; set; }
        public long IdPublicacion { get; set; }
        public int? ComentarioPadre { get; set; }

        public virtual Publicacion IdPublicacionNavigation { get; set; }
    }
}
