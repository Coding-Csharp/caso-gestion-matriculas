using CasoGestionMatriculas.Operation.Domain.Model.ValueObjects;

namespace CasoGestionMatriculas.Operation.Domain.Model.Commands
{
    public record CreateRegistrationCommand
        (int CourseId, int StudentId, ERegistrationState State);
}