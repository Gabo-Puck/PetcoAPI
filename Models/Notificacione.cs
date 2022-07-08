using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Notificacione
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Origen { get; set; }
        public int IdUsuario { get; set; }

        public DateTime Fecha_Generacion { get; set; }



        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
