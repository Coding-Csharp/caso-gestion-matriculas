using CasoGestionMatriculas.Operation.Domain.Model.Commands;

namespace CasoGestionMatriculas.Operation.Domain.Services
{
    public interface IStudentCommandService
    {
        public Task<bool> Handle(CreateStudentCommand command);
    }
}