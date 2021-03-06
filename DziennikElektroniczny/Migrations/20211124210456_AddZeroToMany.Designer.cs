// <auto-generated />
using System;
using DziennikElektroniczny.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DziennikElektroniczny.Migrations
{
    [DbContext(typeof(DziennikElektronicznyContext))]
    [Migration("20211124210456_AddZeroToMany")]
    partial class AddZeroToMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DziennikElektroniczny.Models.Event", b =>
                {
                    b.Property<int>("event_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime>("end_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("start_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("event_id");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.EventParticipator", b =>
                {
                    b.Property<int>("EventParticipatorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("EventParticipatorId");

                    b.HasIndex("EventId");

                    b.HasIndex("PersonId");

                    b.ToTable("EventParticipators");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Parent", b =>
                {
                    b.Property<int>("ParentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ParentPersonId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("StudentPersonId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("ParentId");

                    b.HasIndex("ParentPersonId");

                    b.HasIndex("StudentPersonId");

                    b.ToTable("parents");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("PersonalInfoId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("PersonId");

                    b.HasIndex("PersonalInfoId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.PersonalInfo", b =>
                {
                    b.Property<int>("PersonalInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("SecondName")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("PersonalInfoId");

                    b.ToTable("PersonalInfos");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.EventParticipator", b =>
                {
                    b.HasOne("DziennikElektroniczny.Models.Event", "Event")
                        .WithMany("event_participators")
                        .HasForeignKey("EventId");

                    b.HasOne("DziennikElektroniczny.Models.Person", "Person")
                        .WithMany("EventParticipators")
                        .HasForeignKey("PersonId");

                    b.Navigation("Event");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Parent", b =>
                {
                    b.HasOne("DziennikElektroniczny.Models.Person", "ParentPerson")
                        .WithMany("ParentPersons")
                        .HasForeignKey("ParentPersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DziennikElektroniczny.Models.Person", "StudentPerson")
                        .WithMany("StudentPersons")
                        .HasForeignKey("StudentPersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ParentPerson");

                    b.Navigation("StudentPerson");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Person", b =>
                {
                    b.HasOne("DziennikElektroniczny.Models.PersonalInfo", "PersonalInfo")
                        .WithMany("Persons")
                        .HasForeignKey("PersonalInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Event", b =>
                {
                    b.Navigation("event_participators");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Person", b =>
                {
                    b.Navigation("EventParticipators");

                    b.Navigation("ParentPersons");

                    b.Navigation("StudentPersons");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.PersonalInfo", b =>
                {
                    b.Navigation("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
