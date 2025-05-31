using CasoGestionMatriculas.Operation.Domain.Model.Entities;
using CasoGestionMatriculas.Operation.Domain.Model.Queries;

namespace CasoGestionMatriculas.Operation.Domain.Services
{
    public interface ICourseQueryService
    {
        public Task<IEnumerable<Course>> Handle(GetAllCoursesQuery query);
        public Task<Course?> Handle(GetCourseByIdQuery query);
    }
}