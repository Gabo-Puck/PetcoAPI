using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Donacione
    {
        public int Id { get; set; }
        public int IdOrganizacion { get; set; }
        public int IdUsuario { get; set; }
        public int? IdMeta { get; set; }
        public int Cantidad { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Meta IdMetaNavigation { get; set; }
        public virtual Usuario IdOrganizacionNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
