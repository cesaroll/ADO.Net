using Base.Factory;
using Base.Interface.Util;
using Base.Util;
using DB.Config;
using DB.Entity;
using DB.Interface.Factory;
using Microsoft.Practices.Unity;


namespace DB.Factory
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
            //http://www.codeproject.com/Articles/143258/Revisiting-XML-Configurations-In-Unity
            //https://msdn.microsoft.com/en-US/library/Ff647848.aspx

            /* ****************************************************** */
            /*             Common Registrations                       */
            /* ****************************************************** */
            uc.RegisterType<ILogger, Logger>();
            uc.RegisterType<IDBUtil, DBUtil>();

            uc.RegisterInstance(DBUtil.Instance);
            
            /* ****************************************************** */
            /*            Employee Registrations                      */
            /* ****************************************************** */
            uc.RegisterType<IEmployeeFactory, EmployeeFactory>();
            uc.RegisterType<IEmployeeFactory, EmployeeLoggingFactory>("Logging");
            
            uc.RegisterInstance(EmployeeConfig.Instance);
            
            /* ****************************************************** */
            /*            Country Registrations                       */
            /* ****************************************************** */
            uc.RegisterType<Factory<Country>>();

            uc.RegisterInstance(CountryConfig.Instance);
            
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