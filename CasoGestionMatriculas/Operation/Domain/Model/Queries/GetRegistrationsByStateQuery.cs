using CasoGestionMatriculas.Operation.Domain.Model.ValueObjects;

namespace CasoGestionMatriculas.Operation.Domain.Model.Queries
{
    public record GetRegistrationsByStateQuery(ERegistrationState State);
}