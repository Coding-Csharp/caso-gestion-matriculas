using Microsoft.AspNetCore.Mvc;
using CasoGestionMatriculas.Operation.Domain.Model.Queries;
using CasoGestionMatriculas.Operation.Domain.Model.ValueObjects;
using CasoGestionMatriculas.Operation.Domain.Services;
using CasoGestionMatriculas.Operation.Interfaces.REST.Resources;
using CasoGestionMatriculas.Operation.Interfaces.REST.Transform;

namespace CasoGestionMatriculas.Operation.Interfaces.REST
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController
        (ICourseCommandService courseCommandService,
        IStudentCommandService studentCommandService,
        IRegistrationCommandService registrationCommandService,
        IRegistrationQueryService registrationQueryService) :
        ControllerBase
    {
        [HttpPost("course")]
        public async Task<IActionResult> CreateCourse
            ([FromBody] CreateCourseResource resource)
        {
            if (string.IsNullOrEmpty(resource.Name.Trim()))
                return BadRequest("EL NOMBRE NO PUEDE SER VACIO O CON ESPACIOS.");

            var result = await courseCommandService.Handle
                (CreateCourseCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest("NO SE REGISTRO EL CURSO DEBIDO A UN PROBLEMA INTERNO.");

            return Ok("CURSO REGISTRADO CORRECTAMENTE.");
        }

        [HttpPost("student")]
        public async Task<IActionResult> CreateStudent
            ([FromBody] CreateStudentResource resource)
        {
            if (resource.Id < 1)
                return BadRequest("EL ID DEBE SER MAYOR A 0.");

            if (string.IsNullOrEmpty(resource.Firstname.Trim()))
                return BadRequest("EL NOMBRE NO PUEDE SER VACIO O CON ESPACIOS.");

            if (string.IsNullOrEmpty(resource.Lastname.Trim()))
                return BadRequest("EL APELLIDO NO PUEDE SER VACIO O CON ESPACIOS.");

            if (resource.Birthday > DateOnly.FromDateTime(DateTime.Now))
                return BadRequest("LA FECHA DE NACIMIENTO NO PUEDE SER MAYOR QUE LA ACTUAL.");

            if (string.IsNullOrEmpty(resource.Genre.Trim()))
                return BadRequest("EL GENERO NO PUEDE SER VACIO O CON ESPACIOS.");

            if (resource.Phone < 900000000 || resource.Phone > 999999999)
                return BadRequest("EL NUMERO DE CELULAR DEBE SER VALIDO.");

            if (string.IsNullOrEmpty(resource.Email.Trim()))
                return BadRequest("EL EMAIL NO PUEDE SER VACIO O CON ESPACIOS.");

            var result = await studentCommandService.Handle
                (CreateStudentCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest("NO SE REGISTRO EL ESTUDIANTE DEBIDO A UN PROBLEMA INTERNO.");

            return Ok("ESTUDIANTE REGISTRADO CORRECTAMENTE.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegistration
            ([FromBody] CreateRegistrationResource resource)
        {
            if (resource.CourseId < 1)
                return BadRequest("EL ID DEL CURSO DEBE SER MAYOR A 0.");

            if (resource.StudentId < 1)
                return BadRequest("EL ID DEL ESTUDIANTE DEBE SER MAYOR A 0.");

            if (resource.EnrollmentDate > DateOnly.FromDateTime(DateTime.Now))
                return BadRequest("LA FECHA NO PUEDE SER MAYOR QUE LA ACTUAL.");

            if (!Enum.TryParse<ERegistrationState>(resource.State, true, out var state))
                return BadRequest("EL ESTADO NO ES VALIDO.");

            var registrations = await registrationQueryService.Handle
                (new GetRegistrationsByCourseIdQuery(resource.CourseId));

            if (registrations.Where(r => r.CourseId == resource.CourseId && r.StudentId == resource.StudentId)
                .FirstOrDefault() is not null)
                return BadRequest("YA EXISTE UNA MATRICULA CON EL ESTUDIANTE Y CURSO.");

            var result = await registrationCommandService.Handle
                (CreateRegistrationCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest("NO SE REGISTRO LA MATRICULA DEBIDO A UN PROBLEMA INTERNO.");

            return Ok("MATRICULA REGISTRADA CORRECTAMENTE.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRegistration
            (int id, [FromBody] UpdateRegistrationResource resource)
        {
            if (id < 1 || resource.Id < 1)
                return BadRequest("EL ID DE LA MATRICULA DEBE SER MAYOR A 0.");

            if (!Enum.TryParse<ERegistrationState>(resource.State, true, out var state))
                return BadRequest("EL ESTADO NO ES VALIDO.");

            registrationCommandService.Handle
                (UpdateRegistrationCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            return Ok("MATRICULA ACTUALIZADA CORRECTAMENTE.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRegistration(int id)
        {
            DeleteRegistrationResource resource = new(id);

            if (id < 1 || resource.Id < 1)
                return BadRequest("EL ID DE LA MATRICULA DEBE SER MAYOR A 0.");

            registrationCommandService.Handle
                (DeleteRegistrationCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            return Ok("MATRICULA ELIMINADA CORRECTAMENTE.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RegistrationById(int id)
        {
            var registration = await registrationQueryService.Handle
                (new GetRegistrationByIdQuery(id));

            if (registration is null)
                return BadRequest("NO SE ENCONTRO LA MATRICULA.");

            var registrationResouce = RegistrationResourceFromEntityAssembler
                .ToResourceFromEntity(registration);

            return Ok(registrationResouce);
        }

        [HttpGet("by-course/{courseId}")]
        public async Task<IActionResult> RegistrationByCourseId(int courseId)
        {
            var registrations = await registrationQueryService.Handle
                (new GetRegistrationsByCourseIdQuery(courseId));

            var registrationsResource = registrations.Select
                (RegistrationResourceFromEntityAssembler.ToResourceFromEntity);

            return Ok(registrationsResource);
        }

        [HttpGet("by-student/{studentId}")]
        public async Task<IActionResult> RegistrationByStudentId(int studentId)
        {
            var registrations = await registrationQueryService.Handle
                (new GetRegistrationsByStudentIdQuery(studentId));

            var registrationsResource = registrations.Select
                (RegistrationResourceFromEntityAssembler.ToResourceFromEntity);

            return Ok(registrationsResource);
        }

        [HttpGet("by-state")]
        public async Task<IActionResult> RegistrationByState([FromQuery] string state)
        {
            if (!Enum.TryParse<ERegistrationState>(state, true, out var finalState))
                return BadRequest("EL ESTADO NO ES VALIDO.");

            var registrations = await registrationQueryService.Handle
                (new GetRegistrationsByStateQuery(finalState));

            var registrationsResource = registrations.Select
                (RegistrationResourceFromEntityAssembler.ToResourceFromEntity);

            return Ok(registrationsResource);
        }
    }
}