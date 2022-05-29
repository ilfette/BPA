using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using University.Domain.Core;

#nullable disable

namespace University.Infrastructure.Data
{
    public partial class UniversityContext : DbContext
    {
        public UniversityContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }
       

        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<Lection> Lections { get; set; }
        public virtual DbSet<LectionLector> LectionLectors { get; set; }
        public virtual DbSet<Lector> Lectors { get; set; }
        public virtual DbSet<StudHw> StudHws { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
               optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=University;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            
           // optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=efbasicsappdb;Trusted_Connection=True;");
  
            
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("attendance");

                entity.HasIndex(e => e.LrLnId, "IX_attendance_Lr_Ln_Id");

                entity.HasIndex(e => e.StudentId, "IX_attendance_Student_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LrLnId).HasColumnName("Lr_Ln_Id");

                entity.Property(e => e.StudentId).HasColumnName("Student_Id");

                entity.HasOne(d => d.LrLn)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.LrLnId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_attendance_ToLections_Lectors");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_attendance_ToStudents");
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasIndex(e => e.LrLnId, "IX_Homeworks_Lr_ln_ID");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LrLnId).HasColumnName("Lr_ln_ID");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.LrLn)
                    .WithMany(p => p.Homeworks)
                    .HasForeignKey(d => d.LrLnId)
                    .HasConstraintName("FK_Homeworks_ToLections_Lectors");
            });

            modelBuilder.Entity<Lection>(entity =>
            {
                entity.ToTable("lections");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NameSubj)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Name_subj")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<LectionLector>(entity =>
            {
                entity.ToTable("lection_lectors");

                entity.HasIndex(e => e.LectionId, "IX_lection_lectors_Lection_Id");

                entity.HasIndex(e => e.LectorId, "IX_lection_lectors_Lector_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.LectionId).HasColumnName("Lection_Id");

                entity.Property(e => e.LectorId).HasColumnName("Lector_Id");

                entity.HasOne(d => d.Lection)
                    .WithMany(p => p.LectionLectors)
                    .HasForeignKey(d => d.LectionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_lection_lectors_ToLections");

                entity.HasOne(d => d.Lector)
                    .WithMany(p => p.LectionLectors)
                    .HasForeignKey(d => d.LectorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_lection_lectors_ToLectors");
            });

            modelBuilder.Entity<Lector>(entity =>
            {
                entity.ToTable("lectors");

                entity.HasIndex(e => e.Email, "IX_Table_Email");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Degree)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Tel).HasMaxLength(50);
            });

            modelBuilder.Entity<StudHw>(entity =>
            {
                entity.ToTable("stud_hw");

                entity.HasIndex(e => e.HomeworkId, "IX_stud_hw_Homework_Id");

                entity.HasIndex(e => e.StudentId, "IX_stud_hw_Student_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.HomeworkId).HasColumnName("Homework_Id");

                entity.Property(e => e.StudentId).HasColumnName("Student_Id");

                entity.HasOne(d => d.Homework)
                    .WithMany(p => p.StudHws)
                    .HasForeignKey(d => d.HomeworkId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_stud_hw_ToHomeworks");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudHws)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_stud_hw_ToStudents");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("students");

                entity.HasIndex(e => e.Email, "IX_student_Email")
                    .IsUnique()
                    .HasFilter("([Email] IS NOT NULL)");

                entity.HasIndex(e => e.Recordbook, "IX_student_Recordbook")
                    .IsUnique()
                    .HasFilter("([Recordbook] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Group)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('?? ???????')")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Recordbook)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Tel).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
