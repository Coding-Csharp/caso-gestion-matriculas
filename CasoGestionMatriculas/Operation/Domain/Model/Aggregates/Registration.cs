using CasoGestionMatriculas.Operation.Domain.Model.Commands;
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

        public Registration() { }
        public Registration(CreateRegistrationCommand command)
        {
            this.CourseId = command.CourseId;
            this.StudentId = command.StudentId;
            this.State = command.State.ToString();
        }
    }
}