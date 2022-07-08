using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class VacunasEspecie
    {
        public int IdVacuna { get; set; }
        public int IdEspecie { get; set; }

        public virtual Especie IdEspecieNavigation { get; set; }
        public virtual Vacuna IdVacunaNavigation { get; set; }
    }
}
