using System;
using System.Collections.Generic;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            DonacioneIdOrganizacionNavigations = new HashSet<Donacione>();
            DonacioneIdUsuarioNavigations = new HashSet<Donacione>();
            Formularios = new HashSet<Formulario>();
            Intereses = new HashSet<Interese>();
            MensajeUsuarioDestinatarioNavigations = new HashSet<Mensaje>();
            MensajeUsuarioRemitenteNavigations = new HashSet<Mensaje>();
            Notificaciones = new HashSet<Notificacione>();
            ReporteIdUsuarioReportaNavigations = new HashSet<Reporte>();
            ReporteIdUsuarioReportadoNavigations = new HashSet<Reporte>();
            Solicitudes = new HashSet<Solicitude>();
            UsuarioBloqueadoIdBloqueadoNavigations = new HashSet<UsuarioBloqueado>();
            UsuarioBloqueadoIdUsuarioNavigations = new HashSet<UsuarioBloqueado>();
        }

        public int Id { get; set; }
        public string FotoPerfil { get; set; }
        public int FkRegistro { get; set; }
        public int Reputacion { get; set; }

        public virtual Registro FkRegistroNavigation { get; set; }
        public virtual ICollection<Donacione> DonacioneIdOrganizacionNavigations { get; set; }
        public virtual ICollection<Donacione> DonacioneIdUsuarioNavigations { get; set; }
        public virtual ICollection<Formulario> Formularios { get; set; }
        public virtual ICollection<Interese> Intereses { get; set; }
        public virtual ICollection<Mensaje> MensajeUsuarioDestinatarioNavigations { get; set; }
        public virtual ICollection<Mensaje> MensajeUsuarioRemitenteNavigations { get; set; }
        public virtual ICollection<Notificacione> Notificaciones { get; set; }
        public virtual ICollection<Reporte> ReporteIdUsuarioReportaNavigations { get; set; }
        public virtual ICollection<Reporte> ReporteIdUsuarioReportadoNavigations { get; set; }
        public virtual ICollection<Solicitude> Solicitudes { get; set; }
        public virtual ICollection<UsuarioBloqueado> UsuarioBloqueadoIdBloqueadoNavigations { get; set; }
        public virtual ICollection<UsuarioBloqueado> UsuarioBloqueadoIdUsuarioNavigations { get; set; }
    }
}
