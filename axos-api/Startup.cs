using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
      services.AddControllers();
      services.AddDbContext<AxosContext>(options =>
        options.UseSqlite("Filename=AxosDevEnv.db"));

      services.AddScoped<DbContext, AxosContext>();
      // services.AddScoped < IUserManager, UserManager<Usuario>();

      services.AddAutoMapper(typeof(Startup));

      services.AddCors(options =>
            {
              options.AddPolicy("AllowAll",
                  p => p.AllowAnyOrigin().
                      AllowAnyHeader().
                      AllowAnyMethod()
              );
            });


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

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
