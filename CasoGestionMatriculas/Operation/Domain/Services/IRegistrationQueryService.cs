using CasoGestionMatriculas.Operation.Domain.Model.Aggregates;
using CasoGestionMatriculas.Operation.Domain.Model.Queries;

namespace CasoGestionMatriculas.Operation.Domain.Services
{
    public interface IRegistrationQueryService
    {
        public Task<IEnumerable<Registration>> Handle(GetAllRegistrationsQuery query);
        public Task<IEnumerable<Registration>> Handle(GetRegistrationsByStudentIdQuery query);
        public Task<IEnumerable<Registration>> Handle(GetRegistrationsByCourseIdQuery query);
        public Task<IEnumerable<Registration>> Handle(GetRegistrationsByStateQuery query);
        public Task<Registration?> Handle(GetRegistrationByIdQuery query);
    }
}