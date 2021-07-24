using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace B_7.Models
{
    public partial class StudentContextDB : DbContext
    {
        public StudentContextDB()
            : base("name=StudentContextDB")
        {
        }

        public virtual DbSet<facultyTable> facultyTables { get; set; }
        public virtual DbSet<studentTable> studentTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<facultyTable>()
             //   .HasMany(e => e.studentTables)
               // .WithRequired(e => e.facultyTable)
                //.WillCascadeOnDelete(false);

            modelBuilder.Entity<studentTable>()
                .Property(e => e.averageScore)
                .IsFixedLength();
        }
    }
}
