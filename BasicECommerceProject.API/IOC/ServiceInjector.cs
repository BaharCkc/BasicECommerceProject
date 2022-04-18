using BasicECommerceProject.Business.IService;
using BasicECommerceProject.Business.IUnitOfWorks;
using BasicECommerceProject.Business.Service;
using BasicECommerceProject.Business.UnitOfWorks;
using BasicECommerceProject.DataAccess.DbContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceProject.API.IOC
{
    public class ServiceInjector
    {
        public static void Add(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnectionString");

            services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer(connectionString, optionsBuilder =>
                optionsBuilder.MigrationsAssembly("BasicECommerceProject.DataAccess")), ServiceLifetime.Scoped
            );

            //JWT Begin

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {

                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "officeerpapi.com",
                    ValidIssuer = "officeerpapi.com",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"))

                };
            });

            //JWT End

            services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IOrderService, OrderService>();
        }
    }
}
