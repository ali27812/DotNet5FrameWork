using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.Api;
using WebFramework.Filters;

namespace DotNet5FrameWork.Controllers
{
    [AllowAnonymous]
    [ApiResultFilter]
    [ApiController]
    [Route("api/[controller]")]// api/v2/test
    public class HomeController : ControllerBase
    {
        [HttpGet("[action]")]
        public string GetName()
        {
            return "fgff";
        }
    }
}
