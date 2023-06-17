using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace App.Utilities
{
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Uses reflection to set the properties
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configuration"></param>
        /// <param name="target"></param>
        /// <param name="propsToSkip"></param>
        public static void SetProps<T>(this IConfiguration configuration, T target, params string[] propsToSkip)
        {

        }
    }
}
