using CasoGestionMatriculas.Operation.Domain.Model.Aggregates;
using CasoGestionMatriculas.Operation.Domain.Model.Commands;

namespace CasoGestionMatriculas.Operation.Domain.Model.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public DateOnly Birthday { get; set; }
        public string Genre { get; set; } = null!;
        public int Phone { get; set; }
        public string Email { get; set; } = null!;

        public virtual ICollection<Registration> Registrations { get; set; } = [];

        public Student() { }
        public Student(CreateStudentCommand command)
        {
            this.Id = command.Id;
            this.Firstname = command.Firstname;
            this.Lastname = command.Lastname;
            this.Birthday = command.Birthday;
            this.Phone = command.Phone;
            this.Email = command.Email;
        }
    }
}