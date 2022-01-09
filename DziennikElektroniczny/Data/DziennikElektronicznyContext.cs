using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.Data
{
    public class DziennikElektronicznyContext : DbContext
    {
        public DziennikElektronicznyContext(DbContextOptions<DziennikElektronicznyContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasMany(x => x.EventParticipators)
                .WithOne(x => x.Person)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Person>()
                .HasMany(x => x.NoteStudentPersons)
                .WithOne(x => x.StudentPerson)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Person>()
                .HasMany(x => x.NoteTeacherPersons)
                .WithOne(x => x.TeacherPerson)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Person>()
                .HasMany(x => x.SubjectTeacherPersons)
                .WithOne(x => x.TeacherPerson)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Parent>()
                .HasOne(x => x.ParentPerson)
                .WithMany(x => x.ParentPersons)
                .HasForeignKey(x => x.ParentPersonId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Parent>()
                .HasOne(x => x.StudentPerson)
                .WithMany(x => x.StudentPersons)
                .HasForeignKey(x => x.StudentPersonId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Note>()
                .HasOne(x => x.TeacherPerson)
                .WithMany(x => x.NoteTeacherPersons)
                .HasForeignKey(x => x.TeacherPersonId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Note>()
                .HasOne(x => x.StudentPerson)
                .WithMany(x => x.NoteStudentPersons)
                .HasForeignKey(x => x.StudentPersonId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Message>()
                .HasOne(x => x.ToPerson)
                .WithMany(x => x.ToPersons)
                .HasForeignKey(x => x.ToPersonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(x => x.FromPerson)
                .WithMany(x => x.FromPersons)
                .HasForeignKey(x => x.FromPersonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(x => x.MessageContent)
                .WithMany(x => x.Messages)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MessageContent>()
                .HasMany(x => x.Messages)
                .WithOne(x => x.MessageContent)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Event>()
                .HasMany(x => x.EventParticipators)
                .WithOne(x => x.Event)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Grade>()
                .HasOne(x => x.StudentPerson)
                .WithMany(x => x.GradeStudentPersons)
                .HasForeignKey(x => x.StudentPersonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Grade>()
                .HasOne(x => x.TeacherPerson)
                .WithMany(x => x.GradeTeacherPersons)
                .HasForeignKey(x => x.TeacherPersonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lesson>()
                .HasMany(x => x.Attendances)
                .WithOne(x => x.Lesson)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SubjectInfo>()
                .HasMany(x => x.Subjects)
                .WithOne(x => x.SubjectInfo)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Person>()
                .HasMany(x => x.GroupTeacher)
                .WithOne(x => x.TeacherPerson)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Person>()
                .HasMany(x => x.StudentsGroupMembers)
                .WithOne(x => x.StudentPerson)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentsGroup>()
                .HasMany(x => x.StudentsGroupMembers)
                .WithOne(x => x.StudentsGroup)
                .OnDelete(DeleteBehavior.Cascade);

        }
        public DbSet<Event> Event { get; set; }
        public DbSet<EventParticipator> EventParticipator { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonalInfo> PersonalInfo { get; set; }
        public DbSet<Parent> Parent { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<MessageContent> MessageContent { get ;set;}
        public DbSet<Subject> Subject { get; set; }
        public DbSet<SubjectInfo> SubjectInfo { get; set; }
        public DbSet<ClassRoom> ClassRoom { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<StudentsGroup> StudentsGroup { get; set; }
        public DbSet<StudentsGroupMember> StudentsGroupMember { get; set; }
        public DbSet<Note> Note { get; set; }
    }
}
