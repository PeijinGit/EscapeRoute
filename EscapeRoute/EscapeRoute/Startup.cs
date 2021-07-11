using Azure.Storage.Blobs;
using Business;
using Business.Interfaces;
using DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoute
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(ac => ac.AddPolicy("any", ap => ap.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddSingleton(x=> new BlobServiceClient(Configuration.GetValue<string>("AzureBlobString")));
            services.Configure<AppSettingModels>(Configuration.GetSection("ConnectionStrings"));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,//是否验证Issuer
                        ValidateAudience = true,//是否验证Audience
                        ValidateLifetime = true,//是否验证失效时间
                        ClockSkew = TimeSpan.FromSeconds(30),
                        ValidateIssuerSigningKey = true,//是否验证SecurityKey
                        ValidAudience = ConstParam.Domain,//Audience
                        ValidIssuer = ConstParam.Domain,//Issuer，这两项和前面签发jwt的设置一致
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConstParam.SecurityKey))//拿到SecurityKey
                    };
                });
            services.AddScoped(typeof(IDataDAL), typeof(DAL.CoordinateRecDAL));
            services.AddScoped(typeof(IDataBLL), typeof(Business.CoordinateRecBLL));
            services.AddScoped(typeof(ISurveyDAL), typeof(DAL.SurveyRecDAL));
            services.AddScoped(typeof(ISurveyBLL), typeof(Business.SurveyRecBLL));
            services.AddScoped(typeof(IFileBLL), typeof(Business.FileBLL));
            services.AddScoped(typeof(IUser), typeof(Business.UserBLL));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("any");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
