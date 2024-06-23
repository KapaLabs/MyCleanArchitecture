using Microsoft.EntityFrameworkCore;
using Self.CleanArchitecture.Usecase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self.CleanArchitecture.Persistence
{
    public class ApplicaitonDbContext : DbContext, IReadRepository
    {
        List<CountryGwp> _hardCodedValues = new List<CountryGwp>();
        public ApplicaitonDbContext()
        {
            //seeding with hardcoded values
            _hardCodedValues.Add(new CountryGwp() { BusinessName = "transport", CountryName = "ae", Value = 446001906.1F, Year = 2014 });
            _hardCodedValues.Add(new CountryGwp() { BusinessName = "liability", CountryName = "ae", Value = 634545022.9F, Year = 2014 });           
        }
        public DbSet<CountryGwp> CountryGwps { get; set; }

        //public IQueryable<ICountryGwp> CountryBusinessRevenue { get => CountryGwps; }
        public IQueryable<ICountryGwp> CountryBusinessRevenue { get => _hardCodedValues.AsQueryable(); }
    }
}
