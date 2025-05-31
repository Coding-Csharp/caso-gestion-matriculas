using CasoGestionMatriculas.Operation.Domain.Model.Commands;
using CasoGestionMatriculas.Operation.Domain.Repositories;
using CasoGestionMatriculas.Operation.Domain.Services;
using CasoGestionMatriculas.Shared.Domain.Repositories;

namespace CasoGestionMatriculas.Operation.Application.Internal.CommandServices
{
    public class CourseCommandService
        (ICourseRepository courseRepository,
        IUnitOfWork unitOfWork) :
        ICourseCommandService
    {
        public async Task<bool> Handle(CreateCourseCommand command)
        {
            try
            {
                await courseRepository.AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}