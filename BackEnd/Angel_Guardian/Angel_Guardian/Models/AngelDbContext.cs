using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angel_Guardian.Models;

namespace Angel_Guardian.Models
{
    public class AngelDbContext : DbContext
    {
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Comprobante> Comprobante { get; set; }
        public DbSet<ComprobanteDetalle> ComprobanteDetalle { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Estatus> Estatus { get; set; }
        public DbSet<Imagen> Imagen { get; set; }
        public DbSet<Negocio> Negocio { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public AngelDbContext() { }
        public AngelDbContext(DbContextOptions<AngelDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comprobante>().HasKey(comprobante => comprobante.IdComprobante);
            modelBuilder.Entity<Comprobante>(comprobante => {
                comprobante.Property(e => e.IdUsuario)
                    .IsRequired(true);
                comprobante.Property(e => e.IdNegocio)
                    .IsRequired(true);
                comprobante.Property(e => e.Efectivo)
                    .IsRequired(true);
                comprobante.Property(e => e.IdEstatus)
                    .IsRequired(true);
                comprobante.Property(e => e.IdDireccion)
                    .IsRequired(true);
                comprobante.Property(e => e.Puntuacion)
                    .IsRequired(true);
                comprobante.Property(e => e.Precio)
                    .IsRequired(true);
                comprobante.Property(e => e.Pago)
                    .IsRequired(true);
                comprobante.Property(e => e.Cambio)
                    .IsRequired(true);
                comprobante.Property(e => e.Fecha)
                    .IsRequired(true);

                comprobante
                    .HasOne(e => e.Usuario)
                    .WithMany(y => y.Comprobantes)
                    .HasForeignKey(e => e.IdUsuario)
                    .OnDelete(DeleteBehavior.Cascade);
                comprobante
                    .HasOne(e => e.Negocio)
                    .WithMany(y => y.Comprobantes)
                    .HasForeignKey(e => e.IdNegocio)
                    .OnDelete(DeleteBehavior.Cascade);
                comprobante
                    .HasOne(e => e.Direccion)
                    .WithMany(y => y.Comprobantes)
                    .HasForeignKey(e => e.IdDireccion)
                    .OnDelete(DeleteBehavior.Cascade);
                comprobante
                    .HasOne(e => e.Estatus)
                    .WithMany(y => y.Comprobantes)
                    .HasForeignKey(e => e.IdEstatus)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ComprobanteDetalle>().HasKey(comprobantedetalle => comprobantedetalle.IdComprobanteDetalle);
            modelBuilder.Entity<ComprobanteDetalle>(comprobantedetalle => {
                comprobantedetalle.Property(e => e.IdComprobante).IsRequired(true);
                comprobantedetalle.Property(e => e.IdServicio).IsRequired(true);
                comprobantedetalle.Property(e => e.Puntuacion).IsRequired(true);
                comprobantedetalle.Property(e => e.Precio).IsRequired(true);
                comprobantedetalle.Property(e => e.Cambio).IsRequired(true);
                comprobantedetalle.Property(e => e.Fecha).IsRequired(true);
                comprobantedetalle.Property(e => e.Cantidad).IsRequired(true);

                comprobantedetalle
                    .HasOne(e => e.Comprobante)
                    .WithMany(y => y.ComprobanteDetalle)
                    .HasForeignKey(e => e.IdComprobante)
                    .OnDelete(DeleteBehavior.Cascade);
                comprobantedetalle
                    .HasOne(e => e.Servicio)
                    .WithMany(y => y.ComprobanteDetalle)
                    .HasForeignKey(e => e.IdServicio)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Direccion>().HasKey(direcccion => direcccion.IdDireccion);
            modelBuilder.Entity<Direccion>(direcccion => {
                direcccion.Property(e => e.IdUsuario)
                    .IsRequired(true);
                direcccion.Property(e => e.IdEstado)
                    .IsRequired(true);
                direcccion.Property(e => e.IdMunicipio)
                    .IsRequired(true);
                direcccion.Property(e => e.Calle)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(200);
                direcccion.Property(e => e.Colonia)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(50);
                direcccion.Property(e => e.NumeroInterior)
                    .IsRequired(true);

                direcccion
                    .HasOne(e => e.Usuario)
                    .WithMany(y => y.Direccion)
                    .HasForeignKey(e => e.IdUsuario)
                    .OnDelete(DeleteBehavior.Cascade);
                direcccion
                    .HasOne(e => e.Estado)
                    .WithMany(y => y.Direccion)
                    .HasForeignKey(e => e.IdEstado)
                    .OnDelete(DeleteBehavior.Cascade);
                direcccion
                    .HasOne(e => e.Municipio)
                    .WithMany(y => y.Direccion)
                    .HasForeignKey(e => e.IdMunicipio)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Estado>().HasKey(estado => estado.IdEstado);
            modelBuilder.Entity<Estado>(estado => {
                estado.Property(e => e.Nombre)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Estatus>().HasKey(estatus => estatus.IdEstatus);
            modelBuilder.Entity<Estatus>(estatus => {
                estatus.Property(e => e.Nombre)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(50);
                estatus.Property(e => e.Fecha).IsRequired(true);
            });

            modelBuilder.Entity<Imagen>().HasKey(imagen => imagen.IdImagen);
            modelBuilder.Entity<Imagen>(imagen => {
                imagen.Property(e => e.Nombre)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(500);
                imagen.Property(e => e.Ruta)
                    .IsRequired(true)
                    .IsUnicode(false);
                imagen.Property(e => e.Size).IsRequired(true);
                imagen.Property(e => e.Fecha).IsRequired(true);
            });

            modelBuilder.Entity<Municipio>().HasKey(municipio => municipio.IdMunicipio);
            modelBuilder.Entity<Municipio>(municipio => {
                municipio.Property(e => e.IdEstado)
                    .IsRequired(true);
                municipio.Property(e => e.Nombre)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(200);

                municipio
                    .HasOne(e => e.Estado)
                    .WithMany(y => y.Municipio)
                    .HasForeignKey(e => e.IdEstado)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Negocio>().HasKey(negocio => negocio.IdNegocio);
            modelBuilder.Entity<Negocio>(negocio => {
                negocio.Property(e => e.IdImagen).IsRequired(true);
                negocio.Property(e => e.IdEstado).IsRequired(true);
                negocio.Property(e => e.IdMunicipio).IsRequired(true);
                negocio.Property(e => e.IdUsuario).IsRequired(true);
                negocio.Property(e => e.Nombre)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(100);
                negocio.Property(e => e.RazonSocial)
                    .IsRequired(true)
                    .IsUnicode(false);
                negocio.Property(e => e.PuntuacionPromedio).IsRequired(true);
                negocio.Property(e => e.Fecha).IsRequired(true);
                negocio.Property(e => e.Calle)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(200);
                negocio.Property(e => e.Colonia)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(50);
                negocio.Property(e => e.NumeroInterior)
                    .IsRequired(true);
                negocio.Property(e => e.Fecha)
                    .IsRequired(true);
                negocio.Property(e => e.Activo)
                    .IsRequired(true);

                negocio
                    .HasOne(e => e.Imagen)
                    .WithMany(y => y.Negocio)
                    .HasForeignKey(e => e.IdImagen)
                    .HasConstraintName("fk_Negocio_Imagen")
                    .OnDelete(DeleteBehavior.Cascade);
                negocio
                    .HasOne(e => e.Municipio)
                    .WithMany(y => y.Negocio)
                    .HasForeignKey(e => e.IdMunicipio)
                    .HasConstraintName("fk_Negocio_Municipio")
                    .OnDelete(DeleteBehavior.Cascade);
                negocio
                    .HasOne(e => e.Estado)
                    .WithMany(y => y.Negocio)
                    .HasForeignKey(e => e.IdEstado)
                    .HasConstraintName("fk_Negocio_Estado")
                    .OnDelete(DeleteBehavior.Cascade);
                negocio
                    .HasOne(e => e.Usuario)
                    .WithMany(y => y.Negocio)
                    .HasForeignKey(e => e.IdUsuario)
                    .HasConstraintName("fk_Negocio_Usuario")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Servicio>().HasKey(servicio => servicio.IdServicio);
            modelBuilder.Entity<Servicio>(servicio =>
            {
                servicio.Property(e => e.IdNegocio).IsRequired(true);
                servicio.Property(e => e.Puntuacion).IsRequired(true);
                servicio.Property(e => e.Nombre)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .IsRequired(true);
                servicio.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .IsRequired(true);
                servicio.Property(e => e.Duracion)
                    .IsRequired(true);
                servicio.Property(e => e.Precio)
                    .IsRequired(true);
                servicio.Property(e => e.Fecha)
                    .IsRequired(true);
                servicio.Property(e => e.Activo)
                   .IsRequired(true);

                servicio
                    .HasOne(e => e.Negocio)
                    .WithMany(y => y.Servicio)
                    .HasForeignKey(e => e.IdNegocio)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Usuario>(Usuario => {
                Usuario.HasKey(e => e.IdUsuario);
                Usuario.Property(e => e.NickName)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(50);
                Usuario.Property(e => e.NombreUsuario)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(200);
                Usuario.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(50);
                Usuario.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(50);
                Usuario.Property(e => e.Celular)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(100); 
                Usuario.Property(e => e.Email)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(50);
                Usuario.Property(e => e.Consumidor).IsRequired();
                Usuario.Property(e => e.Fecha).IsRequired();
            });
        }
    }
}
