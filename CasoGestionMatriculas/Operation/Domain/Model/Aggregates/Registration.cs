using CasoGestionMatriculas.Operation.Domain.Model.Entities;

namespace CasoGestionMatriculas.Operation.Domain.Model.Aggregates
{
    public class Registration
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public string State { get; set; } = null!;

        public virtual Course Course { get; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}