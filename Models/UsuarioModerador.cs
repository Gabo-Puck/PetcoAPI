using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class UsuarioModerador
    {
        public int Id { get; set; }
        public int IdRegistro { get; set; }

        public virtual Registro IdRegistroNavigation { get; set; }
    }
}
