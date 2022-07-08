using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Interese
    {
        public int IdEspecie { get; set; }
        public int IdUsuario { get; set; }

        public virtual Especie IdEspecieNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
