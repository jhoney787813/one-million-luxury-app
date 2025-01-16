using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
       public record PropertyFilterResultModel(
        long IdOwner,
        string OwnerName,
        string PropertyName,
        string PropertyAddress,
        decimal? Price,
        string ImageUrl
    );
}
