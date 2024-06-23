using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self.CleanArchitecture.Usecase
{
    public interface IRevenue
    {
        public Guid ReveneId { get; set; }
        public Guid BusinessId { get; set; }
        public int Year { get; set; }
        public decimal Value { get; set; }
    }
}
