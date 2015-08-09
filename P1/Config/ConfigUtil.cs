using System;
using P1.Enity;

namespace P1.Config
{
    public static class ConfigUtil
    {
        public static IConfig<T> GetConfig<T>()
        {
            if (typeof(T) == typeof(Employee))
               return (IConfig<T>)EmployeeConfig.Instance;

            if (typeof(T) == typeof(Country))
                return (IConfig<T>)CountryConfig.Instance;

            return null;
        }
    }
}