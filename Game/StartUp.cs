using Game.GameWorld;
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
        services.AddSingleton<IUI, ConsoleUI>();
        services.AddSingleton(configuration);
    }

    private IConfiguration GetConfig()
    {
        return new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();
    }
}