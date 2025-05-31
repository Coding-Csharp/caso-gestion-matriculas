using CasoGestionMatriculas.Operation.Domain.Model.Aggregates;
using CasoGestionMatriculas.Operation.Domain.Model.Commands;

namespace CasoGestionMatriculas.Operation.Domain.Model.Entities
{
    public class Student
    {
        public int Id { get; private set; }
        public string Firstname { get; private set; } = null!;
        public string Lastname { get; private set; } = null!;
        public DateOnly Birthday { get; private set; }
        public string Genre { get; private set; } = null!;
        public int Phone { get; private set; }
        public string Email { get; private set; } = null!;

        public virtual ICollection<Registration> Registrations { get; } = [];

        public Student() { }
        public Student(CreateStudentCommand command)
        {
            this.Id = command.Id;
            this.Firstname = command.Firstname;
            this.Lastname = command.Lastname;
            this.Birthday = command.Birthday;
            this.Genre = command.Genre;
            this.Phone = command.Phone;
            this.Email = command.Email;
        }
    }
}