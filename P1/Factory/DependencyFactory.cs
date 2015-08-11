using Microsoft.Practices.Unity;
using P1.Config;
using P1.Enity;
using P1.Interface.Factory;
using P1.Interface.Util;
using P1.Util;

namespace P1.Factory
{
    //Wrapping Unity
    public class DependencyFactory
    {
        /// <summary>
        /// Public reference to the unity container which will 
        /// allow the ability to register instrances or take 
        /// other actions on the container.
        /// </summary>
        public static IUnityContainer Container { get; set; }

        /// <summary>
        /// Static constructor for DependencyFactory which will 
        /// initialize the unity container.
        /// </summary>
        static DependencyFactory()
        {
            var uc = new UnityContainer();

            //TODO: Change to XML COnfiguration

            /* ****************************************************** */
            /*             Common Registrations                       */
            /* ****************************************************** */
            uc.RegisterType<ILogger, Logger>();


            /* ****************************************************** */
            /*            Employee Registrations                      */
            /* ****************************************************** */
            uc.RegisterInstance(EmployeeConfig.Instance);
            uc.RegisterType<IEmployeeFactory, EmployeeFactory>();
            uc.RegisterType<IEmployeeFactory, EmployeeLoggingFactory>("Logging");

            /* ****************************************************** */
            /*            Country Registrations                       */
            /* ****************************************************** */
            uc.RegisterInstance(CountryConfig.Instance);
            uc.RegisterType<Factory<Country>>();


            /* ****************************************************** */
            /*                  Assign Container                      */
            /* ****************************************************** */
            Container = uc;
        }

        /// <summary>
        /// Resolves the type parameter T to an instance of the appropriate type.
        /// </summary>
        /// <typeparam name="T">Type of object to return</typeparam>
        public static T Resolve<T>()
        {
            T ret = default(T);

            if (Container.IsRegistered(typeof(T)))
            {
                ret = Container.Resolve<T>();
            }

            return ret;
        }

        public static T Resolve<T>(string name)
        {
            T ret = default(T);

            if (Container.IsRegistered(typeof(T), name))
            {
                ret = Container.Resolve<T>(name);
            }

            return ret;
        }

    }
}