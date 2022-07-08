using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Vacuna
    {
        public Vacuna()
        {
            VacunasEspecies = new HashSet<VacunasEspecie>();
            VacunasMascota = new HashSet<VacunasMascotum>();
        }

        public int Id { get; set; }
        public string NombreVacuna { get; set; }

        public virtual ICollection<VacunasEspecie> VacunasEspecies { get; set; }
        public virtual ICollection<VacunasMascotum> VacunasMascota { get; set; }
    }
}
