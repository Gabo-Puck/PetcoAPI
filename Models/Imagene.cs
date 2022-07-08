using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Imagene
    {
        public Imagene()
        {
            ImagenesMascota = new HashSet<ImagenesMascotum>();
        }

        public long Id { get; set; }
        public string Ruta { get; set; }

        public virtual ICollection<ImagenesMascotum> ImagenesMascota { get; set; }
    }
}
