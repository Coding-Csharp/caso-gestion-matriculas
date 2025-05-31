using CasoGestionMatriculas.Operation.Domain.Model.Entities;
using CasoGestionMatriculas.Operation.Domain.Repositories;
using CasoGestionMatriculas.Shared.Infrastructure.Persistence.EFC.Configuration;
using CasoGestionMatriculas.Shared.Infrastructure.Persistence.EFC.Repositories;
using System.Data;

namespace CasoGestionMatriculas.Operation.Infrastructure.Persistence.Repositories
{
    internal class StudentRepository
        (CasoGestionMatriculasContext context) :
        BaseRepository<Student>(context),
        IStudentRepository
    { }
}