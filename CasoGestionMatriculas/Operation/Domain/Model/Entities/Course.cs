using CasoGestionMatriculas.Operation.Domain.Model.Aggregates;
using CasoGestionMatriculas.Operation.Domain.Model.Commands;

namespace CasoGestionMatriculas.Operation.Domain.Model.Entities
{
    public class Course
    {
        public int Id { get; }
        public DateOnly EnrollmentDate { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Registration> Registrations { get; set; } = [];

        public Course() { }
        public Course(CreateCourseCommand command)
        {
            this.EnrollmentDate = command.EnrollmentDate;
            this.Name = command.Name;
        }
    }
}