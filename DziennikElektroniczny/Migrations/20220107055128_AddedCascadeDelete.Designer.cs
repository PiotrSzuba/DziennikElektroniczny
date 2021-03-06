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
    [Migration("20220107055128_AddedCascadeDelete")]
    partial class AddedCascadeDelete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DziennikElektroniczny.Models.Attendance", b =>
                {
                    b.Property<int>("AttendanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AbsenceNote")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int?>("LessonId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentPersonId")
                        .HasColumnType("int");

                    b.Property<int>("WasPresent")
                        .HasColumnType("int");

                    b.HasKey("AttendanceId");

                    b.HasIndex("LessonId");

                    b.HasIndex("StudentPersonId");

                    b.ToTable("Attendance");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.ClassRoom", b =>
                {
                    b.Property<int>("ClassRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Building")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Floor")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("ClassRoomId");

                    b.ToTable("ClassRoom");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<DateTime>("DndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("EventId");

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

                    b.ToTable("EventParticipator");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StudentPersonId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherPersonId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.HasKey("GradeId");

                    b.HasIndex("StudentPersonId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherPersonId");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Lesson", b =>
                {
                    b.Property<int>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherPersonId")
                        .HasColumnType("int");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LessonId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherPersonId");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FromPersonId")
                        .HasColumnType("int");

                    b.Property<int?>("MessageContentId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SeenDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ToPersonId")
                        .HasColumnType("int");

                    b.HasKey("MessageId");

                    b.HasIndex("FromPersonId");

                    b.HasIndex("MessageContentId");

                    b.HasIndex("ToPersonId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.MessageContent", b =>
                {
                    b.Property<int>("MessageContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("MessageContentId");

                    b.ToTable("MessageContent");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<int?>("StudentPersonId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherPersonId")
                        .HasColumnType("int");

                    b.HasKey("NoteId");

                    b.HasIndex("StudentPersonId");

                    b.HasIndex("TeacherPersonId");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Parent", b =>
                {
                    b.Property<int>("ParentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ParentPersonId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentPersonId")
                        .HasColumnType("int");

                    b.HasKey("ParentId");

                    b.HasIndex("ParentPersonId");

                    b.HasIndex("StudentPersonId");

                    b.ToTable("Parent");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("PersonalInfoId")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("PersonId");

                    b.HasIndex("PersonalInfoId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.PersonalInfo", b =>
                {
                    b.Property<int>("PersonalInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("SecondName")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.HasKey("PersonalInfoId");

                    b.ToTable("PersonalInfo");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.StudentsGroup", b =>
                {
                    b.Property<int>("StudentsGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(2000)");

                    b.Property<int?>("TeacherPersonId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("YearOfStudy")
                        .HasColumnType("int");

                    b.HasKey("StudentsGroupId");

                    b.HasIndex("TeacherPersonId")
                        .IsUnique()
                        .HasFilter("[TeacherPersonId] IS NOT NULL");

                    b.ToTable("StudentsGroup");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.StudentsGroupMember", b =>
                {
                    b.Property<int>("StudentsGroupMemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("StudentPersonId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentsGroupId")
                        .HasColumnType("int");

                    b.HasKey("StudentsGroupMemberId");

                    b.HasIndex("StudentPersonId");

                    b.HasIndex("StudentsGroupId");

                    b.ToTable("StudentsGroupMember");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassRoomId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsGroupId")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectInfoId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherPersonId")
                        .HasColumnType("int");

                    b.HasKey("SubjectId");

                    b.HasIndex("ClassRoomId");

                    b.HasIndex("StudentsGroupId");

                    b.HasIndex("SubjectInfoId");

                    b.HasIndex("TeacherPersonId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.SubjectInfo", b =>
                {
                    b.Property<int>("SubjectInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("SubjectInfoId");

                    b.ToTable("SubjectInfo");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Attendance", b =>
                {
                    b.HasOne("DziennikElektroniczny.Models.Lesson", "Lesson")
                        .WithMany("Attendances")
                        .HasForeignKey("LessonId");

                    b.HasOne("DziennikElektroniczny.Models.Person", "StudentPerson")
                        .WithMany("AttendanceStudentPersons")
                        .HasForeignKey("StudentPersonId");

                    b.Navigation("Lesson");

                    b.Navigation("StudentPerson");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.EventParticipator", b =>
                {
                    b.HasOne("DziennikElektroniczny.Models.Event", "Event")
                        .WithMany("EventParticipators")
                        .HasForeignKey("EventId");

                    b.HasOne("DziennikElektroniczny.Models.Person", "Person")
                        .WithMany("EventParticipators")
                        .HasForeignKey("PersonId");

                    b.Navigation("Event");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Grade", b =>
                {
                    b.HasOne("DziennikElektroniczny.Models.Person", "StudentPerson")
                        .WithMany("GradeStudentPersons")
                        .HasForeignKey("StudentPersonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DziennikElektroniczny.Models.Subject", "Subject")
                        .WithMany("Grades")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DziennikElektroniczny.Models.Person", "TeacherPerson")
                        .WithMany("GradeTeacherPersons")
                        .HasForeignKey("TeacherPersonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("StudentPerson");

                    b.Navigation("Subject");

                    b.Navigation("TeacherPerson");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Lesson", b =>
                {
                    b.HasOne("DziennikElektroniczny.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DziennikElektroniczny.Models.Person", "TeacherPerson")
                        .WithMany()
                        .HasForeignKey("TeacherPersonId");

                    b.Navigation("Subject");

                    b.Navigation("TeacherPerson");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Message", b =>
                {
                    b.HasOne("DziennikElektroniczny.Models.Person", "FromPerson")
                        .WithMany("FromPersons")
                        .HasForeignKey("FromPersonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DziennikElektroniczny.Models.MessageContent", "MessageContent")
                        .WithMany("Messages")
                        .HasForeignKey("MessageContentId");

                    b.HasOne("DziennikElektroniczny.Models.Person", "ToPerson")
                        .WithMany("ToPersons")
                        .HasForeignKey("ToPersonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("FromPerson");

                    b.Navigation("MessageContent");

                    b.Navigation("ToPerson");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Note", b =>
                {
                    b.HasOne("DziennikElektroniczny.Models.Person", "StudentPerson")
                        .WithMany("NoteStudentPersons")
                        .HasForeignKey("StudentPersonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DziennikElektroniczny.Models.Person", "TeacherPerson")
                        .WithMany("NoteTeacherPersons")
                        .HasForeignKey("TeacherPersonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("StudentPerson");

                    b.Navigation("TeacherPerson");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Parent", b =>
                {
                    b.HasOne("DziennikElektroniczny.Models.Person", "ParentPerson")
                        .WithMany("ParentPersons")
                        .HasForeignKey("ParentPersonId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("DziennikElektroniczny.Models.Person", "StudentPerson")
                        .WithMany("StudentPersons")
                        .HasForeignKey("StudentPersonId")
                        .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity("DziennikElektroniczny.Models.StudentsGroup", b =>
                {
                    b.HasOne("DziennikElektroniczny.Models.Person", "TeacherPerson")
                        .WithOne("GroupTeacher")
                        .HasForeignKey("DziennikElektroniczny.Models.StudentsGroup", "TeacherPersonId");

                    b.Navigation("TeacherPerson");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.StudentsGroupMember", b =>
                {
                    b.HasOne("DziennikElektroniczny.Models.Person", "StudentPerson")
                        .WithMany("StudentsGroupMembers")
                        .HasForeignKey("StudentPersonId");

                    b.HasOne("DziennikElektroniczny.Models.StudentsGroup", "StudentsGroup")
                        .WithMany("StudentsGroupMembers")
                        .HasForeignKey("StudentsGroupId");

                    b.Navigation("StudentPerson");

                    b.Navigation("StudentsGroup");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Subject", b =>
                {
                    b.HasOne("DziennikElektroniczny.Models.ClassRoom", "ClassRoom")
                        .WithMany("Subjects")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DziennikElektroniczny.Models.StudentsGroup", "StudentsGroup")
                        .WithMany("Subjects")
                        .HasForeignKey("StudentsGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DziennikElektroniczny.Models.SubjectInfo", "SubjectInfo")
                        .WithMany("Subjects")
                        .HasForeignKey("SubjectInfoId");

                    b.HasOne("DziennikElektroniczny.Models.Person", "TeacherPerson")
                        .WithMany("SubjectTeacherPersons")
                        .HasForeignKey("TeacherPersonId");

                    b.Navigation("ClassRoom");

                    b.Navigation("StudentsGroup");

                    b.Navigation("SubjectInfo");

                    b.Navigation("TeacherPerson");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.ClassRoom", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Event", b =>
                {
                    b.Navigation("EventParticipators");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Lesson", b =>
                {
                    b.Navigation("Attendances");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.MessageContent", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Person", b =>
                {
                    b.Navigation("AttendanceStudentPersons");

                    b.Navigation("EventParticipators");

                    b.Navigation("FromPersons");

                    b.Navigation("GradeStudentPersons");

                    b.Navigation("GradeTeacherPersons");

                    b.Navigation("GroupTeacher");

                    b.Navigation("NoteStudentPersons");

                    b.Navigation("NoteTeacherPersons");

                    b.Navigation("ParentPersons");

                    b.Navigation("StudentPersons");

                    b.Navigation("StudentsGroupMembers");

                    b.Navigation("SubjectTeacherPersons");

                    b.Navigation("ToPersons");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.PersonalInfo", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.StudentsGroup", b =>
                {
                    b.Navigation("StudentsGroupMembers");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.Subject", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("DziennikElektroniczny.Models.SubjectInfo", b =>
                {
                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
