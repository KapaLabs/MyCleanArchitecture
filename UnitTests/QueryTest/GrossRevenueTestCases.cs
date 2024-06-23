using Moq;
using Self.CleanArchitecture.Usecase;
using Self.CleanArchitecture.Persistence;

namespace UnitTests
{
    public class GrossRevenueTestCases
    {

        [Fact]
        public void CalculationAverage()
        {
            Guid aeTransport = Guid.NewGuid();
            List<ICountryWiseBusiness> countryWiseBusinesses = new() {
                new CountryWiseBusinessDTO(){BusinessId = aeTransport,BusinessName = "transport",CountryName = "ae"},
            };
            List<IRevenue> businessRevenues = new(){
                new BusinessRevenueDTO(){BusinessId = aeTransport,Year = 2010,Value = 231441262.7m},
                new BusinessRevenueDTO(){BusinessId = aeTransport,Year = 2011,Value = 268744928.7m},

            };

            Mock<IReadRepository> _readRepositoryMock = new();
            _readRepositoryMock.Setup(business => business.CountryBusiness).Returns(countryWiseBusinesses.AsQueryable());
            _readRepositoryMock.Setup(revenues => revenues.BusinessRevenue).Returns(businessRevenues.AsQueryable());
            
            CountryGWPQueryHandler queryHandler = new CountryGWPQueryHandler(_readRepositoryMock.Object);
           var result =  queryHandler.Handle(new CountryGWPQuery("ae", new string[] { "transport" }), new CancellationTokenSource().Token);

            Assert.True(result.Result.BusinessesRevenues.Select(item => item.GrossRevenue).Sum() == 250093095.7m);


        }

        [Fact]
        public void CheckTimeFilter()
        {
            Guid aeTransport = Guid.NewGuid();
            List<ICountryWiseBusiness> countryWiseBusinesses = new() {
                new CountryWiseBusinessDTO(){BusinessId = aeTransport,BusinessName = "transport",CountryName = "ae"},
            };
            List<IRevenue> businessRevenues = new(){
                new BusinessRevenueDTO(){BusinessId = aeTransport,Year = 2000,Value = 231441262.7m}, // this will be skipped
                new BusinessRevenueDTO(){BusinessId = aeTransport,Year = 2011,Value = 268744928.7m},

            };

            Mock<IReadRepository> _readRepositoryMock = new();
            _readRepositoryMock.Setup(business => business.CountryBusiness).Returns(countryWiseBusinesses.AsQueryable());
            _readRepositoryMock.Setup(revenues => revenues.BusinessRevenue).Returns(businessRevenues.AsQueryable());

            CountryGWPQueryHandler queryHandler = new CountryGWPQueryHandler(_readRepositoryMock.Object);
            var result = queryHandler.Handle(new CountryGWPQuery("ae", new string[] { "transport" }), new CancellationTokenSource().Token);

            Assert.True(result.Result.BusinessesRevenues.Select(item => item.GrossRevenue).Sum() == 268744928.7m);
        }

        [Fact]
        public void CheckBusinessDateFilter()
        {
            Guid aeTransport = Guid.NewGuid();
            List<ICountryWiseBusiness> countryWiseBusinesses = new() {
                new CountryWiseBusinessDTO(){BusinessId = aeTransport,BusinessName = "transport",CountryName = "ae"},
            };
            List<IRevenue> businessRevenues = new(){
                new BusinessRevenueDTO(){BusinessId = aeTransport,Year = 2014,Value = 231441262.7m}, 
                new BusinessRevenueDTO(){BusinessId = new Guid(),Year = 2011,Value = 268744928.7m},// this will be skipped

            };

            Mock<IReadRepository> _readRepositoryMock = new();
            _readRepositoryMock.Setup(business => business.CountryBusiness).Returns(countryWiseBusinesses.AsQueryable());
            _readRepositoryMock.Setup(revenues => revenues.BusinessRevenue).Returns(businessRevenues.AsQueryable());

            CountryGWPQueryHandler queryHandler = new CountryGWPQueryHandler(_readRepositoryMock.Object);
            var result = queryHandler.Handle(new CountryGWPQuery("ae", new string[] { "transport" }), new CancellationTokenSource().Token);

            Assert.True(result.Result.BusinessesRevenues.Select(item => item.GrossRevenue).Sum() == 231441262.7m);
        }
    }
}