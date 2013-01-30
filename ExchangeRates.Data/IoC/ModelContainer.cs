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

        public static UnityContainer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_key)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new UnityContainer();
                            _Instance = new UnityContainer();
                            _Instance.RegisterType<IDatabaseWrapper, DatabaseWrapper>();
                            _Instance.RegisterType<IExchangeRatesService, OpenExchangeRatesService>();
                            _Instance.RegisterType<IManager, Manager>();
                        }
                    }
                }
                return _Instance;
            }

        }

    }
}
