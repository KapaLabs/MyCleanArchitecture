using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Self.CleanArchitecture.Usecase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Microsoft.Extensions.Primitives;


namespace Self.CleanArchitecture.Persistence
{
    /// <summary>
    /// Reporesents CSV file data store and parser.
    /// Repository is responsible for mapping to DTO / Anti-corruption layer between real persistence and Iterface needed by applicaiton
    /// </summary>
    public class CSVFileDataStore : IReadRepository
    {
        private const int BusinessOffset = 4;
        private const int StartingYear = 2000;//Assuming data starts from 2000. Better to read from 0th file of header/config. Avoid coupling with file format/values.

        private List<CountryWiseBusinessDTO> _businessRecords = new List<CountryWiseBusinessDTO>();
        private List<BusinessRevenueDTO> _revenueRecords = new List<BusinessRevenueDTO>();

        public CSVFileDataStore(IConfiguration configuration)
        {
            string fileLocation = configuration["CSVFileLocaiton"];
            SeedDataFromFile(fileLocation!);
        }
        private void SeedDataFromFile(string fileLocation)
        {   
            string[] rows = File.ReadAllLines(fileLocation);
            for (int row = 1; row < rows.Length; row++) // skip header
            {
                string[] fields = rows[row].Split(',');

                //create business record
                CountryWiseBusinessDTO countryWiseBusinessDTO = new()
                    {
                    BusinessName = fields[3],
                    CountryName = fields[0],
                    BusinessId = Guid.NewGuid()
                };
                _businessRecords.Add(countryWiseBusinessDTO);

                //Traverse all revenue years
                for (int field = BusinessOffset; field < fields.Length; field++)
                {
                    if (string.IsNullOrEmpty(fields[field]))
                    {
                        continue;// no value for this year
                    }
                    else if (!(decimal.TryParse(fields[field], out _)))
                    {
                        //inform the datasource is corrupted. 
                        //Log the error and continue to next record.
                        continue;
                    }
                    else
                    {
                        BusinessRevenueDTO businessRevenueDTO = new()
                        {
                            ReveneId = Guid.NewGuid(),
                            BusinessId = countryWiseBusinessDTO.BusinessId,
                            Year = StartingYear + field - BusinessOffset,
                            Value = decimal.Parse(fields[field])
                        };
                        _revenueRecords.Add(businessRevenueDTO);
                    }                   
                }
            }
        }
        
        //Taking liberty to have same contract.
        //Repository is responsible for mapping to DTO / Anti-corruption layer between real persistence and Iterface needed by applicaiton
        public IQueryable<ICountryWiseBusiness> CountryBusiness { get => _businessRecords.AsQueryable(); }
        public IQueryable<IRevenue> BusinessRevenue { get => _revenueRecords.AsQueryable(); }

    }
}
