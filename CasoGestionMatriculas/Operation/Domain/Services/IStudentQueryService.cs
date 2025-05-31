using CasoGestionMatriculas.Operation.Domain.Model.Entities;
using CasoGestionMatriculas.Operation.Domain.Model.Queries;

namespace CasoGestionMatriculas.Operation.Domain.Services
{
    public interface IStudentQueryService
    {
        public Task<IEnumerable<Student>> Handle(GetAllStudentsQuery query);
        public Task<Student?> Handle(GetStudentByIdQuery query);
    }
}