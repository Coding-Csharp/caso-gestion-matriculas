using CasoGestionMatriculas.Operation.Domain.Model.Commands;

namespace CasoGestionMatriculas.Operation.Domain.Services
{
    public interface ICourseCommandService
    {
        public Task<string> Handle(CreateCourseCommand command);
    }
}