using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebFramework.Filters;

namespace WebFramework.Api
{
    [AllowAnonymous]
    [ApiResultFilter]
    [ApiController]
    //[Route("api/v{version:apiVersion}/[controller]")]// api/v1/test
    public class BaseController : ControllerBase
    {
        //public UserRepository UserRepository { get; set; } => property injection
        //public bool UserIsAutheticated => HttpContext.User.Identity.IsAuthenticated;
    }
}
