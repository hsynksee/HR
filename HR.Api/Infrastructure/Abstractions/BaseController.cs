using HR.Service.ServiceInterfaces.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SharedKernel.Abstractions;
using SharedKernel.Constants;
using SharedKernel.Exceptions;

namespace HR.Api.Infrastructure.Abstractions
{
    [Authorize()]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        private readonly ISystemAppService _systemAppService;

        public BaseController(ISystemAppService systemAppService)
        {
            _systemAppService = systemAppService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await _systemAppService.SetUserPermissionsAsync();

            await base.OnActionExecutionAsync(context, next);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            var ex = context.Exception;

            if (ex != null)
            {
                if (ex is UnauthorizedAccessException)
                    context.Result = new UnauthorizedObjectResult(new BaseResponse("Yetkisiz işlem"));

                else if (ex is ForbiddenAccessException)
                    context.Result = StatusCode(StatusCodes.Status403Forbidden, new BaseResponse("Yetkisiz Erişim"));

                else
                    //TODO: Canlıda stacktrace verilmemeli.
                    context.Result = StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse($"{ex.Message}--{ex.InnerException?.Message}"));
                // context.Result = StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse("İşleminizi gerçekleştirirken bir hata oluştu."));
                //TODO: Canlıda stacktrace verilmemeli.

                context.ExceptionHandled = true;
            }
        }
    }
}
