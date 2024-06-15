using Energy.API.Configurations;
using Microsoft.OpenApi.Models;

namespace Energy.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new()
                {
                    Title = "Energy API",
                    Version = "v1",
                    Description = "Energy API DOCS",
                    Contact = new OpenApiContact
                    {
                        Name = "William Queiroz",
                        Email = "awconsultec@gmail.com",
                        Url = new Uri("https://github.com/willqz"),
                    },
                });
            });

            services.AddMvc();

            services.ResolveDependencies();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Energy API");
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();
            app.UseCors("AllowOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
