using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public record PropertyModel(
       long IdProperty,
       string Name,
       string Address,
       decimal? Price,
       DateTime CreatedAt,
       string CodeInternal,
       short? Year,
       long IdOwner
   );
}
