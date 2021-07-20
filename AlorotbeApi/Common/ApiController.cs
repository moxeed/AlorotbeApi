using AlorotbeApi;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Alorotbe.Api.Common
{
    [ApiController]
    [EnableCors(Startup.AllowAny)]
    [Route("[controller]/[action]")]
    public class ApiController : ControllerBase
    {
    }
}
