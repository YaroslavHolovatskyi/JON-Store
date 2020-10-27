using Microsoft.Extensions.Configuration;

namespace JON_Store.Infrastructure
{
    public static class ConfigurationExtensions
    {
        public static T Bind<T>(this IConfiguration configuration, string key)
            where T : new()
        {
            var instanceToBind = new T();
            configuration.Bind(key, instanceToBind);
            return instanceToBind;
        }
    }
}
