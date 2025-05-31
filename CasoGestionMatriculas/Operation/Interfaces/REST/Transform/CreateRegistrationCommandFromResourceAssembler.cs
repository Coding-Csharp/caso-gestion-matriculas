using CasoGestionMatriculas.Operation.Domain.Model.Commands;
using CasoGestionMatriculas.Operation.Domain.Model.ValueObjects;
using CasoGestionMatriculas.Operation.Interfaces.REST.Resources;

namespace CasoGestionMatriculas.Operation.Interfaces.REST.Transform
{
    public class CreateRegistrationCommandFromResourceAssembler
    {
        public static CreateRegistrationCommand ToCommandFromResource
            (CreateRegistrationResource resource) =>
            new(resource.CourseId, resource.StudentId,
                Enum.Parse<ERegistrationState>(resource.State));
    }
}