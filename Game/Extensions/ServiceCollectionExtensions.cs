using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static void GetUI(this ServiceCollection services, IConfiguration config)
        {
            var ui = config.GetSection("game:ui").Value;

            switch (ui)
            {
                case "console":
                    services.AddSingleton<IUI, ConsoleUI>();
                    break;
                default:
                    break;
            }
        }
    }
}
