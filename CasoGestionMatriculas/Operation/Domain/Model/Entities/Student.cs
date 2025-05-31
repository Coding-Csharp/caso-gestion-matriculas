using CasoGestionMatriculas.Operation.Domain.Model.Aggregates;

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
    }
}