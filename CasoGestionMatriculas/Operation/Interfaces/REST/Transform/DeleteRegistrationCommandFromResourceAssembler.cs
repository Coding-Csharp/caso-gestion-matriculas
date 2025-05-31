using CasoGestionMatriculas.Operation.Domain.Model.Commands;
using CasoGestionMatriculas.Operation.Interfaces.REST.Resources;

namespace CasoGestionMatriculas.Operation.Interfaces.REST.Transform
{
    public class DeleteRegistrationCommandFromResourceAssembler
    {
        public static DeleteRegistrationCommand ToCommandFromResource
            (DeleteRegistrationResource resource) => new(resource.Id);
    }
}