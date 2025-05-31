using CasoGestionMatriculas.Operation.Domain.Model.Aggregates;
using CasoGestionMatriculas.Shared.Domain.Repositories;

namespace CasoGestionMatriculas.Operation.Domain.Repositories
{
    public interface IRegistrationRepository :
        IBaseRepository<Registration>
    { }
}