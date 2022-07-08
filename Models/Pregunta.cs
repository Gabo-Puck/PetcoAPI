using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Pregunta
    {
        public Pregunta()
        {
            OpcionesRespuestasPregunta = new HashSet<OpcionesRespuestasPregunta>();
            PreguntasFormularios = new HashSet<PreguntasFormulario>();
            Respuesta = new HashSet<Respuesta>();
        }

        public int Id { get; set; }
        public string Pregunta1 { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<OpcionesRespuestasPregunta> OpcionesRespuestasPregunta { get; set; }
        public virtual ICollection<PreguntasFormulario> PreguntasFormularios { get; set; }
        public virtual ICollection<Respuesta> Respuesta { get; set; }
    }
}
