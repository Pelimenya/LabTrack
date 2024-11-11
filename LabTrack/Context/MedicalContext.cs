using System;
using System.Collections.Generic;
using LabTrack.Entites;
using Microsoft.EntityFrameworkCore;

namespace LabTrack.Context;

public partial class MedicalContext : DbContext
{
    public MedicalContext()
    {
    }

    public MedicalContext(DbContextOptions<MedicalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientDoctorAppointment> PatientDoctorAppointments { get; set; }

    public virtual DbSet<ReservationSchedule> ReservationSchedules { get; set; }

    public virtual DbSet<RoomReservation> RoomReservations { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<ScheduleException> ScheduleExceptions { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=\"localhost\"; port=\"5432\"; Database=\"MedicalLabDataBase\"; Username=\"Pelimenya\"; Password=\"root\";");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.IdDoctor).HasName("Doctors_pkey");

            entity.Property(e => e.IdDoctor).HasColumnName("Id_Doctor");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_Name");
            entity.Property(e => e.IdSpecialization).HasColumnName("Id_Specialization");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last_Name");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.Password).HasMaxLength(50);

            entity.HasOne(d => d.IdSpecializationNavigation).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.IdSpecialization)
                .HasConstraintName("Doctors_Id_Specialization_fkey");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.IdEvent).HasName("Events_pkey");

            entity.Property(e => e.IdEvent).HasColumnName("Id_Event");
            entity.Property(e => e.EventDate).HasColumnName("Event_Date");
            entity.Property(e => e.EventEndTime).HasColumnName("Event_End_Time");
            entity.Property(e => e.EventStartTime).HasColumnName("Event_Start_Time");
            entity.Property(e => e.EventType)
                .HasMaxLength(50)
                .HasColumnName("Event_Type");
            entity.Property(e => e.IdRoomReservation).HasColumnName("Id_Room_Reservation");

            entity.HasOne(d => d.IdRoomReservationNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdRoomReservation)
                .HasConstraintName("Events_Id_Room_Reservation_fkey");
        });

        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.HasKey(e => e.IdMedicalRecord).HasName("Medical_Records_pkey");

            entity.ToTable("Medical_Records");

            entity.Property(e => e.IdMedicalRecord).HasColumnName("Id_Medical_Record");
            entity.Property(e => e.Diagnosis).HasMaxLength(255);
            entity.Property(e => e.IdDoctor).HasColumnName("Id_Doctor");
            entity.Property(e => e.IdPatient).HasColumnName("Id_Patient");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.IdDoctor)
                .HasConstraintName("Medical_Records_Id_Doctor_fkey");

            entity.HasOne(d => d.IdPatientNavigation).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.IdPatient)
                .HasConstraintName("Medical_Records_Id_Patient_fkey");
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.HasKey(e => e.IdMedicine).HasName("Medicines_pkey");

            entity.Property(e => e.IdMedicine).HasColumnName("Id_Medicine");
            entity.Property(e => e.IdWarehouse).HasColumnName("Id_Warehouse");
            entity.Property(e => e.Manufacturer).HasMaxLength(255);
            entity.Property(e => e.MedicineName)
                .HasMaxLength(255)
                .HasColumnName("Medicine_Name");
            entity.Property(e => e.StockQuantity).HasColumnName("Stock_Quantity");
            entity.Property(e => e.TradeName)
                .HasMaxLength(255)
                .HasColumnName("Trade_Name");

            entity.HasOne(d => d.IdWarehouseNavigation).WithMany(p => p.Medicines)
                .HasForeignKey(d => d.IdWarehouse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Medicines_Id_Warehouse_fkey");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.IdPatient).HasName("Patients_pkey");

            entity.Property(e => e.IdPatient).HasColumnName("Id_Patient");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.DateLastVisit).HasColumnName("Date_Last_Visit");
            entity.Property(e => e.DateNextVisit).HasColumnName("Date_Next_Visit");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_Name");
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.HealthHistory).HasColumnName("Health_History");
            entity.Property(e => e.InsurancePolicyEndDate).HasColumnName("Insurance_Policy_EndDate");
            entity.Property(e => e.InsurancePolicyNumber)
                .HasMaxLength(18)
                .HasColumnName("Insurance_Policy_Number");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MedicalCardNumber)
                .HasMaxLength(10)
                .HasColumnName("Medical_Card_Number");
            entity.Property(e => e.MedicalCardStartDate).HasColumnName("Medical_Card_StartDate");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.PassportIssuedBy)
                .HasMaxLength(150)
                .HasColumnName("Passport_IssuedBy");
            entity.Property(e => e.PassportNumber)
                .HasMaxLength(6)
                .HasColumnName("Passport_Number");
            entity.Property(e => e.PassportSeries)
                .HasMaxLength(4)
                .HasColumnName("Passport_Series");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.Photo).HasMaxLength(150);
        });

        modelBuilder.Entity<PatientDoctorAppointment>(entity =>
        {
            entity.HasKey(e => e.IdPatientDoctorAppointment).HasName("Patient_Doctor_Appointment_pkey");

            entity.ToTable("Patient_Doctor_Appointment");

            entity.Property(e => e.IdPatientDoctorAppointment).HasColumnName("Id_Patient_Doctor_Appointment");
            entity.Property(e => e.AppointmentDate).HasColumnName("Appointment_Date");
            entity.Property(e => e.AppointmentEndTime).HasColumnName("Appointment_End_Time");
            entity.Property(e => e.AppointmentStartTime).HasColumnName("Appointment_Start_Time");
            entity.Property(e => e.IdDoctor).HasColumnName("Id_Doctor");
            entity.Property(e => e.IdPatient).HasColumnName("Id_Patient");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.PatientDoctorAppointments)
                .HasForeignKey(d => d.IdDoctor)
                .HasConstraintName("Patient_Doctor_Appointment_Id_Doctor_fkey");

            entity.HasOne(d => d.IdPatientNavigation).WithMany(p => p.PatientDoctorAppointments)
                .HasForeignKey(d => d.IdPatient)
                .HasConstraintName("Patient_Doctor_Appointment_Id_Patient_fkey");
        });

        modelBuilder.Entity<ReservationSchedule>(entity =>
        {
            entity.HasKey(e => e.IdReservationSchedule).HasName("Reservation_Schedule_pkey");

            entity.ToTable("Reservation_Schedule");

            entity.Property(e => e.IdReservationSchedule).HasColumnName("Id_Reservation_Schedule");
            entity.Property(e => e.IdRoomReservation).HasColumnName("Id_Room_Reservation");
            entity.Property(e => e.IdSchedule).HasColumnName("Id_Schedule");
            entity.Property(e => e.ReservationDate).HasColumnName("Reservation_Date");
            entity.Property(e => e.ReservationEndTime).HasColumnName("Reservation_End_Time");
            entity.Property(e => e.ReservationStartTime).HasColumnName("Reservation_Start_Time");

            entity.HasOne(d => d.IdRoomReservationNavigation).WithMany(p => p.ReservationSchedules)
                .HasForeignKey(d => d.IdRoomReservation)
                .HasConstraintName("Reservation_Schedule_Id_Room_Reservation_fkey");

            entity.HasOne(d => d.IdScheduleNavigation).WithMany(p => p.ReservationSchedules)
                .HasForeignKey(d => d.IdSchedule)
                .HasConstraintName("Reservation_Schedule_Id_Schedule_fkey");
        });

        modelBuilder.Entity<RoomReservation>(entity =>
        {
            entity.HasKey(e => e.IdRoomReservation).HasName("Room_Reservation_pkey");

            entity.ToTable("Room_Reservation");

            entity.Property(e => e.IdRoomReservation).HasColumnName("Id_Room_Reservation");
            entity.Property(e => e.RoomType)
                .HasMaxLength(50)
                .HasColumnName("Room_Type");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.IdSchedule).HasName("Schedule_pkey");

            entity.ToTable("Schedule");

            entity.Property(e => e.IdSchedule).HasColumnName("Id_Schedule");
            entity.Property(e => e.EndTime).HasColumnName("End_Time");
            entity.Property(e => e.IdDoctor).HasColumnName("Id_Doctor");
            entity.Property(e => e.ScheduleDate).HasColumnName("Schedule_Date");
            entity.Property(e => e.StartTime).HasColumnName("Start_Time");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.IdDoctor)
                .HasConstraintName("Schedule_Id_Doctor_fkey");
        });

        modelBuilder.Entity<ScheduleException>(entity =>
        {
            entity.HasKey(e => e.IdException).HasName("Schedule_Exceptions_pkey");

            entity.ToTable("Schedule_Exceptions");

            entity.Property(e => e.IdException).HasColumnName("Id_Exception");
            entity.Property(e => e.ExceptionDate).HasColumnName("Exception_Date");
            entity.Property(e => e.ExceptionDescription).HasColumnName("Exception_Description");
            entity.Property(e => e.ExceptionTime).HasColumnName("Exception_Time");
            entity.Property(e => e.IdSchedule).HasColumnName("Id_Schedule");

            entity.HasOne(d => d.IdScheduleNavigation).WithMany(p => p.ScheduleExceptions)
                .HasForeignKey(d => d.IdSchedule)
                .HasConstraintName("Schedule_Exceptions_Id_Schedule_fkey");
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(e => e.IdSpecialization).HasName("Specialization_pkey");

            entity.ToTable("Specialization");

            entity.Property(e => e.IdSpecialization).HasColumnName("Id_Specialization");
            entity.Property(e => e.SpecializationName)
                .HasMaxLength(50)
                .HasColumnName("Specialization_Name");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.IdWarehouse).HasName("Warehouse_pkey");

            entity.ToTable("Warehouse");

            entity.Property(e => e.IdWarehouse).HasColumnName("Id_Warehouse");
            entity.Property(e => e.WarehouseName)
                .HasMaxLength(255)
                .HasColumnName("Warehouse_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
