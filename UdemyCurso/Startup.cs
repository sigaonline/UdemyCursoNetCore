using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using UdemyCurso.Model.Context;
using UdemyCurso.Business;
using UdemyCurso.Business.Implementation;
using UdemyCurso.Repository.Implementation;
using UdemyCurso.Repository;

using System.Collections.Generic;
using UdemyCurso.Repository.Generic;

namespace UdemyCurso
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            _logger = logger;
        }

        public IConfiguration _configuration { get; }
        private readonly ILogger _logger;
        public IHostingEnvironment _environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connectionString));

            if (_environment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                    var evolve = new Evolve.Evolve(evolveConnection, MsgBoxResult => _logger.LogInformation(MsgBoxResult))
                    {
                        Locations = new List<string> { "db/migrations" },
                        IsEraseDisabled = true,
                    };
                    evolve.Migrate();

                }
                catch (System.Exception ex)
                {
                    _logger.LogCritical("Database migration failed.",ex);
                    throw ex;
                }
            }
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(_configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });

            //services.AddControllers();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddApiVersioning();
            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IPersonRepository, PersonRepositoryImpl>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            //loggerFactory.AddConsole(_configuration.GetSection("Logging"));

            app.UseRouting();
            app.UseEndpoints(builder => builder.MapControllers());

        }
    }
}
