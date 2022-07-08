using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class TipoReporte
    {
        public TipoReporte()
        {
            Reportes = new HashSet<Reporte>();
        }

        public byte Id { get; set; }
        public string Razon { get; set; }
        public byte? Peso { get; set; }

        public virtual ICollection<Reporte> Reportes { get; set; }
    }
}
