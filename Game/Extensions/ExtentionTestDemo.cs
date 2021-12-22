using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Extensions
{
    public static class ExtentionTestDemo
    {
        private static readonly IGetMapSize defaultImplementation = new GetMapSize();
        public static IGetMapSize Implemetation { private get; set; } = defaultImplementation;
        internal static int GetMapSizeFor(this IConfiguration configuratin, string value)
        {
            return Implemetation.GetMapSizeFor(configuratin, value);
        } 
    }

    public class GetMapSize : IGetMapSize
    {
        public int GetMapSizeFor(IConfiguration configuratin, string value)
        {
            var section = configuratin.GetSection("game:mapsettings");
            return int.TryParse(section[value], out int result) ? result : 0;
        }
    }

    public interface IGetMapSize
    {
        int GetMapSizeFor(IConfiguration configuratin, string value);
    }
}
