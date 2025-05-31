using CasoGestionMatriculas.Shared.Domain.Repositories;
using CasoGestionMatriculas.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace CasoGestionMatriculas.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public class UnitOfWork
        (CasoGestionMatriculasContext context) :
        IUnitOfWork
    {
        public async Task CompleteAsync() =>
            await context.SaveChangesAsync();
    }
}