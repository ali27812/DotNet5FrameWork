//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using DotNet5FrameWork.Models;
//using Data.Contracts;
//using Data.Repositories;
//using Entites;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Services.Services;
//using WebFramework.Api;

//namespace DotNet5FrameWork.Controllers.v2
//{
//    //[ApiVersion("2")]
//    [Route("api/v2/[controller]")]// api/v2/test
//    public class UserController : v1.UserController
//    {
//        public UserController(IUserRepository userRepository, IJwtService jwtService, ILogger<v1.UserController> logger) : base(userRepository, jwtService, logger)
//        {
//        }

//        public override Task<ApiResult<User>> Create(UserDto userDto, CancellationToken cancellationToken)
//        {
//            return base.Create(userDto, cancellationToken);
//        }

//        public override Task<ApiResult> Delete(int id, CancellationToken cancellationToken)
//        {
//            return base.Delete(id, cancellationToken);
//        }

//        public override Task<ActionResult<List<User>>> Get(CancellationToken cancellationToken)
//        {
//            return base.Get(cancellationToken);
//        }

//        public override Task<ApiResult<User>> Get(int id, CancellationToken cancellationToken)
//        {
//            return base.Get(id, cancellationToken);
//        }

//        public override Task<ActionResult<string>> Token(TokenModel tokenModel, CancellationToken cancellationToken)
//        {
//            return base.Token(tokenModel, cancellationToken);
//        }

//        public override Task<ApiResult> Update(int id, UserDto user, CancellationToken cancellationToken)
//        {
//            return base.Update(id, user, cancellationToken);
//        }
//    }
//}
