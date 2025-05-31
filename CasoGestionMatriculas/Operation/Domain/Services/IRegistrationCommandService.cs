using CasoGestionMatriculas.Operation.Domain.Model.Commands;

namespace CasoGestionMatriculas.Operation.Domain.Services
{
    public interface IRegistrationCommandService
    {
        public Task<bool> Handle(CreateRegistrationCommand command);
        public bool Handle(UpdateRegistrationCommand command);
        public bool Handle(DeleteRegistrationCommand command);
    }
}