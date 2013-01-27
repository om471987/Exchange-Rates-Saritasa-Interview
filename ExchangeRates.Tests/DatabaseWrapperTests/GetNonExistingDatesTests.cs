using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExchangeRates.Tests
{
    [TestClass]
    public class GetNonExistingDatesTests
    {
        private DateTime _dateTime; 

        [TestInitialize]
        public void Setup()
        {
            _dateTime = DateTime.Now.AddDays(-4);
        }

        [TestMethod]
        public void GetNonExistingDatesNotNull()
        {
            //Assert.IsNotNull(DatabaseWrapper.GetNonExistingDates(_dateTime, 2));
        }
    }
}
