using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TPISubastas.AccesoDatos;
using TPISubastas.Sitio.Models;
using TPISubastas.Sitio.HostedServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace TPISubastas.Sitio
{
   public class Startup
   {
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.

      private void Encrypt()
      {
         

      }

      public void ConfigureServices(IServiceCollection services)
      {
         string key = Configuration.GetValue<string>("TokenKey");
         TokenValidationParameters TokenOptions = new TokenValidationParameters()
         {
            ValidateIssuer = true,
            ValidIssuer = "TPISubastas.Sitio",
            ValidateAudience = true,
            ValidAudience = "Usuarios",
            ValidateIssuerSigningKey = true,

            //Me queda pendiente aprender a hacerlo correctamente
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key)),
            RequireExpirationTime = true,
            ValidateLifetime = true,
            ClockSkew = new TimeSpan(0)
         };
         services.AddSingleton(TokenOptions);

         services.AddDbContext<ContextoSubasta>(x =>
         {
            x.UseSqlServer(Configuration.GetConnectionString("TPISubastas.SQLServer"), x => x.MigrationsAssembly("TPISubastas.Sitio"));
         });
         services.AddDbContext<Security.SecurityContext>(x =>
         {
            x.UseSqlServer(Configuration.GetConnectionString("TPISubastas.Seguridad"), x => x.MigrationsAssembly("TPISubastas.Sitio"));
         });
         services.AddAuthentication(o =>
         {
            o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
         }).AddCookie(o =>
         {
            o.LoginPath = "/Account/Login";
            o.ExpireTimeSpan = new TimeSpan(0, 30, 0);
            o.SlidingExpiration = true;
         }).AddJwtBearer(o =>
         {
            o.TokenValidationParameters = TokenOptions;
         });

         services.AddIdentity<Security.SecurityUser, Security.SecurityRole>(o =>
         {
            o.User.RequireUniqueEmail = true;
            o.Password.RequiredLength = 8;
            o.Password.RequireNonAlphanumeric = false;
            o.Password.RequireUppercase = true;
            o.Password.RequireDigit = true;
            o.Password.RequireLowercase = true;

         }).AddEntityFrameworkStores<Security.SecurityContext>();

         services.AddControllersWithViews();

         services.AddHostedService<EstadoSubastaHostedService>();
         services.AddHostedService<UsuarioGanadorHostedService>();
         services.AddHostedService<SubastaHabilitadaHostedService>();
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }
         else
         {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
         }
         app.UseHttpsRedirection();
         app.UseStaticFiles();

         app.UseRouting();

         app.UseAuthentication();

         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");
         });
      }
   }
}
