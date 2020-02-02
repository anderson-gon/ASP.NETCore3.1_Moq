using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq.Application.Contracts.V1;
using Moq.Application.Interfaces;

namespace Moq.API.Controllers
{
    [ApiController]
    [Route("[v1/controller]")]
    public class UserController : ControllerBase
    {
       
        private readonly ILogger<UserController> _log;
        private readonly IUserAppService _userAppService;

        public UserController(ILogger<UserController> log,
                        IUserAppService userAppService)
        {
            _log = log;
            _userAppService = userAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDTO request)
        {
            try
            {
                await _userAppService.AddUserAsync(request);
                return new OkResult();
            }
            catch (Exception e)
            {
                _log.LogError(e, "Error on processing request");
                return new BadRequestObjectResult(new
                {
                    error = e.Message,
                    stackTrace = e.StackTrace
                });
            }
        }
    }
}
