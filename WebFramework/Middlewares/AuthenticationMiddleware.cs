using Data.Contracts;
using Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace WebFramework.Middlewares
{   
   

    public class TokenValues
    {
       
        public TokenValues() { }

       
        public TokenValues(string first, string last)
        {
            UserName = first;
            PassWord = last;
        }

        // Properties.
        public string UserName { get; set; }
        public string PassWord { get; set; }
      
    }

    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;


        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context,IUserRepository userRepository)
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                //Extract credentials
                string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

                int seperatorIndex = usernamePassword.IndexOf(':');

                var username = usernamePassword.Substring(0, seperatorIndex);
                var password = usernamePassword.Substring(seperatorIndex + 1);
                var user = await userRepository.GetByUserAndPass(username, password, CancellationToken.None);
                if (user==null)
                {
                    context.Items.Add("UserAndPassValue", null);
                    await _next.Invoke(context);
                    //context.Response.StatusCode = 401;
                    //Unauthorized
                    //return;


                }
                else
                {                    
                    TokenValues UserAndPassValue = new TokenValues
                    {
                        UserName = username,
                        PassWord = password,
                    };
                    context.Items.Add("UserAndPassValue", UserAndPassValue);
                    await _next.Invoke(context);
                }
            }
            else
            {
                // no authorization header
                context.Items.Add("UserAndPassValue", null); //Unauthorized
                await _next.Invoke(context); ;
            }
        }
    }
}
