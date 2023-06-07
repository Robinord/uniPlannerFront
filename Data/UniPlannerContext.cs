using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using uniPlanner.Data;
using uniPlanner.Models;

namespace uniPlanner.Data;

public partial class UniPlannerContext : IdentityDbContext
{
    public UniPlannerContext()
    {
    }

    public UniPlannerContext(DbContextOptions<UniPlannerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApprovedAS> ApprovedAs { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<MajorsOffered> MajorsOffereds { get; set; }

    public virtual DbSet<Programmes> Programmes { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<UniProgrammes> UniProgrammes { get; set; }

    public virtual DbSet<UniversityInfo> UniversityInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=uniPlanner; Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApprovedAS>(entity =>
        {
            entity.HasKey(e => e.As).HasName("PK__approved__3214AD3055543901");

            entity.ToTable("approvedAS", "secondary");

            entity.Property(e => e.As)
                .ValueGeneratedNever()
                .HasColumnName("AS");
            entity.Property(e => e.Assessment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("assessment");
            entity.Property(e => e.Credits).HasColumnName("credits");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .HasColumnName("subject");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__grades__FB4362D92464A083");

            entity.ToTable("grades", "secondary");

            entity.Property(e => e.GradeId).HasColumnName("gradeID");
            entity.Property(e => e.As).HasColumnName("AS");
            entity.Property(e => e.Grade1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("grade");
            entity.Property(e => e.StudentEmail)
                .HasMaxLength(255)
                .HasColumnName("studentEmail");

            entity.HasOne(d => d.AsNavigation).WithMany(p => p.Grades)
                .HasForeignKey(d => d.As)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__grades__AS__38996AB5");

            entity.HasOne(d => d.StudentEmailNavigation).WithMany(p => p.Grades)
                .HasForeignKey(d => d.StudentEmail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__grades__studentE__37A5467C");
        });

        modelBuilder.Entity<MajorsOffered>(entity =>
        {
            entity.HasKey(e => e.MajorOfferedId).HasName("PK__majorsOf__D7F3B4837E436A25");

            entity.ToTable("majorsOffered", "uni");

            entity.Property(e => e.MajorOfferedId).HasColumnName("majorOfferedID");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .HasColumnName("link");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UniProgrammeId).HasColumnName("uniProgrammeID");

            entity.HasOne(d => d.UniProgramme).WithMany(p => p.MajorsOffereds)
                .HasForeignKey(d => d.UniProgrammeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__majorsOff__uniPr__2F10007B");
        });

        modelBuilder.Entity<Programmes>(entity =>
        {
            entity.HasKey(e => e.ProgrammeId).HasName("PK__programm__E49167C2486CC947");

            entity.ToTable("programmes", "uni");

            entity.Property(e => e.ProgrammeId).HasColumnName("programmeID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__students__AB6E6165966B031F");

            entity.ToTable("students", "secondary");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Region)
                .HasMaxLength(255)
                .HasColumnName("region");
        });

        modelBuilder.Entity<UniProgrammes>(entity =>
        {
            entity.HasKey(e => e.UniProgrammeId).HasName("PK__uniProgr__7678E0EAAE88DEA1");

            entity.ToTable("uniProgrammes", "uni");

            entity.Property(e => e.UniProgrammeId).HasColumnName("uniProgrammeID");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .HasColumnName("link");
            entity.Property(e => e.ProgrammeId).HasColumnName("programmeID");
            entity.Property(e => e.RankScore).HasColumnName("rankScore");
            entity.Property(e => e.UniversityId).HasColumnName("universityID");

            entity.HasOne(d => d.Programme).WithMany(p => p.UniProgrammes)
                .HasForeignKey(d => d.ProgrammeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__uniProgra__progr__2B3F6F97");

            entity.HasOne(d => d.University).WithMany(p => p.UniProgrammes)
                .HasForeignKey(d => d.UniversityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__uniProgra__unive__2A4B4B5E");
        });

        modelBuilder.Entity<UniversityInfo>(entity =>
        {
            entity.HasKey(e => e.UniversityId).HasName("PK__universi__F5A408A0EAEECF5B");

            entity.ToTable("universityInfo", "uni");

            entity.Property(e => e.UniversityId).HasColumnName("universityID");
            entity.Property(e => e.Arwurank).HasColumnName("ARWUrank");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Qsrank).HasColumnName("QSrank");
            entity.Property(e => e.Region)
                .HasMaxLength(255)
                .HasColumnName("region");
            entity.Property(e => e.Therank).HasColumnName("THErank");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
