using ObserverPatternAPI.BusinessLogic;
using ObserverPatternAPI.Factories;
using ObserverPatternAPI.Interfaces;
using ObserverPatternAPI.Observers;

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
        builder.Services.AddHttpClient<PokeObservable>();
        builder.Services.AddSingleton<IPokeObservable, PokeObservable>();
        builder.Services.AddSingleton<ObserverFactory>();
        // builder.Services.AddHttpClient<PokeObservable>().Services.AddScoped<IPokeObservable, PokeObservable>();
        // builder.Services.AddSingleton<IPokeObservable, PokeObservable>();

        // builder.Services.AddHttpClient<PokeObservable>(client =>
        // {
        //     client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        // }).Services.AddSingleton<IPokeObservable, PokeObservable>();

        // builder.Services.AddScoped<IPokeObservable, PokeObservable>();

        //We construct the Observers
        builder.Services.AddScoped<IObserver, CharizardObserver>();
        builder.Services.AddScoped<IObserver, IvysaurObserver>();
        builder.Services.AddScoped<IObserver, SquirtleObserver>();
        builder.Services.AddScoped<IObserver, WartortleObserver>();

        // builder.Services.AddHttpClient<PokeObservable>().Services.AddSingleton<IPokeObservable, PokeObservable>();
    
        // builder.Services.AddSingleton<IObserver, CharizardObserver>();
        // builder.Services.AddSingleton<IObserver, IvysaurObserver>();
        // builder.Services.AddSingleton<IObserver, SquirtleObserver>();
        // builder.Services.AddSingleton<IObserver, WartortleObserver>();



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
