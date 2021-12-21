using Game.Entities.Items;
using Game.Extensions;
using Game.GameWorld;
using Game.LimitedList;
using Game.UserInterface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal class StartUp
{
    private IConfiguration configuration = null!;

    internal void SetUp()
    {
        configuration = GetConfig();
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        serviceProvider.GetRequiredService<GamePlay>().Run();

    }

    private void ConfigureServices(ServiceCollection services)
    {
        services.AddSingleton<GamePlay>();
        services.AddSingleton<IMap, Map>();
        services.GetUI(configuration);
        //services.AddSingleton<IUI, ConsoleUI>();
        services.AddSingleton(configuration.GetSection("game:mapsettings").Get<MapSettings>());
        services.Configure<MapSettings>(configuration.GetSection("game:mapsettings").Bind);
        services.AddSingleton(configuration);
        services.AddSingleton<ILimitedList<string>>(new MessageLog<string>(6));
        services.AddSingleton<ILimitedList<Item>>(new MessageLog<Item>(3));
    }

    private IConfiguration GetConfig()
    {
        return new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();
    }
}