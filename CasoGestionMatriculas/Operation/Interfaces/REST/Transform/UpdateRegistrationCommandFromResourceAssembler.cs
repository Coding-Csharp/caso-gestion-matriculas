using CasoGestionMatriculas.Operation.Domain.Model.Commands;
using CasoGestionMatriculas.Operation.Domain.Model.ValueObjects;
using CasoGestionMatriculas.Operation.Interfaces.REST.Resources;

namespace CasoGestionMatriculas.Operation.Interfaces.REST.Transform
{
    public class UpdateRegistrationCommandFromResourceAssembler
    {
        public static UpdateRegistrationCommand ToCommandFromResource
            (UpdateRegistrationResource resource) =>
            new(resource.Id, Enum.Parse<ERegistrationState>(resource.State));
    }
}