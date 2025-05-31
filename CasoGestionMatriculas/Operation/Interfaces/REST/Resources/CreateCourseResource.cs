namespace CasoGestionMatriculas.Operation.Interfaces.REST.Resources
{
    public record CreateCourseResource(DateOnly EnrollmentDate, string Name);
}