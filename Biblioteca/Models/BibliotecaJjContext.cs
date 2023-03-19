using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models;

public partial class BibliotecaJjContext : DbContext
{
    public BibliotecaJjContext()
    {
    }

    public BibliotecaJjContext(DbContextOptions<BibliotecaJjContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<CarreraJj> CarreraJjs { get; set; }

    public virtual DbSet<CategoriaEdad> CategoriaEdads { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<EstadoCivil> EstadoCivils { get; set; }

    public virtual DbSet<EstudianteJj> EstudianteJjs { get; set; }

    public virtual DbSet<FacultadJj> FacultadJjs { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<TipoLibro> TipoLibros { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersRol> UsersRols { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=PC_INGLABCS322C;Initial Catalog=BibliotecaJJ;User ID=sa;Password=labcom,2015;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.IdAutor).HasName("PK__Autor__0DC8163E121C947E");

            entity.ToTable("Autor");

            entity.Property(e => e.IdAutor).HasColumnName("Id_Autor");
            entity.Property(e => e.NombreAutor)
                .HasMaxLength(50)
                .HasColumnName("Nombre_Autor");
        });

        modelBuilder.Entity<CarreraJj>(entity =>
        {
            entity.HasKey(e => e.IdCarrera).HasName("PK__CarreraJ__A74A0EFFF692BA78");

            entity.ToTable("CarreraJJ");

            entity.Property(e => e.IdCarrera).HasColumnName("id_Carrera");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.IdFacultad).HasColumnName("id_Facultad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdFacultadNavigation).WithMany(p => p.CarreraJjs)
                .HasForeignKey(d => d.IdFacultad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarreraJJ__id_Fa__38996AB5");
        });

        modelBuilder.Entity<CategoriaEdad>(entity =>
        {
            entity.HasKey(e => e.IdCategoriaEdad).HasName("PK__Categori__FAEA5A4E070FFBD0");

            entity.ToTable("Categoria_Edad");

            entity.Property(e => e.IdCategoriaEdad).HasColumnName("Id_Categoria_Edad");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(50)
                .HasColumnName("Nombre_Categoria");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estado__AB2EB6F89572A845");

            entity.ToTable("Estado");

            entity.Property(e => e.IdEstado).HasColumnName("Id_Estado");
            entity.Property(e => e.NombreEstado)
                .HasMaxLength(50)
                .HasColumnName("Nombre_Estado");
        });

        modelBuilder.Entity<EstadoCivil>(entity =>
        {
            entity.HasKey(e => e.IdEstadoCivil).HasName("PK__Estado_C__CAE6659AEC3B031B");

            entity.ToTable("Estado_Civil");

            entity.Property(e => e.IdEstadoCivil).HasColumnName("Id_Estado_Civil");
            entity.Property(e => e.NombreEstadoCivil)
                .HasMaxLength(50)
                .HasColumnName("Nombre_Estado_Civil");
        });

        modelBuilder.Entity<EstudianteJj>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante).HasName("PK__Estudian__EC5D9B1C39ECF763");

            entity.ToTable("EstudianteJJ");

            entity.Property(e => e.IdEstudiante).HasColumnName("id_Estudiante");
            entity.Property(e => e.Cedula)
                .HasMaxLength(10)
                .HasColumnName("cedula");
            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(35)
                .HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.IdCarrera).HasColumnName("id_Carrera");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(9)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.EstudianteJjs)
                .HasForeignKey(d => d.IdCarrera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Estudiant__id_Ca__3B75D760");
        });

        modelBuilder.Entity<FacultadJj>(entity =>
        {
            entity.HasKey(e => e.IdFacultad).HasName("PK__Facultad__102C3C9BA0483C9E");

            entity.ToTable("FacultadJJ");

            entity.Property(e => e.IdFacultad).HasColumnName("id_Facultad");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PK__Genero__E76DD66E92CE45C1");

            entity.ToTable("Genero");

            entity.Property(e => e.IdGenero).HasColumnName("Id_Genero");
            entity.Property(e => e.NombreGenero)
                .HasMaxLength(50)
                .HasColumnName("Nombre_Genero");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PK__Libro__FFFE46405DCFBE4C");

            entity.ToTable("Libro");

            entity.Property(e => e.IdLibro).HasColumnName("Id_Libro");
            entity.Property(e => e.IdAutor).HasColumnName("Id_Autor");
            entity.Property(e => e.IdCategoriaEdad).HasColumnName("Id_Categoria_Edad");
            entity.Property(e => e.IdEstado).HasColumnName("Id_Estado");
            entity.Property(e => e.IdTipoLibro).HasColumnName("Id_Tipo_Libro");
            entity.Property(e => e.Titulo).HasMaxLength(50);

            entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdAutor)
                .HasConstraintName("FK__Libro__Id_Autor__4D94879B");

            entity.HasOne(d => d.IdCategoriaEdadNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdCategoriaEdad)
                .HasConstraintName("FK__Libro__Id_Catego__5070F446");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Libro__Id_Estado__4E88ABD4");

            entity.HasOne(d => d.IdTipoLibroNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdTipoLibro)
                .HasConstraintName("FK__Libro__Id_Tipo_L__4F7CD00D");

            entity.HasOne(d => d.MateriaNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.Materia)
                .HasConstraintName("FK__Libro__Materia__5165187F");
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.IdMateria).HasName("PK__Materia__D3FE91FA0F4671AF");

            entity.Property(e => e.IdMateria).HasColumnName("Id_Materia");
            entity.Property(e => e.NombreMateria)
                .HasMaxLength(50)
                .HasColumnName("Nombre_Materia");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo).HasName("PK__Prestamo__996D6033F857229E");

            entity.ToTable("Prestamo");

            entity.Property(e => e.IdPrestamo).HasColumnName("Id_Prestamo");
            entity.Property(e => e.FechaPrestamo)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("Fecha_Prestamo");
            entity.Property(e => e.IdEstudiante).HasColumnName("id_Estudiante");
            entity.Property(e => e.IdLibro).HasColumnName("Id_Libro");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.Observaciones).HasMaxLength(500);
            entity.Property(e => e.TiempoPrestamo)
                .HasMaxLength(50)
                .HasColumnName("Tiempo_Prestamo");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prestamo__id_Est__6B24EA82");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdLibro)
                .HasConstraintName("FK__Prestamo__Id_Lib__6A30C649");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Prestamo__Id_Usu__693CA210");
        });

        modelBuilder.Entity<TipoLibro>(entity =>
        {
            entity.HasKey(e => e.IdTipoLibro).HasName("PK__Tipo_Lib__CA420F7CD5022B1F");

            entity.ToTable("Tipo_Libro");

            entity.Property(e => e.IdTipoLibro).HasColumnName("Id_Tipo_Libro");
            entity.Property(e => e.NombreTipoLibro)
                .HasMaxLength(50)
                .HasColumnName("Nombre_Tipo_Libro");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Users__63C76BE27203E0A1");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.ApellidoUsuario)
                .HasMaxLength(50)
                .HasColumnName("Apellido_Usuario");
            entity.Property(e => e.CedulaUsuario)
                .HasMaxLength(50)
                .HasColumnName("Cedula_Usuario");
            entity.Property(e => e.Direccion).HasMaxLength(50);
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.IdEstadoCivil).HasColumnName("Id_Estado_Civil");
            entity.Property(e => e.IdGenero).HasColumnName("Id_Genero");
            entity.Property(e => e.IdUsersRol).HasColumnName("Id_Users_Rol");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .HasColumnName("Nombre_Usuario");
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.UserPassword).HasMaxLength(50);

            entity.HasOne(d => d.IdEstadoCivilNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdEstadoCivil)
                .HasConstraintName("FK__Users__Id_Estado__5535A963");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdGenero)
                .HasConstraintName("FK__Users__Id_Genero__5441852A");

            entity.HasOne(d => d.IdUsersRolNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdUsersRol)
                .HasConstraintName("FK__Users__Id_Users___5629CD9C");
        });

        modelBuilder.Entity<UsersRol>(entity =>
        {
            entity.HasKey(e => e.IdUsersRol).HasName("PK__Users_Ro__78378E2356C40EC3");

            entity.ToTable("Users_Rol");

            entity.Property(e => e.IdUsersRol).HasColumnName("Id_Users_Rol");
            entity.Property(e => e.NombreUsers)
                .HasMaxLength(50)
                .HasColumnName("Nombre_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
