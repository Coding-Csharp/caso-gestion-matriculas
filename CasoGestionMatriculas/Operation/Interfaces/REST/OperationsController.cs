using CasoGestionMatriculas.Operation.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

    }
}