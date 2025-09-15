using ObserverPatternAPI.BusinessLogic;
using ObserverPatternAPI.Factories;
using ObserverPatternAPI.Interfaces;
using ObserverPatternAPI.Observers;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        //You register the Observable
        builder.Services.AddHttpClient<PokeObservable>();
        builder.Services.AddSingleton<IPokeObservable, PokeObservable>();

        //You register the Factory
        builder.Services.AddSingleton<ObserverFactory>();

        //We register the Observers
        builder.Services.AddScoped<IObserver, CharizardObserver>();
        builder.Services.AddScoped<IObserver, IvysaurObserver>();
        builder.Services.AddScoped<IObserver, SquirtleObserver>();
        builder.Services.AddScoped<IObserver, WartortleObserver>();

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
