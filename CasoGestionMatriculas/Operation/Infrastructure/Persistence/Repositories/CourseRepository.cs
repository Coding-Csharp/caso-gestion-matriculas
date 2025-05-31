using CasoGestionMatriculas.Operation.Domain.Model.Entities;
using CasoGestionMatriculas.Operation.Domain.Repositories;
using CasoGestionMatriculas.Shared.Infrastructure.Persistence.EFC.Configuration;
using CasoGestionMatriculas.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace CasoGestionMatriculas.Operation.Infrastructure.Persistence.Repositories
{
    internal class CourseRepository
        (CasoGestionMatriculasContext context) :
        BaseRepository<Course>(context),
        ICourseRepository
    { }
}