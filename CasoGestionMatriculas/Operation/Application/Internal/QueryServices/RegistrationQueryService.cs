using CasoGestionMatriculas.Operation.Domain.Model.Aggregates;
using CasoGestionMatriculas.Operation.Domain.Model.Queries;
using CasoGestionMatriculas.Operation.Domain.Repositories;
using CasoGestionMatriculas.Operation.Domain.Services;

namespace CasoGestionMatriculas.Operation.Application.Internal.QueryServices
{
    public class RegistrationQueryService
        (IRegistrationRepository registrationRepository) :
        IRegistrationQueryService
    {
        public async Task<IEnumerable<Registration>> Handle(GetAllRegistrationsQuery query)
            => await registrationRepository.ListAsync();

        public async Task<IEnumerable<Registration>> Handle(GetRegistrationsByStudentIdQuery query)
            => await registrationRepository.FindByStudentIdAsync(query.StudentId);

        public async Task<IEnumerable<Registration>> Handle(GetRegistrationsByCourseIdQuery query)
            => await registrationRepository.FindByCourseIdAsync(query.CourseId);

        public async Task<IEnumerable<Registration>> Handle(GetRegistrationsByStateQuery query)
            => await registrationRepository.FindByStateAsync(query.State);

        public async Task<Registration?> Handle(GetRegistrationByIdQuery query)
            => await registrationRepository.FindByIdAsync(query.Id);
    }
}