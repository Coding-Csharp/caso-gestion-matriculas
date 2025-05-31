using CasoGestionMatriculas.Operation.Domain.Model.ValueObjects;

namespace CasoGestionMatriculas.Operation.Domain.Model.Commands
{
    public record UpdateRegistrationCommand(int Id, ERegistrationState state);
}