using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Respuesta
    {
        public int Id { get; set; }
        public string Respuesta1 { get; set; }
        public int IdPregunta { get; set; }
        public int IdSolicitud { get; set; }

        public virtual Pregunta IdPreguntaNavigation { get; set; }
        public virtual Solicitude IdSolicitudNavigation { get; set; }
    }
}
