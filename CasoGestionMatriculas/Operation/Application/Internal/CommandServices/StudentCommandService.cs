using CasoGestionMatriculas.Operation.Domain.Model.Commands;
using CasoGestionMatriculas.Operation.Domain.Repositories;
using CasoGestionMatriculas.Operation.Domain.Services;
using CasoGestionMatriculas.Shared.Domain.Repositories;

namespace CasoGestionMatriculas.Operation.Application.Internal.CommandServices
{
    public class StudentCommandService
        (IStudentRepository studentRepository,
        IUnitOfWork unitOfWork) :
        IStudentCommandService
    {
        public async Task<bool> Handle(CreateStudentCommand command)
        {
            try
            {
                await studentRepository.AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}