using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Solicitude
    {
        public Solicitude()
        {
            Respuesta = new HashSet<Respuesta>();
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public long IdMascota { get; set; }

        public virtual Mascotum IdMascotaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Respuesta> Respuesta { get; set; }
    }
}
