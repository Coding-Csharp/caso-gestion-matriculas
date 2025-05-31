using CasoGestionMatriculas.Operation.Domain.Model.Aggregates;

namespace CasoGestionMatriculas.Operation.Domain.Model.Entities
{
    public class Course
    {
        public int Id { get; }
        public DateOnly EnrollmentDate { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Registration> Registrations { get; set; } = [];
    }
}