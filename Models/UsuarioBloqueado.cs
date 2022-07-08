using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class UsuarioBloqueado
    {
        public int IdUsuario { get; set; }
        public int IdBloqueado { get; set; }

        public virtual Usuario IdBloqueadoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
