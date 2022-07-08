using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Protocolo
    {
        public Protocolo()
        {
            Pasos = new HashSet<Paso>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int IdFormulario { get; set; }

        public virtual Formulario IdFormularioNavigation { get; set; }
        public virtual ICollection<Paso> Pasos { get; set; }
    }
}
