using MediatR;
using Microsoft.AspNetCore.Mvc;
using Self.CleanArchitecture.Usecase;
using Self.CleanArchitecture.Web.Controllers.Contributors;
using System.Linq;

namespace MyCleanArchitecture.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryGwpController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;


        [HttpPost(Name = "CountryGwp")]
        public GetCountryGwpResponse[] Create(GetCountryGwpRequest createContributorRequest)
        {
            var result = _mediator.Send(new CountryGWPQuery(createContributorRequest.country, createContributorRequest.lob));
            result.Wait();
            return result.Result.BusinessesRevenues.Select(x => new GetCountryGwpResponse(x.Business, x.GrossRevenue)).ToArray();
        }
    }
}
