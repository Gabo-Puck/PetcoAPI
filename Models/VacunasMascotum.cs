using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class VacunasMascotum
    {
        public long IdMascota { get; set; }
        public int IdVacuna { get; set; }

        public virtual Mascotum IdMascotaNavigation { get; set; }
        public virtual Vacuna IdVacunaNavigation { get; set; }
    }
}
