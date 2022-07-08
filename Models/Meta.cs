using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Meta
    {
        public Meta()
        {
            Donaciones = new HashSet<Donacione>();
        }

        public int Id { get; set; }
        public long IdMascota { get; set; }
        public int Cantidad { get; set; }
        public bool Completado { get; set; }
        public string Descripcion { get; set; }

        public virtual Mascotum IdMascotaNavigation { get; set; }
        public virtual ICollection<Donacione> Donaciones { get; set; }
    }
}
