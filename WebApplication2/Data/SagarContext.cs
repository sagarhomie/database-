using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Data
{
    public class SagarContext:DbContext
    {
        public SagarContext(DbContextOptions<SagarContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher>Teachers { get; set; }

    }
    [Table("Student")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    [Table("Teacher")]
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string TeacherName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
