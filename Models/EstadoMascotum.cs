using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class EstadoMascotum
    {
        public EstadoMascotum()
        {
            Mascota = new HashSet<Mascotum>();
        }

        public byte Id { get; set; }
        public string EstadoNombre { get; set; }

        public virtual ICollection<Mascotum> Mascota { get; set; }
    }
}
