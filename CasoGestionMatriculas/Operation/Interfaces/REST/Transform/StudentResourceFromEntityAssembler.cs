using CasoGestionMatriculas.Operation.Domain.Model.Entities;
using CasoGestionMatriculas.Operation.Interfaces.REST.Resources;

namespace CasoGestionMatriculas.Operation.Interfaces.REST.Transform
{
    public class StudentResourceFromEntityAssembler
    {
        public static StudentResource ToResourceFromEntity
            (Student entity) =>
            new(entity.Id, entity.Firstname,
                entity.Lastname, entity.Birthday,
                entity.Genre, entity.Phone, entity.Email);
    }
}