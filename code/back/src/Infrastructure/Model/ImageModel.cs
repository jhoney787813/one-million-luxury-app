using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public record ImageModel(
       long IdImage,
       string FileImage,
       bool Enabled,
       DateTime CreatedAt
   );
}
