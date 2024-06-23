using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self.CleanArchitecture.Usecase
{    
    public record CountryGWPQuery(string country, IEnumerable<string> business) : IRequest<CountryGWPResult>
    {
        public string Country { get; init; } = country;
        public IEnumerable<string> Business { get; init; } = business;
        public int BeginYear { get; set; } = 2008;
        public int EndYear { get; set; } = 2015;
    }
    
    public record CountryGWPResult
    {
        public List<(string Business, decimal GrossRevenue)> BusinessesRevenues { get; } = new();
    }

    public class CountryGWPQueryHandler : IRequestHandler<CountryGWPQuery, CountryGWPResult>
    {
         private readonly IReadRepository _readRepository;

        public CountryGWPQueryHandler(IReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<CountryGWPResult> Handle(CountryGWPQuery request, CancellationToken cancellationToken)
        {
            if (request.BeginYear > request.EndYear)
                throw new DataMisalignedException("Time period incorrect for request");

            CountryGWPResult result = new CountryGWPResult();
            var businesses = _readRepository.CountryBusiness.Where(item => item.CountryName.Trim() == request.Country && request.Business.Contains(item.BusinessName.Trim()));
            foreach (var business in businesses)
            {
                decimal businessAverageRevenue = _readRepository.BusinessRevenue.Where(item => item.BusinessId == business.BusinessId && item.Year >= request.BeginYear && item.Year <= request.EndYear).Average(item => item.Value);
                result.BusinessesRevenues.Add(new (business.BusinessName, businessAverageRevenue));
            }            
           return result;
        }
    }
}
