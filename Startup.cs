using AutoMapper;
using EntityFrameworkCore.UseRowNumberForPaging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using skm_back_dotnet.APIBehavior;
using skm_back_dotnet.Filters;
using skm_back_dotnet.Helpers;

namespace skm_back_dotnet;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => {
            options.UseSqlServer(Configuration.GetConnectionString("CS"), 
                                  sqlOptions => {
                                      sqlOptions.UseRowNumberForPaging();
                                      sqlOptions.UseNetTopologySuite();

                                  }
                                );
        });
        //Uma observação sobre paginação do EF, usando o glorioso SQL 2008
        //Criamos uma extenção de paginação que usa Skip e Take, que só funciona no SQL 2017 em diante
        // Instalei o pacote dotnet add package EntityFrameworkCore.UseRowNumberForPaging --version 0.3.0
        // E ativei o builder na configuração do serviço

        services.AddControllers(options => {
            options.Filters.Add(typeof(TheExceptionFilter));
            options.Filters.Add(typeof(ParseBadRequest));
        }).ConfigureApiBehaviorOptions(BadRequestBehavior.Parse);

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c => {
            c.SwaggerDoc("v1", new() { Title = "API Softkuka" , Version = "v1"} ); 
        });

        services.AddCors(options => {
            var frontendURL = Configuration.GetValue<string>("frontend_url");
            options.AddDefaultPolicy(builder => {
                builder
                    .WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader()
                    .WithExposedHeaders(new string[]{ "totalAmountOfRecords" });
            });
        });

        services.AddAutoMapper(typeof(Startup));

        services.AddSingleton(provider => new MapperConfiguration(config => {
            var geometryFactory = provider.GetRequiredService<GeometryFactory>();
            config.AddProfile(new AutoMapperProfiles(geometryFactory));
        }).CreateMapper());

        services.AddScoped<IFileStorageService, AzureStorageService>(); 
        //services.AddScoped<IFileStorageService, InAppStorageService>(); 
        services.AddSingleton<GeometryFactory>(NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326));
        services.AddHttpContextAccessor();

    }

    //Configura pipeline de execução
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();   

        app.UseCors();

        app.UseAuthentication();
        
        app.UseAuthorization();

        app.UseEndpoints(endpoints => {
            endpoints.MapControllers();
        });

    }
}
