using Microsoft.AspNetCore.Authentication.JwtBearer;
using skm_back_dotnet.Filters;
using skm_back_dotnet.Services;

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
        services.AddControllers(options => {
            options.Filters.Add(typeof(TheExceptionFilter));
        });

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c => {
            c.SwaggerDoc("v1", new() { Title = "API Softkuka" , Version = "v1"} ); 
        });

        //Configurações de DI  AddTransient (1 nova instancia a cada chamada) AddScope(Mesma instancia por http req) AddSingleton(Mesma instancia sempre)
        services.AddSingleton<IRepository, InMemoryRepository>();
        services.AddTransient<TheActionFilter>();
    }

    //Configura pipeline de execução
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
    {
        //Exemplo de interceptação do pipeline - para qualquer rota
        // app.Run(async ctx => {
        //     await ctx.Response.WriteAsync("Interceptei a requisição");
        // });

        //Desvio de rota seletivo - tira do asp.net um determinada rota
        // app.Map("/map1", (app) => {
        //     app.Run(async ctx => {
        //     await ctx.Response.WriteAsync("Map1 roda fora do asp.net");
        //  });
        // });

        //Com Use, conseguimos interceptr pipeline na ida e na volta. O fluxo não para.
        //Nesse caso exemplo para logar a resposta de todas as requisições

        // app.Use(async (ctx, next) => {
        //     using(var swapStream = new MemoryStream()){
        //         var originalResponseBody = ctx.Response.Body;
        //         ctx.Response.Body = swapStream;

        //         await next.Invoke();

        //         swapStream.Seek(0, SeekOrigin.Begin);
        //         string responseBody = new StreamReader(swapStream).ReadToEnd();
        //         swapStream.Seek(0, SeekOrigin.Begin);

        //         await swapStream.CopyToAsync(originalResponseBody);
        //         ctx.Response.Body = originalResponseBody;

        //         logger.LogInformation(responseBody);
        //     }
        // });

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();   

        app.UseAuthentication();
        
        app.UseAuthorization();

        app.UseEndpoints(endpoints => {
            endpoints.MapControllers();
        });

    }
}
