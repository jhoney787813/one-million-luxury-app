using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class GetFilteredPropertyUseCase : IGetFilteredPropertyUseCase
    {
        private readonly IMillionDBRepository _millionDBRepository;
        public GetFilteredPropertyUseCase(IMillionDBRepository millionDBRepository)
        {
                _millionDBRepository = millionDBRepository;
        }
        public async Task<IEnumerable<PropertyFilterResultEntity>> GetFilteredPropertiesAsync(PropertyFilterRequestEntity filter)
        {
            var result = await _millionDBRepository.GetFilteredPropertiesAsync(filter);
            return result;
        }
    }
}
