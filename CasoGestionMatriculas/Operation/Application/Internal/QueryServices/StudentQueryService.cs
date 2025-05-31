using CasoGestionMatriculas.Operation.Domain.Model.Entities;
using CasoGestionMatriculas.Operation.Domain.Model.Queries;
using CasoGestionMatriculas.Operation.Domain.Repositories;
using CasoGestionMatriculas.Operation.Domain.Services;

namespace CasoGestionMatriculas.Operation.Application.Internal.QueryServices
{
    public class StudentQueryService
        (IStudentRepository studentRepository) :
        IStudentQueryService
    {
        public async Task<IEnumerable<Student>> Handle(GetAllStudentsQuery query)
            => await studentRepository.ListAsync();

        public async Task<Student?> Handle(GetStudentByIdQuery query)
            => await studentRepository.FindByIdAsync(query.Id);
    }
}