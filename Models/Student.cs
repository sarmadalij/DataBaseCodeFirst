using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseCodeFirst.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Column("StudentName",  TypeName ="varchar(100)")]
        public string Name { get; set; }

        [Column("StudentGender", TypeName = "varchar(20)")]
        [Required(ErrorMessage = "Select Gender")]
        public Gender? Gender { get; set; }
        public int Age { get; set; }

        [Column("StudentDepartment", TypeName = "varchar(100)")]
        public string Department { get; set; }
    }

    //enum is used to define constants
    public enum Gender
    {
        Male, Female
    }
}
