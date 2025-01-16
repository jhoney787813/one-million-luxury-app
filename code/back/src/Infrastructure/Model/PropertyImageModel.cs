using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public record PropertyImageModel(
        long IdPropertyImage,
        long IdProperty,
        DateTime CreatedAt
    );
}
