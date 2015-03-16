using System;

namespace Joerg.Battermann.TfsToolkit.ExtensionMethods
{
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// Tries to get a service.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static T TryGetService<T>(this IServiceProvider serviceProvider, T defaultValue = default(T))
        {
            if (serviceProvider == null)
                return defaultValue;

            return (T)serviceProvider.GetService(typeof(T));
        }
    }
}
