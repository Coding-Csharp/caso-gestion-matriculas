using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using CasoGestionMatriculas.Operation.Domain.Model.Aggregates;
using CasoGestionMatriculas.Operation.Domain.Repositories;
using CasoGestionMatriculas.Shared.Infrastructure.Persistence.EFC.Configuration;
using CasoGestionMatriculas.Shared.Infrastructure.Persistence.EFC.Repositories;
using CasoGestionMatriculas.Operation.Domain.Model.ValueObjects;

namespace CasoGestionMatriculas.Operation.Infrastructure.Persistence.Repositories
{
    internal class RegistrationRepository
        (CasoGestionMatriculasContext context,
        IDbConnection dbConnection) :
        BaseRepository<Registration>(context),
        IRegistrationRepository
    {
        public new void Update(Registration registration)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@id", registration.Id, DbType.Int32);
                parameters.Add("@state", registration.State, DbType.String);

                dbConnection.Execute(
                    "sp_update_registration",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo actualizar el estado de la inscripción. Detalles: " + ex.Message);
            }
        }
        public new void Remove(Registration registration)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@id", registration.Id, DbType.Int32);

                dbConnection.Execute(
                    "sp_delete_registration",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar la inscripción. Detalles: " + ex.Message);
            }
        }

        public async Task<IEnumerable<Registration>> FindByStudentIdAsync
            (int studentId) =>await Context.Set<Registration>()
            .Where(r => r.StudentId == studentId).ToListAsync();

        public async Task<IEnumerable<Registration>> FindByCourseIdAsync
            (int courseId) => await Context.Set<Registration>()
            .Where(r => r.CourseId == courseId).ToListAsync();

        public async Task<IEnumerable<Registration>> FindByStateAsync
            (ERegistrationState state) => await Context.Set<Registration>()
            .Where(r => r.State == state.ToString()).ToListAsync();
    }
}