using Microsoft.EntityFrameworkCore;
using CasoGestionMatriculas.Operation.Domain.Model.Aggregates;
using CasoGestionMatriculas.Operation.Domain.Model.Entities;

namespace CasoGestionMatriculas.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public partial class CasoGestionMatriculasContext : DbContext
    {
        public CasoGestionMatriculasContext() { }

        public CasoGestionMatriculasContext
            (DbContextOptions<CasoGestionMatriculasContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("server=LAPTOP-G7UV3UKS;database=CasoGestionMatriculas;user=AaronPC;password=123;TrustServerCertificate=true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_course_id");

                entity.ToTable("courses");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.EnrollmentDate).HasColumnName("enrollment_date");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_registration_id");

                entity.ToTable("registrations");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CourseId).HasColumnName("courses_id");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");
                entity.Property(e => e.StudentId).HasColumnName("students_id");

                entity.HasOne(d => d.Course).WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_registrations_courses_id");

                entity.HasOne(d => d.Student).WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_registrations_students_id");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_student_id");

                entity.ToTable("students");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Birthday).HasColumnName("birthday");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");
                entity.Property(e => e.Firstname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("firstname");
                entity.Property(e => e.Genre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("genre");
                entity.Property(e => e.Lastname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lastname");
                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}