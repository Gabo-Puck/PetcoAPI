using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Municipio
    {
        public Municipio()
        {
            Registros = new HashSet<Registro>();
        }

        public int Id { get; set; }
        public int IdEstado { get; set; }
        public string Nombre { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual ICollection<Registro> Registros { get; set; }
    }
}
