using Microsoft.EntityFrameworkCore;
using Self.CleanArchitecture.Usecase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self.CleanArchitecture.Persistence
{
    /// <summary>
    /// Repository is responsible for mapping to DTO / Anti-corruption layer between real persistence and Iterface needed by applicaiton
    /// </summary>
    public class ApplicaitonDbContext : DbContext, IReadRepository
    {
        public ApplicaitonDbContext()
        {                       
        }
        public IQueryable<ICountryWiseBusiness> CountryBusiness { get => throw new NotImplementedException("File DB supported"); }
        public IQueryable<IRevenue> BusinessRevenue { get => throw new NotImplementedException("File DB supported"); }
    }
}
