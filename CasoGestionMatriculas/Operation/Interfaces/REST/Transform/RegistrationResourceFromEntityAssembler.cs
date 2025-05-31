using CasoGestionMatriculas.Operation.Domain.Model.Aggregates;
using CasoGestionMatriculas.Operation.Interfaces.REST.Resources;

namespace CasoGestionMatriculas.Operation.Interfaces.REST.Transform
{
    public class RegistrationResourceFromEntityAssembler
    {
        public static RegistrationResource ToResourceFromEntity
            (Registration entity) =>
            new(entity.Id, entity.CourseId,
                entity.StudentId, entity.State);
    }
}