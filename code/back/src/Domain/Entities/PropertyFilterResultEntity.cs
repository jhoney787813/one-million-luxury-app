using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PropertyFilterResultEntity
    {
           public long IdOwner{set;get;}
           public string OwnerName{set;get;}
           public string PropertyName{set;get;}
           public string PropertyAddress{set;get;}
           public decimal? Price{set;get;}
           public string ImageUrl { set; get; }

    }
}
