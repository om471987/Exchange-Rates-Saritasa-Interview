using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.DataService.IoC
{
    public static class ModelContainer
    {
        private static readonly object _key = new object();
        private static UnityContainer _Instance;

        static ModelContainer()
        {
            _Instance = new UnityContainer();
        }

        public static UnityContainer Instance
        {
            get
            {
                _Instance.RegisterType<IDatabaseWrapper, DatabaseWrapper>(new HierarchicalLifetimeManager());
                _Instance.RegisterType<IExchangeRatesService, OpenExchangeRatesService>(new HierarchicalLifetimeManager());
                _Instance.RegisterType<IManager, Manager>(new HierarchicalLifetimeManager());
                return _Instance;
            }
        }
    }
}
