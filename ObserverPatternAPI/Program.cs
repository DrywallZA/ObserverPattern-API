

using ObserverPatternAPI.BusinessLogic;
using ObserverPatternAPI.Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        //You contruct the Observable
        builder.Services.AddHttpClient<IPokeObservable, PokeObservable>();



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        // app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}
