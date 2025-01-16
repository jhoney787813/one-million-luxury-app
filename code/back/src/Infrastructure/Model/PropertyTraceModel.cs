using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public record PropertyTraceModel(
       long IdPropertyTrace,
       DateTime? DateSale,
       string Name,
       decimal? Value,
       double? Tax,
       long? IdProperty,
       DateTime CreatedAt
   );
}
