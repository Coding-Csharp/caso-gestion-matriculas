namespace CasoGestionMatriculas.Operation.Domain.Model.Commands
{
    public record CreateCourseCommand
        (DateOnly EnrollmentDate, string Name);
}