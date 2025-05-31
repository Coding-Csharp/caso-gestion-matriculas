using CasoGestionMatriculas.Operation.Domain.Model.Aggregates;
using CasoGestionMatriculas.Operation.Domain.Model.Commands;

namespace CasoGestionMatriculas.Operation.Domain.Model.Entities
{
    public class Course
    {
        public int Id { get; }
        public string Name { get; private set; } = null!;

        public virtual ICollection<Registration> Registrations { get; } = [];

        public Course() { }
        public Course(CreateCourseCommand command)
        {
            this.Name = command.Name;
        }
    }
}