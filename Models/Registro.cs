using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Registro
    {
        public Registro()
        {
            UsuarioModeradors = new HashSet<UsuarioModerador>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public byte TipoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int Municipio { get; set; }
        public string Telefono { get; set; }
        public string Contrasena { get; set; }
        public string DocumentoIdentidad { get; set; }

        public virtual Municipio MunicipioNavigation { get; set; }
        public virtual ICollection<UsuarioModerador> UsuarioModeradors { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
