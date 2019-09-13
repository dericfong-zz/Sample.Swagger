using System;
using Microsoft.AspNetCore.Mvc;

namespace Sample.Swagger.Controllers
{
    public class DefaultController : Controller
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public IActionResult Index()
        {
            if (IsDebug)
            {
                return Redirect("/swagger/");
            }
            else
            {
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                return Ok($"{environment} API is up!");
            }
        }

        public static bool IsDebug
        {
            get
            {
                bool isDebug = false;
#if DEBUG
                isDebug = true;
#endif
                return isDebug;
            }
        }
    }
}