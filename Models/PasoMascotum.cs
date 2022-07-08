using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class PasoMascotum
    {
        public long Id { get; set; }
        public long IdMascota { get; set; }
        public int IdPaso { get; set; }
        public byte Completado { get; set; }
        public string Archivo { get; set; }

        public virtual Mascotum IdMascotaNavigation { get; set; }
        public virtual Paso IdPasoNavigation { get; set; }
    }
}
