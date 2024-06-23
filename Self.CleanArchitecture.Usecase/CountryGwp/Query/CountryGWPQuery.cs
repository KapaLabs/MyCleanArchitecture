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
        public IEnumerable<(string Business, decimal GrossRevenue)> BusinessesRevenues { get; set; }

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

            var businesscases = _readRepository.CountryBusinessRevenue.Where(item => item.Year >= request.BeginYear && item.Year <= request.EndYear && item.CountryName == request.Country).Where(item => request.Business.Contains(item.BusinessName));
            CountryGWPResult result = new CountryGWPResult();
            // mapping to result penidng
           return result;
        }
    }
}
