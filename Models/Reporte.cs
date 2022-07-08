using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Reporte
    {
        public int Id { get; set; }
        public string Razon { get; set; }
        public string Origen { get; set; }
        public byte TipoOrigen { get; set; }
        public int IdUsuarioReporta { get; set; }
        public int IdUsuarioReportado { get; set; }
        public byte TipoReporte { get; set; }

        public virtual Usuario IdUsuarioReportaNavigation { get; set; }
        public virtual Usuario IdUsuarioReportadoNavigation { get; set; }
        public virtual TipoReporte TipoReporteNavigation { get; set; }
    }
}
