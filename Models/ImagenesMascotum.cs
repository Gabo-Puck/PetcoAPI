using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class ImagenesMascotum
    {
        public long IdMascota { get; set; }
        public long IdImagen { get; set; }

        public virtual Imagene IdImagenNavigation { get; set; }
        public virtual Mascotum IdMascotaNavigation { get; set; }
    }
}
