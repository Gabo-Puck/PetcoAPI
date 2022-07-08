using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Mensaje
    {
        public int Id { get; set; }
        public int UsuarioRemitente { get; set; }
        public int UsuarioDestinatario { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha_Envio { get; set; }
        public virtual Usuario UsuarioDestinatarioNavigation { get; set; }
        public virtual Usuario UsuarioRemitenteNavigation { get; set; }
    }
}
