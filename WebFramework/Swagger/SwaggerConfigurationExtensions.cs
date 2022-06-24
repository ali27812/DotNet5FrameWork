using Common.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WebFramework.Swagger
{
    public static class SwaggerConfigurationExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            Assert.NotNull(services, nameof(services));

            //Add services to use Example Filters in swagger
            //services.AddSwaggerExamples();
            //Add services and configuration to use swagger
            services.AddSwaggerGen(options =>
            {
                ////var xmlDocPath = Path.Combine(AppContext.BaseDirectory, "DotNet5FrameWork.xml");
                //////show controller XML comments like summary
                ////options.IncludeXmlComments(xmlDocPath, true);

                options.EnableAnnotations();
                //options.DescribeAllEnumsAsStrings();
                //options.DescribeAllParametersInCamelCase();
                //options.DescribeStringEnumsInCamelCase()
                //options.UseReferencedDefinitionsForEnums()
                //options.IgnoreObsoleteActions();
                //options.IgnoreObsoleteProperties();

                options.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "API V1" });
                options.SwaggerDoc("v2", new OpenApiInfo { Version = "v2", Title = "API V2" });

                #region Filters
                ////Enable to use [SwaggerRequestExample] & [SwaggerResponseExample]
                //options.ExampleFilters();

                ////Adds an Upload button to endpoints which have [AddSwaggerFileUploadButton]
                //options.OperationFilter<AddFileParamTypesOperationFilter>();

                //Set summary of action if not already set
                //options.OperationFilter<ApplySummariesOperationFilter>();

                #region Add UnAuthorized to Response
                //Add 401 response and security requirements (Lock icon) to actions that need authorization
                //ali
                //options.OperationFilter<UnauthorizedResponsesOperationFilter>(true, "Bearer");
                //ali
                #endregion

                //#region Add Jwt Authentication
                ////Add Lockout icon on top of swagger ui page to authenticate
                ///


                //////options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //////{
                //////    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //////    Name = "Authorization",
                //////    In = ParameterLocation.Header,
                //////    Type = SecuritySchemeType.ApiKey,
                //////    Scheme = "Bearer"
                //////});



                //options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                //{
                //    {"Bearer", new string[] { }}
                //});
                //options.AddSecurityDefinition("Bearer", new OAuth2Scheme
                //{
                //    Flow = "password",
                //    TokenUrl = "https://localhost:44378/api/v1/User/Token",
                //});
                //#endregion



                #region Versioning
                // Remove version parameter from all Operations
                options.OperationFilter<RemoveVersionParameters>();

                //set version "api/v{version}/[controller]" from current swagger doc verion
                options.DocumentFilter<SetVersionInPaths>();

                //Seperate and categorize end-points by doc version
                options.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                    var versions = methodInfo.DeclaringType
                        .GetCustomAttributes<ApiVersionAttribute>(true)
                        .SelectMany(attr => attr.Versions);

                    return versions.Any(v => $"v{v.ToString()}" == docName);
                });
                #endregion

                //If use FluentValidation then must be use this package to show validation in swagger (MicroElements.Swashbuckle.FluentValidation)
                //options.AddFluentValidationRules();
                #endregion
            });
        }

        public static void UseSwaggerAndUI(this IApplicationBuilder app)
        {
            Assert.NotNull(app, nameof(app));

            //Swagger middleware for generate "Open API Documentation" in swagger.json
            app.UseSwagger(options =>
            {
                //options.RouteTemplate = "api-docs/{documentName}/swagger.json";
            });

            //Swagger middleware for generate UI from swagger.json
            app.UseSwaggerUI(options =>
            {


                options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
                options.SwaggerEndpoint("/swagger/v2/swagger.json", "V2 Docs");
            });
        }
    }
}
