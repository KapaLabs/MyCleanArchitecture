using Self.CleanArchitecture.Usecase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self.CleanArchitecture.Usecase
{
    public interface IReadRepository
    {
        IQueryable<ICountryGwp> CountryBusinessRevenue { get;}
    }
}
