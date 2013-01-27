using Microsoft.Practices.Unity;

namespace ExchangeRates
{
    public class ResolveType
    {
        private readonly UnityContainer _container;
        private static ResolveType _getType;

        private ResolveType()
        {
            _container = new UnityContainer();
            _container.RegisterType<IDatabaseWrapper, DatabaseWrapper>();
            _container.RegisterType<IOpenExchangeRatesService, OpenExchangeRatesService>();
            _container.RegisterType<IManager, Manager>();
        }

        public static ResolveType GetInstance()
        {
            return _getType ?? (_getType = new ResolveType());
        }

        public Manager Manager()
        {
            return _container.Resolve<Manager>();
        }
    }
}
