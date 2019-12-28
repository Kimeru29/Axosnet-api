using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace axos_api
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
      services.AddAuthentication(opt =>
      {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
    .AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = "http://localhost:5000",
        ValidAudience = "http://localhost:5000",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@99"))
      };
    });

      services.AddControllers();
      services.AddDbContext<AxosContext>(options =>
        options.UseSqlite("Filename=AxosDevEnv.db"));

      services.AddScoped<DbContext, AxosContext>();
      // services.AddScoped < IUserManager, UserManager<Usuario>();

      services.AddAutoMapper(typeof(Startup));

      // services.AddCors(o => o.AddPolicy("MuereCors", builder =>
      //   {
      //     builder.AllowAnyOrigin()
      //            .AllowAnyMethod()
      //            .AllowAnyHeader();
      //   }));

      services.AddCors(options =>
    {
      options.AddPolicy("MuereCors",
      builder =>
      {
        builder.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
      });
    });

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);





      // var builder = services.AddIdentityCore<AppUser>(o =>
      // {
      //   o.Password.RequireDigit = false;
      //   o.Password.RequireLowercase = false;
      //   o.Password.RequireUppercase = false;
      //   o.Password.RequireNonAlphanumeric = false;
      //   o.Password.RequiredLength = 6;
      // });
      // builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
      // builder.AddEntityFrameworkStores<AxosContext>().AddDefaultTokenProviders();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseCors(
        options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
    );


      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthentication();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });


    }
  }
}
