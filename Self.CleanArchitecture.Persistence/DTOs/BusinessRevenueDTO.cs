using Self.CleanArchitecture.Usecase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self.CleanArchitecture.Persistence
{
    public class BusinessRevenueDTO : IRevenue
    {
        public Guid ReveneId { get; set; }
        public Guid BusinessId { get; set; }
        public int Year { get; set; }
        public decimal Value { get; set; }
    }
}
