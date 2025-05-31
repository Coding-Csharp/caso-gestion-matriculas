using CasoGestionMatriculas.Operation.Domain.Model.Commands;
using CasoGestionMatriculas.Operation.Interfaces.REST.Resources;

namespace CasoGestionMatriculas.Operation.Interfaces.REST.Transform
{
    public class CreateCourseCommandFromResourceAssembler
    {
        public static CreateCourseCommand ToCommandFromResource
            (CreateCourseResource resource) => new(resource.Name);
    }
}