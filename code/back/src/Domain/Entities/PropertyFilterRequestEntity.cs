using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PropertyFilterRequestEntity
    {
        public string? Name { set; get; }
        public string? Address { set; get; }
        public decimal? MinPrice { set; get; }
        public decimal? MaxPrice { set; get; }

    }
}
