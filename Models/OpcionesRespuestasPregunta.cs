using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class OpcionesRespuestasPregunta
    {
        public int Id { get; set; }
        public int IdPregunta { get; set; }
        public string OpcionRespuesta { get; set; }

        public virtual Pregunta IdPreguntaNavigation { get; set; }
    }
}
