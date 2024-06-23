using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self.CleanArchitecture.Usecase
{
    public interface ICountryGwp
    {
        public string CountryName { get; set; }
        public string VariableId { get; set; }
        public string BusinessName { get; set; }
        public int Year { get; set; }
        public float Value { get; set; }
    }
}
