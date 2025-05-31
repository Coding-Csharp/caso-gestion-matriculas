using CasoGestionMatriculas.Operation.Domain.Model.Commands;
using CasoGestionMatriculas.Operation.Interfaces.REST.Resources;

namespace CasoGestionMatriculas.Operation.Interfaces.REST.Transform
{
    public class CreateStudentCommandFromResourceAssembler
    {
        public static CreateStudentCommand ToCommandFromResource
            (CreateStudentResource resource) =>
            new(resource.Id, resource.Firstname, resource.Lastname,
                resource.Birthday, resource.Genre, resource.Phone,
                resource.Email);
    }
}