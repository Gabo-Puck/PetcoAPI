using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class PreguntasFormulario
    {
        public int IdPregunta { get; set; }
        public int IdFormulario { get; set; }

        public virtual Formulario IdFormularioNavigation { get; set; }
        public virtual Pregunta IdPreguntaNavigation { get; set; }
    }
}
