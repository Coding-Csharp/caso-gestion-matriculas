using CasoGestionMatriculas.Operation.Domain.Model.Entities;
using CasoGestionMatriculas.Operation.Domain.Model.Queries;
using CasoGestionMatriculas.Operation.Domain.Repositories;
using CasoGestionMatriculas.Operation.Domain.Services;

namespace CasoGestionMatriculas.Operation.Application.Internal.QueryServices
{
    public class CourseQueryService
        (ICourseRepository courseRepository) :
        ICourseQueryService
    {
        public async Task<IEnumerable<Course>> Handle(GetAllCoursesQuery query)
            => await courseRepository.ListAsync();

        public async Task<Course?> Handle(GetCourseByIdQuery query)
            => await courseRepository.FindByIdAsync(query.Id);
    }
}