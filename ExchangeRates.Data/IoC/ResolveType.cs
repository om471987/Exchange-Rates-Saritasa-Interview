using Microsoft.Practices.Unity;

namespace ExchangeRates.DataService
{
    /// <summary>
    /// It is a central place to register interfaces with their concrete types
    /// </summary>
    public class ResolveType
    {
        private readonly UnityContainer _container;
        private static ResolveType _getType;

        /// <summary>
        /// Types are registered
        /// </summary>
        private ResolveType()
        {
            _container = new UnityContainer();
            _container.RegisterType<IDatabaseWrapper, DatabaseWrapper>();
            _container.RegisterType<IExchangeRatesService, OpenExchangeRatesService>();
            _container.RegisterType<IManager, Manager>();
        }

        /// <summary>
        /// Static method to get Singleton object
        /// </summary>
        /// <returns></returns>
        public static ResolveType GetInstance()
        {
            return _getType ?? (_getType = new ResolveType());
        }

        /// <summary>
        /// Return new manager object whenever asked
        /// </summary>
        /// <returns></returns>
        public Manager Manager()
        {
            return _container.Resolve<Manager>();
        }
    }
}
