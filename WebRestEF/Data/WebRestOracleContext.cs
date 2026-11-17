using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebRest.EF.Models;

namespace WebRest.EF.Data;

public partial class WebRestOracleContext : DbContext
{
    public WebRestOracleContext(DbContextOptions<WebRestOracleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Address { get; set; }

    public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserPasskeys> AspNetUserPasskeys { get; set; }

    public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }

    public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }

    public virtual DbSet<Country> Country { get; set; }

    public virtual DbSet<Course> Course { get; set; }

    public virtual DbSet<Department> Department { get; set; }

    public virtual DbSet<Employee> Employee { get; set; }

    public virtual DbSet<Employer> Employer { get; set; }

    public virtual DbSet<Employment> Employment { get; set; }

    public virtual DbSet<EmploymentPay> EmploymentPay { get; set; }

    public virtual DbSet<Enrollment> Enrollment { get; set; }

    public virtual DbSet<Grade> Grade { get; set; }

    public virtual DbSet<GradeConversion> GradeConversion { get; set; }

    public virtual DbSet<GradeType> GradeType { get; set; }

    public virtual DbSet<GradeTypeWeight> GradeTypeWeight { get; set; }

    public virtual DbSet<Instructor> Instructor { get; set; }

    public virtual DbSet<InstructorAddress> InstructorAddress { get; set; }

    public virtual DbSet<Job> Job { get; set; }

    public virtual DbSet<Location> Location { get; set; }

    public virtual DbSet<Manager> Manager { get; set; }

    public virtual DbSet<MidtermLocation> MidtermLocation { get; set; }

    public virtual DbSet<Region> Region { get; set; }

    public virtual DbSet<Section> Section { get; set; }

    public virtual DbSet<SectionLocation> SectionLocation { get; set; }

    public virtual DbSet<StateProvince> StateProvince { get; set; }

    public virtual DbSet<Student> Student { get; set; }

    public virtual DbSet<StudentAddress> StudentAddress { get; set; }

    public virtual DbSet<StudentEmployer> StudentEmployer { get; set; }

    public virtual DbSet<VwRegionEurope> VwRegionEurope { get; set; }

    public virtual DbSet<Zipcode> Zipcode { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("UD_AMENDOZA")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressGuid).HasName("ADDRESS_PK");

            entity.Property(e => e.AddressGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.St).IsFixedLength();

            entity.HasOne(d => d.Zipcode).WithMany(p => p.Address)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ADDRESS_FK1");
        });

        modelBuilder.Entity<AspNetUsers>(entity =>
        {
            entity.HasMany(d => d.Role).WithMany(p => p.User)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRoles",
                    r => r.HasOne<AspNetRoles>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUsers>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryGuid).HasName("COUNTRY_PK");

            entity.Property(e => e.CountryGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CountryId).IsFixedLength();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Region).WithMany(p => p.Country)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("COUNTRY_FK");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseGuid).HasName("COURSE_PK");

            entity.Property(e => e.CourseGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Prerequisite).WithMany(p => p.InversePrerequisite).HasConstraintName("COURSE_FK1");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentGuid).HasName("DEPARTMENT_PK");

            entity.Property(e => e.DepartmentGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Location).WithMany(p => p.Department)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DEPARTMENT_FK1");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeGuid).HasName("EMPLOYEE_PK");

            entity.Property(e => e.EmployeeGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Employer>(entity =>
        {
            entity.HasKey(e => e.EmployerGuid).HasName("EMPLOYER_PK");

            entity.Property(e => e.EmployerGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Employment>(entity =>
        {
            entity.HasKey(e => e.EmploymentGuid).HasName("EMPLOYMENT_PK");

            entity.Property(e => e.EmploymentGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Department).WithMany(p => p.Employment).HasConstraintName("EMPLOYMENT_FK3");

            entity.HasOne(d => d.Employee).WithMany(p => p.Employment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EMPLOYMENT_FK1");

            entity.HasOne(d => d.Job).WithMany(p => p.Employment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EMPLOYMENT_FK2");
        });

        modelBuilder.Entity<EmploymentPay>(entity =>
        {
            entity.HasKey(e => e.EmploymentPayGuid).HasName("EMPLOYMENT_PAY_PK");

            entity.Property(e => e.EmploymentPayGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Employment).WithMany(p => p.EmploymentPay)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EMPLOYMENT_PAY_FK1");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentGuid).HasName("ENROLLMENT_PK");

            entity.Property(e => e.EnrollmentGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Section).WithMany(p => p.Enrollment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ENROLLMENT_FK1");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ENROLLMENT_FK2");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeGuid).HasName("GRADE_PK");

            entity.Property(e => e.GradeGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();

            entity.HasOne(d => d.GradeType).WithMany(p => p.Grade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GRADE_FK1");

            entity.HasOne(d => d.Section).WithMany(p => p.Grade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GRADE_FK2");

            entity.HasOne(d => d.Student).WithMany(p => p.Grade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GRADE_FK3");
        });

        modelBuilder.Entity<GradeConversion>(entity =>
        {
            entity.HasKey(e => e.GradeConversionGuid).HasName("GRADE_CONVERSION_PK");

            entity.Property(e => e.GradeConversionGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<GradeType>(entity =>
        {
            entity.HasKey(e => e.GradeTypeGuid).HasName("GRADE_TYPE_PK");

            entity.Property(e => e.GradeTypeGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.GradeTypeCode).IsFixedLength();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<GradeTypeWeight>(entity =>
        {
            entity.HasKey(e => e.GradeTypeWeightGuid).HasName("GRADE_TYPE_WEIGHT_PK");

            entity.Property(e => e.GradeTypeWeightGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.DropLowest).IsFixedLength();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();

            entity.HasOne(d => d.GradeType).WithMany(p => p.GradeTypeWeight)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GRADE_TYPE_WEIGHT_FK2");

            entity.HasOne(d => d.Section).WithMany(p => p.GradeTypeWeight)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GRADE_TYPE_WEIGHT_FK1");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InstructorGuid).HasName("INSTRUCTOR_PK");

            entity.Property(e => e.InstructorGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<InstructorAddress>(entity =>
        {
            entity.HasKey(e => e.InstructorAddressGuid).HasName("INSTRUCTOR_ADDRESS_PK");

            entity.Property(e => e.InstructorAddressGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.AddressGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Address).WithMany(p => p.InstructorAddress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("INSTRUCTOR_ADDRESS_FK2");

            entity.HasOne(d => d.Instructor).WithMany(p => p.InstructorAddress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("INSTRUCTOR_ADDRESS_FK1");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobGuid).HasName("JOB_PK");

            entity.Property(e => e.JobGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationGuid).HasName("LOCATION_PK");

            entity.Property(e => e.LocationGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.ManagerGuid).HasName("MANAGER_PK");

            entity.Property(e => e.ManagerGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Department).WithMany(p => p.Manager)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MANAGER_FK2");

            entity.HasOne(d => d.Employment).WithMany(p => p.Manager)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MANAGER_FK1");
        });

        modelBuilder.Entity<MidtermLocation>(entity =>
        {
            entity.HasKey(e => e.LocationGuid).HasName("MIDTERM_LOCATION_PK");

            entity.Property(e => e.LocationGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Country).WithMany(p => p.MidtermLocation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("LOCATION_FK1");

            entity.HasOne(d => d.StateProvince).WithMany(p => p.MidtermLocation).HasConstraintName("LOCATION_FK2");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionGuid).HasName("REGION_PK");

            entity.Property(e => e.RegionGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionGuid).HasName("SECTION_PK");

            entity.Property(e => e.SectionGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Course).WithMany(p => p.Section)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SECTION_FK1");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Section)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SECTION_FK2");
        });

        modelBuilder.Entity<SectionLocation>(entity =>
        {
            entity.HasKey(e => e.SectionLocationGuid).HasName("SECTION_LOCATION_PK");

            entity.Property(e => e.SectionLocationGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Location).WithMany(p => p.SectionLocation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SECTION_LOCATION_FK2");

            entity.HasOne(d => d.Section).WithMany(p => p.SectionLocation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SECTION_LOCATION_FK1");
        });

        modelBuilder.Entity<StateProvince>(entity =>
        {
            entity.HasKey(e => e.StateProvinceGuid).HasName("STATE_PROVINCE_PK");

            entity.Property(e => e.StateProvinceGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentGuid).HasName("STUDENT_PK");

            entity.Property(e => e.StudentGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<StudentAddress>(entity =>
        {
            entity.HasKey(e => e.StudentAddressGuid).HasName("STUDENT_ADDRESS_PK");

            entity.Property(e => e.StudentAddressGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.AddressGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Address).WithMany(p => p.StudentAddress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("STUDENT_ADDRESS_FK2");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentAddress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("STUDENT_ADDRESS_FK1");
        });

        modelBuilder.Entity<StudentEmployer>(entity =>
        {
            entity.HasKey(e => e.StudentEmployerGuid).HasName("STUDENT_EMPLOYER_PK");

            entity.Property(e => e.StudentEmployerGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Employer).WithMany(p => p.StudentEmployer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("STUDENT_EMPLOYER_FK1");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentEmployer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("STUDENT_EMPLOYER_FK2");
        });

        modelBuilder.Entity<VwRegionEurope>(entity =>
        {
            entity.ToView("VW_REGION_EUROPE");
        });

        modelBuilder.Entity<Zipcode>(entity =>
        {
            entity.HasKey(e => e.ZipcodeGuid).HasName("ZIPCODE_PK");

            entity.Property(e => e.ZipcodeGuid).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
