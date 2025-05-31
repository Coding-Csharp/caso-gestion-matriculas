using CasoGestionMatriculas.Operation.Domain.Model.Commands;
using CasoGestionMatriculas.Operation.Domain.Repositories;
using CasoGestionMatriculas.Operation.Domain.Services;
using CasoGestionMatriculas.Shared.Domain.Repositories;

namespace CasoGestionMatriculas.Operation.Application.Internal.CommandServices
{
    public class RegistrationCommandService
        (IRegistrationRepository registrationRepository,
        IUnitOfWork unitOfWork) :
        IRegistrationCommandService
    {
        public async Task<bool> Handle(CreateRegistrationCommand command)
        {
            try
            {
                await registrationRepository.AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
        public bool Handle(UpdateRegistrationCommand command)
            => registrationRepository.Update(new(command));

        public bool Handle(DeleteRegistrationCommand command)
            => registrationRepository.Remove(new(command));
    }
}