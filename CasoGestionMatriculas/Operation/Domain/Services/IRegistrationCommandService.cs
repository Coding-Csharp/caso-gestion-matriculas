using CasoGestionMatriculas.Operation.Domain.Model.Commands;

namespace CasoGestionMatriculas.Operation.Domain.Services
{
    public interface IRegistrationCommandService
    {
        public Task<bool> Handle(CreateRegistrationCommand command);
        public void Handle(UpdateRegistrationCommand command);
        public void Handle(DeleteRegistrationCommand command);
    }
}