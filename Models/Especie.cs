using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Especie
    {
        public Especie()
        {
            Intereses = new HashSet<Interese>();
            Mascota = new HashSet<Mascotum>();
            VacunasEspecies = new HashSet<VacunasEspecie>();
        }

        public int Id { get; set; }
        public string NombreEspecie { get; set; }

        public virtual ICollection<Interese> Intereses { get; set; }
        public virtual ICollection<Mascotum> Mascota { get; set; }
        public virtual ICollection<VacunasEspecie> VacunasEspecies { get; set; }
    }
}
