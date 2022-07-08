using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Paso
    {
        public Paso()
        {
            PasoMascota = new HashSet<PasoMascotum>();
        }

        public int Id { get; set; }
        public string TituloPaso { get; set; }
        public string Descripcion { get; set; }
        public short DiasEstimados { get; set; }
        public string Archivo { get; set; }
        public int IdProtocolo { get; set; }

        public virtual Protocolo IdProtocoloNavigation { get; set; }
        public virtual ICollection<PasoMascotum> PasoMascota { get; set; }
    }
}
