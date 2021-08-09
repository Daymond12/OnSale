using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OnSale.Web.Data;
using OnSale.Web.Data.Entities;
using OnSale.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnSale.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;

            });

            //servicio para ruta no autorixada
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/NotAuthorized";
                options.AccessDeniedPath = "/Account/NotAuthorized";
            });

            //Inyección a la conexión de la base de datos
            services.AddDbContext<DataContext>(cfg =>
            {
                //UseSqlServer usa el EF Core
                //el parametro Configuration hala del appsettings la DefaultConnection
                cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAuthentication()
            .AddCookie()
            //Vea hermano ud va usar unos token llamados token bearer
            .AddJwtBearer(cfg =>
            {
                cfg.TokenValidationParameters = new TokenValidationParameters//librerias de token
                {
                    ValidIssuer = Configuration["Tokens:Issuer"],//vienen del appsettings
                    ValidAudience = Configuration["Tokens:Audience"],////vienen del appsettings
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))////vienen del appsettings
                };
            });



            services.AddTransient<SeedDb>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //inyectar el IBlobHelper como una implementacion de BlobHelper
            //inyectar el IConverterHelper como una implementacion de ConverterHelper
            services.AddScoped<IBlobHelper, BlobHelper>();
            services.AddScoped<IConverterHelper, ConverterHelper>();
            services.AddScoped<ICombosHelper, CombosHelper>();
            //inyectamos el IuserHelper
            services.AddScoped<IUserHelper, UserHelper>();

            //Servicios para trabajar con roles y usuarios
            services.AddIdentity<User, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;//tener un unico email
                cfg.Password.RequireDigit = false;//que mi pass tenga digitos?no
                cfg.Password.RequiredUniqueChars = 0;//que tenga caracter unico?no
                cfg.Password.RequireLowercase = false;//que tenga una minuscula?no
                cfg.Password.RequireNonAlphanumeric = false;//que tanga un alfanumerico?no
                cfg.Password.RequireUppercase = false;//que tenga una mayuscula?no
            }).AddEntityFrameworkStores<DataContext>();
        }



        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            //cuando no se encuentre la pagina
            app.UseStatusCodePagesWithReExecute("/error/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();//aqui le indicamos que la aplicacion usa antentificación
           // app.UseCookiePolicy();



            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
