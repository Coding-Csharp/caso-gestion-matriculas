using CasoGestionMatriculas.Operation.Domain.Model.Entities;
using CasoGestionMatriculas.Shared.Domain.Repositories;

namespace CasoGestionMatriculas.Operation.Domain.Repositories
{
    public interface ICourseRepository :
        IBaseRepository<Course>
    { }
}