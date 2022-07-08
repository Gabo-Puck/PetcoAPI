using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Formulario
    {
        public Formulario()
        {
            PreguntasFormularios = new HashSet<PreguntasFormulario>();
            Protocolos = new HashSet<Protocolo>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<PreguntasFormulario> PreguntasFormularios { get; set; }
        public virtual ICollection<Protocolo> Protocolos { get; set; }
    }
}
