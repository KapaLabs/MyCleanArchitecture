using MediatR;
using Microsoft.AspNetCore.Mvc;
using Self.CleanArchitecture.Usecase;
using Self.CleanArchitecture.Web.Controllers.Contributors;
using System.Linq;

namespace MyCleanArchitecture.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryGwpController(ILogger<CountryGwpController> logger, IMediator mediator) : ControllerBase
    {

        private readonly ILogger<CountryGwpController> _logger = logger;
        private readonly IMediator _mediator = mediator;


        [HttpPost(Name = "CountryGwp")]
        public (string Business, decimal GrossRevenue)[] Create(GetCountryGwpRequest createContributorRequest)
        {
            var result = _mediator.Send(new CountryGWPQuery(createContributorRequest.country, createContributorRequest.lob));
            result.Wait();

            var response = new GetCountryGwpResponse(result.Result.BusinessesRevenues.Select(x => (x.Business, x.GrossRevenue)).ToArray());

            // result to response pending
            var a = result.Result.BusinessesRevenues.Select(x => (x.Business, x.GrossRevenue)).ToArray();
            return a;
        }
    }
}
