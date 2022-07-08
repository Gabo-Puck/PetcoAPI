using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PetcoAPI.Models
{
    public partial class petcodbv2Context : DbContext
    {
        public petcodbv2Context()
        {
        }

        public petcodbv2Context(DbContextOptions<petcodbv2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Comentario> Comentarios { get; set; }
        public virtual DbSet<Donacione> Donaciones { get; set; }
        public virtual DbSet<Especie> Especies { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<EstadoMascotum> EstadoMascota { get; set; }
        public virtual DbSet<Formulario> Formularios { get; set; }
        public virtual DbSet<Imagene> Imagenes { get; set; }
        public virtual DbSet<ImagenesMascotum> ImagenesMascota { get; set; }
        public virtual DbSet<Interese> Intereses { get; set; }
        public virtual DbSet<Mascotum> Mascota { get; set; }
        public virtual DbSet<Mensaje> Mensajes { get; set; }
        public virtual DbSet<Meta> Metas { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<Notificacione> Notificaciones { get; set; }
        public virtual DbSet<OpcionesRespuestasPregunta> OpcionesRespuestasPreguntas { get; set; }
        public virtual DbSet<Paso> Pasos { get; set; }
        public virtual DbSet<PasoMascotum> PasoMascota { get; set; }
        public virtual DbSet<Pregunta> Preguntas { get; set; }
        public virtual DbSet<PreguntasFormulario> PreguntasFormularios { get; set; }
        public virtual DbSet<Protocolo> Protocolos { get; set; }
        public virtual DbSet<Publicacion> Publicacions { get; set; }
        public virtual DbSet<Registro> Registros { get; set; }
        public virtual DbSet<Reporte> Reportes { get; set; }
        public virtual DbSet<Respuesta> Respuestas { get; set; }
        public virtual DbSet<Solicitude> Solicitudes { get; set; }
        public virtual DbSet<TipoReporte> TipoReportes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioBloqueado> UsuarioBloqueados { get; set; }
        public virtual DbSet<UsuarioModerador> UsuarioModeradors { get; set; }
        public virtual DbSet<Vacuna> Vacunas { get; set; }
        public virtual DbSet<VacunasEspecie> VacunasEspecies { get; set; }
        public virtual DbSet<VacunasMascotum> VacunasMascota { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=127.0.0.1;uid=root;pwd=halo1234;database=petcodbv2;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.ToTable("comentario");

                entity.HasIndex(e => e.IdPublicacion, "ID_Publicacion");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ComentarioPadre).HasColumnName("Comentario_Padre");

                entity.Property(e => e.IdPublicacion).HasColumnName("ID_Publicacion");

                entity.Property(e => e.Texto)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdPublicacionNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.IdPublicacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comentario_ibfk_1");
            });

            modelBuilder.Entity<Donacione>(entity =>
            {
                entity.ToTable("donaciones");

                entity.HasComment("Tabla que almacena todas las donaciones realizadas dentro de la plataforma");

                entity.HasIndex(e => e.IdMeta, "ID_Meta");

                entity.HasIndex(e => e.IdOrganizacion, "ID_Organizacion");

                entity.HasIndex(e => e.IdUsuario, "ID_Usuario");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cantidad).HasComment("Este campo almacena la cantidad dinero en pesos que se dono");

                entity.Property(e => e.IdMeta)
                    .HasColumnName("ID_Meta")
                    .HasComment("Este campo almacenna la ID de una meta cuando se realiza una donación a cierta. De otro modo será nulo");

                entity.Property(e => e.IdOrganizacion)
                    .HasColumnName("ID_Organizacion")
                    .HasComment("Este campo almancena la ID de la organización a la que se esta donando.");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("ID_Usuario")
                    .HasComment("Este campo almacena la ID del usuario que realiza la donación");

                entity.Property(e => e.Mensaje)
                    .HasMaxLength(50)
                    .HasComment("Este campo almacena un mensaje que el usuario escriba a la hora de hacer la donación. Puede ser nulo");

                entity.HasOne(d => d.IdMetaNavigation)
                    .WithMany(p => p.Donaciones)
                    .HasForeignKey(d => d.IdMeta)
                    .HasConstraintName("donaciones_ibfk_3");

                entity.HasOne(d => d.IdOrganizacionNavigation)
                    .WithMany(p => p.DonacioneIdOrganizacionNavigations)
                    .HasForeignKey(d => d.IdOrganizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("donaciones_ibfk_1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.DonacioneIdUsuarioNavigations)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("donaciones_ibfk_2");
            });

            modelBuilder.Entity<Especie>(entity =>
            {
                entity.ToTable("especie");

                entity.HasComment("Tabla que almacena la lista de animales que se pueden publicar en la plataforma");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NombreEspecie)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Nombre_Especie");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("estado");

                entity.HasComment("Estados de la República Mexicana");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Abreviatura)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasComment("Abreviatura - Nombre abreviado de la entidad");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("Nombre - Nombre de la entidad");
            });

            modelBuilder.Entity<EstadoMascotum>(entity =>
            {
                entity.ToTable("estado_mascota");

                entity.HasComment("Tabla que almacena todos los posibles estados de una mascota dentro de la plataforma");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.EstadoNombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Estado_Nombre")
                    .HasComment("Nombre del estado");
            });

            modelBuilder.Entity<Formulario>(entity =>
            {
                entity.ToTable("formulario");

                entity.HasIndex(e => e.IdUsuario, "ID_Usuario");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("ID_Usuario")
                    .HasComment("ID del usuario al que pertenece el formulario");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasComment("Titulo del formulario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Formularios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("formulario_ibfk_1");
            });

            modelBuilder.Entity<Imagene>(entity =>
            {
                entity.ToTable("imagenes");

                entity.HasComment("Tabla que almacena las direcciones de todas las imagenes correspondientes ");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ruta)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ImagenesMascotum>(entity =>
            {
                entity.HasKey(e => new { e.IdMascota, e.IdImagen })
                    .HasName("PRIMARY");

                entity.ToTable("imagenes_mascota");

                entity.HasComment("Esta tabla almacena la relación entre las mascotas y sus respectivas fotos");

                entity.HasIndex(e => e.IdImagen, "ID_Imagen");

                entity.Property(e => e.IdMascota)
                    .HasColumnName("ID_Mascota")
                    .HasComment("ID de la mascota");

                entity.Property(e => e.IdImagen)
                    .HasColumnName("ID_Imagen")
                    .HasComment("ID de la imagen a la que se asocia la mascota");

                entity.HasOne(d => d.IdImagenNavigation)
                    .WithMany(p => p.ImagenesMascota)
                    .HasForeignKey(d => d.IdImagen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("imagenes_mascota_ibfk_2");

                entity.HasOne(d => d.IdMascotaNavigation)
                    .WithMany(p => p.ImagenesMascota)
                    .HasForeignKey(d => d.IdMascota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("imagenes_mascota_ibfk_1");
            });

            modelBuilder.Entity<Interese>(entity =>
            {
                entity.HasKey(e => new { e.IdEspecie, e.IdUsuario })
                    .HasName("PRIMARY");

                entity.ToTable("intereses");

                entity.HasComment("Tabla que permite que almacenar los intereses de los usuarios. Relaciona cada usuario con un posbile animal de la lista de especies");

                entity.HasIndex(e => e.IdUsuario, "ID_Usuario");

                entity.Property(e => e.IdEspecie)
                    .HasColumnName("ID_Especie")
                    .HasComment("ID_Especie -> Especie(ID)\n\nEspecie elegida por el usuario (Pueden ser varias)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("ID_Usuario")
                    .HasComment("ID_Usuario -> Usuario(ID)\n");

                entity.HasOne(d => d.IdEspecieNavigation)
                    .WithMany(p => p.Intereses)
                    .HasForeignKey(d => d.IdEspecie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("intereses_ibfk_1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Intereses)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("intereses_ibfk_2");
            });

            modelBuilder.Entity<Mascotum>(entity =>
            {
                entity.ToTable("mascota");

                entity.HasComment("Tabla que almacena todas las mascotas que se suben a la plataforma");

                entity.HasIndex(e => e.IdEspecie, "ID_Especie");

                entity.HasIndex(e => e.IdEstado, "ID_Estado");

                entity.HasIndex(e => e.IdPublicacion, "ID_Publicacion");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).IsRequired();

                entity.Property(e => e.IdEspecie).HasColumnName("ID_Especie");

                entity.Property(e => e.IdEstado).HasColumnName("ID_Estado");

                entity.Property(e => e.IdPublicacion)
                    .HasColumnName("ID_Publicacion")
                    .HasComment("ID de la publicación a la que pertenece dicha mascota");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdEspecieNavigation)
                    .WithMany(p => p.Mascota)
                    .HasForeignKey(d => d.IdEspecie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mascota_ibfk_3");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Mascota)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mascota_ibfk_1");

                entity.HasOne(d => d.IdPublicacionNavigation)
                    .WithMany(p => p.Mascota)
                    .HasForeignKey(d => d.IdPublicacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mascota_ibfk_2");
            });

            modelBuilder.Entity<Mensaje>(entity =>
            {
                entity.ToTable("mensajes");

                entity.HasComment("Tabla que almacena todos los mensajes enviados dentro de la plataforma");

                entity.HasIndex(e => e.UsuarioDestinatario, "Usuario_Destinatario");

                entity.HasIndex(e => e.UsuarioRemitente, "Usuario_Remitente");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Texto)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasComment("Contenido del mensaje enviado");

                entity.Property(e => e.UsuarioDestinatario)
                    .HasColumnName("Usuario_Destinatario")
                    .HasComment("ID Usuario que recibe el mensaje");

                entity.Property(e => e.UsuarioRemitente)
                    .HasColumnName("Usuario_Remitente")
                    .HasComment("ID Usuario que manda el mensaje");

                entity.HasOne(d => d.UsuarioDestinatarioNavigation)
                    .WithMany(p => p.MensajeUsuarioDestinatarioNavigations)
                    .HasForeignKey(d => d.UsuarioDestinatario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mensajes_ibfk_2");

                entity.HasOne(d => d.UsuarioRemitenteNavigation)
                    .WithMany(p => p.MensajeUsuarioRemitenteNavigations)
                    .HasForeignKey(d => d.UsuarioRemitente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mensajes_ibfk_1");
            });

            modelBuilder.Entity<Meta>(entity =>
            {
                entity.ToTable("metas");

                entity.HasIndex(e => e.IdMascota, "ID_Mascota");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IdMascota).HasColumnName("ID_Mascota");

                entity.HasOne(d => d.IdMascotaNavigation)
                    .WithMany(p => p.Meta)
                    .HasForeignKey(d => d.IdMascota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("metas_ibfk_1");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.ToTable("municipio");

                entity.HasComment("Municipio de la República Mexicana");

                entity.HasIndex(e => e.IdEstado, "ID_Estado");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("ID_Estado")
                    .HasComment("Relación: estado -> id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasComment("Nombre – Nombre del municipio");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("municipio_ibfk_1");
            });

            modelBuilder.Entity<Notificacione>(entity =>
            {
                entity.ToTable("notificaciones");

                entity.HasComment("Esta tabla almacena todas las notificaciones generadas dentro de la plataforma");

                entity.HasIndex(e => e.IdUsuario, "ID_Usuario");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Información que muestra la notificación");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("ID_Usuario")
                    .HasComment("ID_Usuario al cual pertenece la notificación");

                entity.Property(e => e.Origen)
                    .IsRequired()
                    .HasComment("Campo que almacena el origen (url) del origen la notificación");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Notificaciones)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("notificaciones_ibfk_1");
            });

            modelBuilder.Entity<OpcionesRespuestasPregunta>(entity =>
            {
                entity.ToTable("opciones_respuestas_preguntas");

                entity.HasIndex(e => e.IdPregunta, "ID_Pregunta");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdPregunta).HasColumnName("ID_Pregunta");

                entity.Property(e => e.OpcionRespuesta)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("Opcion_Respuesta");

                entity.HasOne(d => d.IdPreguntaNavigation)
                    .WithMany(p => p.OpcionesRespuestasPregunta)
                    .HasForeignKey(d => d.IdPregunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("opciones_respuestas_preguntas_ibfk_1");
            });

            modelBuilder.Entity<Paso>(entity =>
            {
                entity.ToTable("paso");

                entity.HasIndex(e => e.IdProtocolo, "ID_Protocolo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Archivo).HasMaxLength(255);

                entity.Property(e => e.Descripcion).IsRequired();

                entity.Property(e => e.IdProtocolo).HasColumnName("ID_Protocolo");

                entity.Property(e => e.TituloPaso)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Titulo_Paso");

                entity.HasOne(d => d.IdProtocoloNavigation)
                    .WithMany(p => p.Pasos)
                    .HasForeignKey(d => d.IdProtocolo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("paso_ibfk_1");
            });

            modelBuilder.Entity<PasoMascotum>(entity =>
            {
                entity.ToTable("paso_mascota");

                entity.HasComment("Esta tabla guarda el progreso de los procesos de adopcion");

                entity.HasIndex(e => e.IdMascota, "ID_Mascota");

                entity.HasIndex(e => e.IdPaso, "ID_Paso");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Archivo)
                    .HasMaxLength(255)
                    .HasComment("Campo que almacena la dirección de un archivo que sea necesario para el paso");

                entity.Property(e => e.Completado).HasComment("Variable que almacena si se ha completado o no este paso");

                entity.Property(e => e.IdMascota)
                    .HasColumnName("ID_Mascota")
                    .HasComment("ID de la mascota a la cual se esta llevando en el proceso de adopción");

                entity.Property(e => e.IdPaso)
                    .HasColumnName("ID_Paso")
                    .HasComment("ID del paso del cual se guarda el progreso");

                entity.HasOne(d => d.IdMascotaNavigation)
                    .WithMany(p => p.PasoMascota)
                    .HasForeignKey(d => d.IdMascota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("paso_mascota_ibfk_1");

                entity.HasOne(d => d.IdPasoNavigation)
                    .WithMany(p => p.PasoMascota)
                    .HasForeignKey(d => d.IdPaso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("paso_mascota_ibfk_2");
            });

            modelBuilder.Entity<Pregunta>(entity =>
            {
                entity.ToTable("preguntas");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Pregunta1)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("Pregunta");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<PreguntasFormulario>(entity =>
            {
                entity.HasKey(e => new { e.IdPregunta, e.IdFormulario })
                    .HasName("PRIMARY");

                entity.ToTable("preguntas_formulario");

                entity.HasIndex(e => e.IdFormulario, "ID_Formulario");

                entity.Property(e => e.IdPregunta).HasColumnName("ID_Pregunta");

                entity.Property(e => e.IdFormulario).HasColumnName("ID_Formulario");

                entity.HasOne(d => d.IdFormularioNavigation)
                    .WithMany(p => p.PreguntasFormularios)
                    .HasForeignKey(d => d.IdFormulario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preguntas_formulario_ibfk_2");

                entity.HasOne(d => d.IdPreguntaNavigation)
                    .WithMany(p => p.PreguntasFormularios)
                    .HasForeignKey(d => d.IdPregunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preguntas_formulario_ibfk_1");
            });

            modelBuilder.Entity<Protocolo>(entity =>
            {
                entity.ToTable("protocolos");

                entity.HasComment("Tabla que almacena datos de los protocolos creados por los usuarios dentro de la plataforma");

                entity.HasIndex(e => e.IdFormulario, "protocolos_ibfk_1_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).IsRequired();

                entity.Property(e => e.IdFormulario).HasColumnName("ID_Formulario");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdFormularioNavigation)
                    .WithMany(p => p.Protocolos)
                    .HasForeignKey(d => d.IdFormulario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("protocolos_ibfk_1");
            });

            modelBuilder.Entity<Publicacion>(entity =>
            {
                entity.ToTable("publicacion");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).IsRequired();

                entity.Property(e => e.ReportesPeso)
                    .HasColumnName("Reportes_Peso")
                    .HasComment("Reportes_Peso indica la cantidad acumulada de peso por los reportes que haya recibido la publicacion");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Registro>(entity =>
            {
                entity.ToTable("registro");

                entity.HasIndex(e => e.Municipio, "Municipio");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.DocumentoIdentidad)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("Documento_Identidad");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TipoUsuario).HasColumnName("Tipo_Usuario");

                entity.HasOne(d => d.MunicipioNavigation)
                    .WithMany(p => p.Registros)
                    .HasForeignKey(d => d.Municipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("registro_ibfk_1");
            });

            modelBuilder.Entity<Reporte>(entity =>
            {
                entity.ToTable("reportes");

                entity.HasComment("Tabla que almacena los reportes generados por los usuarios");

                entity.HasIndex(e => e.IdUsuarioReporta, "ID_Usuario_Reporta");

                entity.HasIndex(e => e.IdUsuarioReportado, "ID_Usuario_Reportado");

                entity.HasIndex(e => e.TipoReporte, "Tipo_Reporte");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdUsuarioReporta).HasColumnName("ID_Usuario_Reporta");

                entity.Property(e => e.IdUsuarioReportado).HasColumnName("ID_Usuario_Reportado");

                entity.Property(e => e.Origen)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Razon).HasComment("Razon será usada cuando el tipo de reporte corresponda a \"Otro\" y almacenará la razon escrita por el usuario. De otro modo permanecerá nulo");

                entity.Property(e => e.TipoOrigen).HasColumnName("Tipo_Origen");

                entity.Property(e => e.TipoReporte).HasColumnName("Tipo_Reporte");

                entity.HasOne(d => d.IdUsuarioReportaNavigation)
                    .WithMany(p => p.ReporteIdUsuarioReportaNavigations)
                    .HasForeignKey(d => d.IdUsuarioReporta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reportes_ibfk_1");

                entity.HasOne(d => d.IdUsuarioReportadoNavigation)
                    .WithMany(p => p.ReporteIdUsuarioReportadoNavigations)
                    .HasForeignKey(d => d.IdUsuarioReportado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reportes_ibfk_2");

                entity.HasOne(d => d.TipoReporteNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.TipoReporte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reportes_ibfk_3");
            });

            modelBuilder.Entity<Respuesta>(entity =>
            {
                entity.ToTable("respuestas");

                entity.HasIndex(e => e.IdPregunta, "ID_Pregunta");

                entity.HasIndex(e => e.IdSolicitud, "ID_Solicitud");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdPregunta).HasColumnName("ID_Pregunta");

                entity.Property(e => e.IdSolicitud).HasColumnName("ID_Solicitud");

                entity.Property(e => e.Respuesta1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("Respuesta");

                entity.HasOne(d => d.IdPreguntaNavigation)
                    .WithMany(p => p.Respuesta)
                    .HasForeignKey(d => d.IdPregunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("respuestas_ibfk_1");

                entity.HasOne(d => d.IdSolicitudNavigation)
                    .WithMany(p => p.Respuesta)
                    .HasForeignKey(d => d.IdSolicitud)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("respuestas_ibfk_2");
            });

            modelBuilder.Entity<Solicitude>(entity =>
            {
                entity.ToTable("solicitudes");

                entity.HasComment("Guarda la solicitud realizadas en la plataforma ");

                entity.HasIndex(e => e.IdMascota, "ID_Mascota");

                entity.HasIndex(e => e.IdUsuario, "ID_Usuario");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdMascota)
                    .HasColumnName("ID_Mascota")
                    .HasComment("ID de la mascota a la que el Usuario realiza su solicitud");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("ID_Usuario")
                    .HasComment("ID Usuario que realiza la solicitud");

                entity.HasOne(d => d.IdMascotaNavigation)
                    .WithMany(p => p.Solicitudes)
                    .HasForeignKey(d => d.IdMascota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("solicitudes_ibfk_2");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Solicitudes)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("solicitudes_ibfk_1");
            });

            modelBuilder.Entity<TipoReporte>(entity =>
            {
                entity.ToTable("tipo_reporte");

                entity.HasComment("Tabla que almacena los tipos de reportes que existen dentro de la plataforma");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Peso).HasComment("Peso puede ser nulo pues el reporte del tipo \"otro\", tiene peso variable");

                entity.Property(e => e.Razon)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.HasComment("Tabla para almacenar usuarios del tipo Comun y Organizacion");

                entity.HasIndex(e => e.FkRegistro, "FK_Registro");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FkRegistro).HasColumnName("FK_Registro");

                entity.Property(e => e.FotoPerfil)
                    .HasMaxLength(255)
                    .HasColumnName("Foto_Perfil")
                    .HasComment("Foto_Perfil hace referencia a una url de una imagen");

                entity.HasOne(d => d.FkRegistroNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.FkRegistro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuario_ibfk_1");
            });

            modelBuilder.Entity<UsuarioBloqueado>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdBloqueado })
                    .HasName("PRIMARY");

                entity.ToTable("usuario_bloqueado");

                entity.HasIndex(e => e.IdBloqueado, "ID_Bloqueado");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("ID_Usuario")
                    .HasComment("Usuario que bloquea");

                entity.Property(e => e.IdBloqueado)
                    .HasColumnName("ID_Bloqueado")
                    .HasComment("Usuario que ID_Usuario bloquea");

                entity.HasOne(d => d.IdBloqueadoNavigation)
                    .WithMany(p => p.UsuarioBloqueadoIdBloqueadoNavigations)
                    .HasForeignKey(d => d.IdBloqueado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuario_bloqueado_ibfk_2");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioBloqueadoIdUsuarioNavigations)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuario_bloqueado_ibfk_1");
            });

            modelBuilder.Entity<UsuarioModerador>(entity =>
            {
                entity.ToTable("usuario_moderador");

                entity.HasIndex(e => e.IdRegistro, "ID_Registro");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdRegistro)
                    .HasColumnName("ID_Registro")
                    .HasComment("ID_Registro -> Registro(ID)");

                entity.HasOne(d => d.IdRegistroNavigation)
                    .WithMany(p => p.UsuarioModeradors)
                    .HasForeignKey(d => d.IdRegistro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuario_moderador_ibfk_1");
            });

            modelBuilder.Entity<Vacuna>(entity =>
            {
                entity.ToTable("vacunas");

                entity.HasComment("Tabla que almacena todas las vacunas disponibles para cada especie");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NombreVacuna)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("Nombre_Vacuna");
            });

            modelBuilder.Entity<VacunasEspecie>(entity =>
            {
                entity.HasKey(e => new { e.IdVacuna, e.IdEspecie })
                    .HasName("PRIMARY");

                entity.ToTable("vacunas_especie");

                entity.HasIndex(e => e.IdEspecie, "ID_Especie");

                entity.Property(e => e.IdVacuna).HasColumnName("ID_Vacuna");

                entity.Property(e => e.IdEspecie).HasColumnName("ID_Especie");

                entity.HasOne(d => d.IdEspecieNavigation)
                    .WithMany(p => p.VacunasEspecies)
                    .HasForeignKey(d => d.IdEspecie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vacunas_especie_ibfk_2");

                entity.HasOne(d => d.IdVacunaNavigation)
                    .WithMany(p => p.VacunasEspecies)
                    .HasForeignKey(d => d.IdVacuna)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vacunas_especie_ibfk_1");
            });

            modelBuilder.Entity<VacunasMascotum>(entity =>
            {
                entity.HasKey(e => new { e.IdMascota, e.IdVacuna })
                    .HasName("PRIMARY");

                entity.ToTable("vacunas_mascota");

                entity.HasComment("Esta tabla almacena la relación entre las mascotas y sus respectivas vacunas");

                entity.HasIndex(e => e.IdVacuna, "ID_Vacuna");

                entity.Property(e => e.IdMascota)
                    .HasColumnName("ID_Mascota")
                    .HasComment("ID de la mascota a la que se le asocia la vacuna");

                entity.Property(e => e.IdVacuna)
                    .HasColumnName("ID_Vacuna")
                    .HasComment("El id de la vacuna que se le asocia a la mascota");

                entity.HasOne(d => d.IdMascotaNavigation)
                    .WithMany(p => p.VacunasMascota)
                    .HasForeignKey(d => d.IdMascota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vacunas_mascota_ibfk_1");

                entity.HasOne(d => d.IdVacunaNavigation)
                    .WithMany(p => p.VacunasMascota)
                    .HasForeignKey(d => d.IdVacuna)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vacunas_mascota_ibfk_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
