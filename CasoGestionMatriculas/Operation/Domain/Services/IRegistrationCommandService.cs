using CasoGestionMatriculas.Operation.Domain.Model.Commands;

namespace CasoGestionMatriculas.Operation.Domain.Services
{
    public interface IRegistrationCommandService
    {
        public Task<string> Handle(CreateRegistrationCommand command);
        public Task<string> Handle(UpdateRegistrationCommand command);
    }
}