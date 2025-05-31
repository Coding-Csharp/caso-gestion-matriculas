using CasoGestionMatriculas.Operation.Domain.Model.Aggregates;
using CasoGestionMatriculas.Operation.Domain.Model.ValueObjects;
using CasoGestionMatriculas.Shared.Domain.Repositories;

namespace CasoGestionMatriculas.Operation.Domain.Repositories
{
    public interface IRegistrationRepository :
        IBaseRepository<Registration>
    {
        Task<IEnumerable<Registration>> FindByStudentIdAsync(int studentId);
        Task<IEnumerable<Registration>> FindByCourseIdAsync(int courseId);
        Task<IEnumerable<Registration>> FindByStateAsync(ERegistrationState state);
    }
}