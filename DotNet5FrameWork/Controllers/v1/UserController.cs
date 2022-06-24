////using Microsoft.AspNetCore.Authorization;
////using Microsoft.AspNetCore.Mvc;
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Threading.Tasks;
//using DotNet5FrameWork.Models;
//using Common.Utilities;
//using Data.Contracts;
//using Entites;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using Services.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using WebFramework.Api;
//using WebFramework.Middlewares;

//namespace DotNet5FrameWork.Controllers.v1
//{
//    [Route("api/v1/[controller]")]// api/v1/test
//    //[ApiVersion("1")]
//    public class UserController : BaseController
//    {
//        private readonly ILogger<UserController> _log;
//        //seriLog
//        private readonly IUserRepository userRepository;
//        private readonly IJwtService jwtService;

//        public UserController(IUserRepository userRepository, IJwtService jwtService, ILogger<UserController> logger)
//        {
//            this.userRepository = userRepository;
//            this.jwtService = jwtService;
//            _log = logger;
//        }
//        [AllowAnonymous]
//        [HttpGet]
//        public virtual async Task<ActionResult<List<User>>> Get(CancellationToken cancellationToken)
//        {
//            //var userName = HttpContext.User.Identity.GetUserName();
//            //userName = HttpContext.User.Identity.Name;
//            //var userId = HttpContext.User.Identity.GetUserId();
//            //var userIdInt = HttpContext.User.Identity.GetUserId<int>();
//            //var phone = HttpContext.User.Identity.FindFirstValue(ClaimTypes.MobilePhone);
//            //var role = HttpContext.User.Identity.FindFirstValue(ClaimTypes.Role);

//            var users = await userRepository.TableNoTracking.ToListAsync(cancellationToken);
//            return Ok(users);
//        }
//        [HttpGet("{id:int}")]
//        public virtual async Task<ApiResult<User>> Get(int id, CancellationToken cancellationToken)
//        {
//            var user = await userRepository.GetByIdAsync(cancellationToken, id);
//            if (user == null)
//                return NotFound();



//            return user;
//        }
//        [AllowAnonymous]
//        [HttpPost]
//        [Route("Token")]
//        public virtual async Task<ActionResult<string>> Token(TokenModel tokenModel, CancellationToken cancellationToken)//TokenModel tokenModel,
//        {
//            //HttpContext.RiseError(new Exception("متد Create فراخوانی شد"));
//            //seriLog
//            _log.LogError("Hello, world!");
//            //test call view method
//            //userRepository.GetStoreProce();
//            var UserAndPassObject = (TokenValues)HttpContext.Items["UserAndPassValue"];
//            string userName, passWord;
//            if (UserAndPassObject != null)
//            {
//                userName = UserAndPassObject.UserName;
//                passWord = UserAndPassObject.PassWord;
//            }
//            else
//            {
//                userName = tokenModel.UserName;
//                passWord = tokenModel.Password;
//            }
//            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord))
//            {
//                return BadRequest("نام کاربری و کلمه عبور را وارد کنید..");
//            }
//            else
//            {
//                var user = await userRepository.GetByUserAndPass(userName, passWord, cancellationToken);
//                if (user == null)
//                    return BadRequest("نام کاربری یا کلمه عبور معتبر نمی باشد.");

//                var jwt = jwtService.Generate(user);
//                return jwt;
//            }

//        }

//        [AllowAnonymous]
//        [HttpPost]
//        public virtual async Task<ApiResult<User>> Create(UserDto userDto, CancellationToken cancellationToken)
//        {

//            //var user = new User
//            //{
//            //    Age = userDto.Age,
//            //    FullName = userDto.FullName,
//            //    Gender = userDto.Gender,
//            //    UserName = userDto.UserName
//            //};
//            //var user = Mapper.Map<User>(userDto);
//            var user = userDto.ToEntity();
//            await userRepository.AddAsync(user, userDto.Password, cancellationToken);
//            return user;
//        }

//        [HttpPut]
//        public virtual async Task<ApiResult> Update(int id, UserDto user, CancellationToken cancellationToken)
//        {
//            var updateUser = await userRepository.GetByIdAsync(cancellationToken, id);

//            //updateUser.UserName = user.UserName;
//            //updateUser.PasswordHash = user.PasswordHash;
//            //updateUser.FullName = user.FullName;
//            //updateUser.Age = user.Age;
//            //updateUser.Gender = user.Gender;
//            //updateUser.IsActive = user.IsActive;
//            //updateUser.LastLoginDate = user.LastLoginDate;
//            //Mapper.Map(user, updateUser);
//            updateUser = user.ToEntity(updateUser);
//            await userRepository.UpdateAsync(updateUser, cancellationToken);

//            await userRepository.UpdateSecuirtyStampAsync(updateUser, cancellationToken);

//            return Ok();
//        }

//        [HttpDelete]
//        public virtual async Task<ApiResult> Delete(int id, CancellationToken cancellationToken)
//        {
//            var user = await userRepository.GetByIdAsync(cancellationToken, id);
//            await userRepository.DeleteAsync(user, cancellationToken);

//            return Ok();
//        }
//    }
//}
