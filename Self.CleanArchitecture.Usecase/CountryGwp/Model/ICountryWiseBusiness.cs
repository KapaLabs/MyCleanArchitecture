using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self.CleanArchitecture.Usecase
{
    public interface ICountryWiseBusiness
    {
        public string CountryName { get; set; }
        public string BusinessName { get; set; } 
        public Guid BusinessId { get; set; }
    }   
}
