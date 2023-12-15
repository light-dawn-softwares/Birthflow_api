using System;
using System.Collections.Generic;
using Birthflow_api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Birthflow_api.Infrastructure;

public partial class BirthflowDbContext : DbContext
{
    public BirthflowDbContext()
    {
    }

    public BirthflowDbContext(DbContextOptions<BirthflowDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BirthNote> BirthNotes { get; set; }

    public virtual DbSet<CervicalDilation> CervicalDilations { get; set; }

    public virtual DbSet<Configuration> Configurations { get; set; }

    public virtual DbSet<FetalHeartRate> FetalHeartRates { get; set; }

    public virtual DbSet<FrequencyContraction> FrequencyContractions { get; set; }

    public virtual DbSet<MedicalSurveillance> MedicalSurveillances { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationPartograph> NotificationPartographs { get; set; }

    public virtual DbSet<NotificationType> NotificationTypes { get; set; }

    public virtual DbSet<Observation> Observations { get; set; }

    public virtual DbSet<Partograph> Partographs { get; set; }

    public virtual DbSet<PartographState> PartographStates { get; set; }

    public virtual DbSet<Password> Passwords { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vpp> Vpps { get; set; }

    public virtual DbSet<WorkTime> WorkTimes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-5O3USRP;Database=BirthflowDb;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BirthNote>(entity =>
        {
            entity.HasKey(e => e.FrequencyContractionsId).HasName("PK__BirthNot__F096EDF17EEC8310");

            entity.ToTable("BirthNote");

            entity.Property(e => e.FrequencyContractionsId).HasColumnName("FrequencyContractionsID");
            entity.Property(e => e.Alumbramiento)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Apgar)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Caputto)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Circular)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Expulsivo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Hour)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.HuellaPlantar)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Lamniotico)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LAmniotico");
            entity.Property(e => e.Meconio)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Miccion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Pa)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PA");
            entity.Property(e => e.PartographId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PartographID");
            entity.Property(e => e.Placenta)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Temperatura)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Partograph).WithMany(p => p.BirthNotes)
                .HasForeignKey(d => d.PartographId)
                .HasConstraintName("FK__BirthNote__Parto__49C3F6B7");
        });

        modelBuilder.Entity<CervicalDilation>(entity =>
        {
            entity.HasKey(e => e.CervicalDilationId).HasName("PK__Cervical__70FDA8EC7F01B8D2");

            entity.Property(e => e.CervicalDilationId).HasColumnName("CervicalDilationID");
            entity.Property(e => e.Hour).HasColumnType("datetime");
            entity.Property(e => e.PartographId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PartographID");
            entity.Property(e => e.RemOram).HasColumnName("RemORam");
            entity.Property(e => e.Value).HasColumnType("decimal(2, 2)");

            entity.HasOne(d => d.Partograph).WithMany(p => p.CervicalDilations)
                .HasForeignKey(d => d.PartographId)
                .HasConstraintName("FK__CervicalD__Parto__38996AB5");
        });

        modelBuilder.Entity<Configuration>(entity =>
        {
            entity.HasKey(e => e.PasswordId).HasName("PK__Configur__EA7BF0E80F3B8678");

            entity.Property(e => e.PasswordId)
                .ValueGeneratedNever()
                .HasColumnName("PasswordID");
            entity.Property(e => e.Lenguage)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Configurations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Configura__UserI__29572725");
        });

        modelBuilder.Entity<FetalHeartRate>(entity =>
        {
            entity.HasKey(e => e.FetalHeartRateId).HasName("PK__FetalHea__B0B308012B350366");

            entity.Property(e => e.FetalHeartRateId).HasColumnName("FetalHeartRateID");
            entity.Property(e => e.PartographId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PartographID");
            entity.Property(e => e.Time).HasColumnType("datetime");
            entity.Property(e => e.Value)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Partograph).WithMany(p => p.FetalHeartRates)
                .HasForeignKey(d => d.PartographId)
                .HasConstraintName("FK__FetalHear__Parto__440B1D61");
        });

        modelBuilder.Entity<FrequencyContraction>(entity =>
        {
            entity.HasKey(e => e.FrequencyContractionsId).HasName("PK__Frequenc__F096EDF1E25565FD");

            entity.Property(e => e.FrequencyContractionsId).HasColumnName("FrequencyContractionsID");
            entity.Property(e => e.PartographId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PartographID");
            entity.Property(e => e.Time).HasColumnType("datetime");
            entity.Property(e => e.Value)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Partograph).WithMany(p => p.FrequencyContractions)
                .HasForeignKey(d => d.PartographId)
                .HasConstraintName("FK__Frequency__Parto__46E78A0C");
        });

        modelBuilder.Entity<MedicalSurveillance>(entity =>
        {
            entity.HasKey(e => e.MedicalSurveillanceId).HasName("PK__MedicalS__8055CD4EB5D370CF");

            entity.Property(e => e.MedicalSurveillanceId).HasColumnName("MedicalSurveillanceID");
            entity.Property(e => e.ArterialPressure)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ContractionsDuration)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FetalHeartRate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FrequencyContractions)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MaternalPosition)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MaternalPulse)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PainIntensity)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PainLocation)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.PartographId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PartographID");
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.Partograph).WithMany(p => p.MedicalSurveillances)
                .HasForeignKey(d => d.PartographId)
                .HasConstraintName("FK__MedicalSu__Parto__3B75D760");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E3274CEC19D");

            entity.Property(e => e.NotificationId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("NotificationID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.NotificationTypeId).HasColumnName("NotificationTypeID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.NotificationType).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.NotificationTypeId)
                .HasConstraintName("FK__Notificat__Notif__4F7CD00D");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Notificat__UserI__4E88ABD4");
        });

        modelBuilder.Entity<NotificationPartograph>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NotificationPartograph");

            entity.Property(e => e.NotificationId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("NotificationID");
            entity.Property(e => e.PartographId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PartographID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Notification).WithMany()
                .HasForeignKey(d => d.NotificationId)
                .HasConstraintName("FK__Notificat__Notif__5441852A");

            entity.HasOne(d => d.Partograph).WithMany()
                .HasForeignKey(d => d.PartographId)
                .HasConstraintName("FK__Notificat__Parto__52593CB8");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Notificat__UserI__534D60F1");
        });

        modelBuilder.Entity<NotificationType>(entity =>
        {
            entity.HasKey(e => e.NotificationTypeId).HasName("PK__Notifica__299002A1FA42C727");

            entity.Property(e => e.NotificationTypeId).HasColumnName("NotificationTypeID");
            entity.Property(e => e.Description)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Header)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Observation>(entity =>
        {
            entity.HasKey(e => e.MedicalSurveillanceId).HasName("PK__Observat__8055CD4E1743C8D3");

            entity.Property(e => e.MedicalSurveillanceId)
                .ValueGeneratedNever()
                .HasColumnName("MedicalSurveillanceID");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Header)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.HasOne(d => d.MedicalSurveillance).WithOne(p => p.Observation)
                .HasForeignKey<Observation>(d => d.MedicalSurveillanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Observati__Medic__3E52440B");
        });

        modelBuilder.Entity<Partograph>(entity =>
        {
            entity.HasKey(e => e.PartographId).HasName("PK__Partogra__D0EC20BC5D7FD6CF");

            entity.Property(e => e.PartographId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PartographID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.RecordNumber)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Partographs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Partograp__UserI__2C3393D0");
        });

        modelBuilder.Entity<PartographState>(entity =>
        {
            entity.HasKey(e => e.PartographId).HasName("PK__Partogra__D0EC20BC4529E6D6");

            entity.Property(e => e.PartographId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PartographID");
            entity.Property(e => e.LastModification)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Partograph).WithOne(p => p.PartographState)
                .HasForeignKey<PartographState>(d => d.PartographId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Partograp__Parto__31EC6D26");
        });

        modelBuilder.Entity<Password>(entity =>
        {
            entity.HasKey(e => e.PasswordId).HasName("PK__Password__EA7BF0E89CD6A41B");

            entity.Property(e => e.PasswordId)
                .ValueGeneratedNever()
                .HasColumnName("PasswordID");
            entity.Property(e => e.Password1)
                .HasMaxLength(64)
                .HasColumnName("Password");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Passwords)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Passwords__UserI__267ABA7A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC62A4EA3E");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vpp>(entity =>
        {
            entity.HasKey(e => e.VppId).HasName("PK__Vpps__086F0E45D2F29F8C");

            entity.Property(e => e.VppId).HasColumnName("VppID");
            entity.Property(e => e.HodgePlane)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.PartographId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PartographID");
            entity.Property(e => e.Position)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.Partograph).WithMany(p => p.Vpps)
                .HasForeignKey(d => d.PartographId)
                .HasConstraintName("FK__Vpps__Partograph__412EB0B6");
        });

        modelBuilder.Entity<WorkTime>(entity =>
        {
            entity.HasKey(e => e.PartographId).HasName("PK__WorkTime__D0EC20BC5216D6A9");

            entity.Property(e => e.PartographId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PartographID");
            entity.Property(e => e.Membranas)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Paridad)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Posicion)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Partograph).WithOne(p => p.WorkTime)
                .HasForeignKey<WorkTime>(d => d.PartographId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkTimes__Parto__2F10007B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
