using CasoGestionMatriculas.Operation.Domain.Model.Commands;
using CasoGestionMatriculas.Operation.Domain.Model.Entities;
using CasoGestionMatriculas.Operation.Domain.Model.ValueObjects;

namespace CasoGestionMatriculas.Operation.Domain.Model.Aggregates
{
    public class Registration
    {
        public int Id { get; }
        public int CourseId { get; private set; }
        public int StudentId { get; private set; }
        public DateOnly EnrollmentDate { get; private set; }
        public string State { get; private set; } = null!;

        public virtual Course Course { get; } = null!;
        public virtual Student Student { get; } = null!;

        public Registration() { }
        public Registration
            (int courseId, DateOnly enrollmentDate,
            int studentId, ERegistrationState state)
        {
            this.CourseId = courseId;
            this.StudentId = studentId;
            this.EnrollmentDate = enrollmentDate;
            this.State = state.ToString();
        }
        public Registration(CreateRegistrationCommand command)
        {
            this.CourseId = command.CourseId;
            this.StudentId = command.StudentId;
            this.EnrollmentDate = command.EnrollmentDate;
            this.State = command.State.ToString();
        }
        public Registration(UpdateRegistrationCommand command)
        {
            this.Id = command.Id;
            this.State = command.State.ToString();
        }
        public Registration(DeleteRegistrationCommand command)
        {
            this.Id = command.Id;
        }
    }
}