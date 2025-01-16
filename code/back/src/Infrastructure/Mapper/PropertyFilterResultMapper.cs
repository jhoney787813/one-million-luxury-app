using Domain.Entities;
using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper
{
    public static class PropertyFilterResultMapper
    {
        public static IEnumerable<PropertyFilterResultEntity> MapModelToEntity(IEnumerable<PropertyFilterResultModel> result)
        {
            return result.Select(model => new PropertyFilterResultEntity
            {
                IdOwner = model.IdOwner,
                OwnerName = model.OwnerName,
                PropertyName = model.PropertyName,
                PropertyAddress = model.PropertyAddress,
                Price = model.Price,
                ImageUrl = model.ImageUrl
            });
        }

        public static IEnumerable<PropertyFilterResultModel> MapToEntityToModel(IEnumerable<PropertyFilterResultEntity> result)
        {
            return result.Select(entity => new PropertyFilterResultModel(
                                                    entity.IdOwner,
                                                    entity.OwnerName,
                                                    entity.PropertyName,
                                                    entity.PropertyAddress,
                                                    entity.Price,
                                                    entity.ImageUrl)
           );
        }

    }
}
