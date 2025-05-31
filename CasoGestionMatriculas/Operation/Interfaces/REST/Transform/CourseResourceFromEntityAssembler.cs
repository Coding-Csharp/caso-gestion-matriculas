using CasoGestionMatriculas.Operation.Domain.Model.Entities;
using CasoGestionMatriculas.Operation.Interfaces.REST.Resources;

namespace CasoGestionMatriculas.Operation.Interfaces.REST.Transform
{
    public class CourseResourceFromEntityAssembler
    {
        public static CourseResource ToResourceFromEntity(Course entity)
            => new(entity.Id, entity.Name);
    }
}