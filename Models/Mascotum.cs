using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Mascotum
    {
        public Mascotum()
        {
            ImagenesMascota = new HashSet<ImagenesMascotum>();
            Meta = new HashSet<Meta>();
            PasoMascota = new HashSet<PasoMascotum>();
            Solicitudes = new HashSet<Solicitude>();
            VacunasMascota = new HashSet<VacunasMascotum>();
        }

        public long Id { get; set; }
        public long IdPublicacion { get; set; }
        public string Nombre { get; set; }
        public int IdEspecie { get; set; }
        public int Edad { get; set; }
        public string Descripcion { get; set; }
        public byte IdEstado { get; set; }

        public virtual Especie IdEspecieNavigation { get; set; }
        public virtual EstadoMascotum IdEstadoNavigation { get; set; }
        public virtual Publicacion IdPublicacionNavigation { get; set; }
        public virtual ICollection<ImagenesMascotum> ImagenesMascota { get; set; }
        public virtual ICollection<Meta> Meta { get; set; }
        public virtual ICollection<PasoMascotum> PasoMascota { get; set; }
        public virtual ICollection<Solicitude> Solicitudes { get; set; }
        public virtual ICollection<VacunasMascotum> VacunasMascota { get; set; }
    }
}
