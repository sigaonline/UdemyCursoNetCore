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
using Microsoft.Net.Http.Headers;
using Tapioca.HATEOAS;
using UdemyCurso.Hypermedia;
using Microsoft.AspNetCore.Rewrite;

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
            services.AddMvc(option => 
            { 
                option.EnableEndpointRouting = false;
                option.RespectBrowserAcceptHeader = true;
                option.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                option.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("text/json"));
            }
            )
                .AddXmlSerializerFormatters();

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ObjectContentResponseEnricherList.Add(new PersonEnricher());
            
            services.AddSingleton(filterOptions);
            
            services.AddApiVersioning();
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new  Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "ReSTful API ASP.NET Core"
                });
            });
            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IBookBusiness, BookBusinessImpl>();
            services.AddScoped<IPersonRepository, PersonRepositoryImpl>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("v1/swagger.json", "My API V1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseMvc( routes => 
            {
                routes.MapRoute(
                    name : "DefaultApi",
                    template : "{controller=Values}/{id?}"
                    );
            });
            //loggerFactory.AddConsole(_configuration.GetSection("Logging"));

            //app.UseRouting();
            //app.UseEndpoints(builder => builder.MapControllers());

        }
    }
}
