using System.ComponentModel.DataAnnotations;

namespace Self.CleanArchitecture.Web.Controllers.Contributors
{
    public record GetCountryGwpResponse((string Business, decimal GrossRevenue)[] usinessesRevenue)
    {
        public (string Business, decimal GrossRevenue)[] BusinessesRevenue { get; set; }

    }



}
