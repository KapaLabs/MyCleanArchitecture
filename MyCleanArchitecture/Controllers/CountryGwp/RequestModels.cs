using System.ComponentModel.DataAnnotations;

namespace Self.CleanArchitecture.Web.Controllers.Contributors
{
    public class GetCountryGwpRequest
    {       
        [Required]
        public string? country { get; set; }

        [Required]
        public string[]? lob { get; set; }
    }
}
