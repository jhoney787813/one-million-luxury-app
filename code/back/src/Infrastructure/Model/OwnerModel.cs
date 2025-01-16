using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public record OwnerModel(
         long IdOwner,
         string Name,
         string Address,
         string Photo,
         DateTime CreatedAt,
         DateTime? Birthday
     );
}
