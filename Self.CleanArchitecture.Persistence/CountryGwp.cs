using Self.CleanArchitecture.Usecase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self.CleanArchitecture.Persistence
{
    public class CountryGwp : ICountryGwp
    {
        public string CountryName { get; set; }
        public string VariableId { get; set; }
        public string BusinessName { get; set; }
        public int Year { get; set; }
        public float Value { get; set; }
    }
}
