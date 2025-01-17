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
    public class GetTopPropertyUseCase : IGetTopPropertyUseCase
    {
        private readonly IMillionDBRepository _millionDBRepository;
        public GetTopPropertyUseCase(IMillionDBRepository millionDBRepository)
        {
                _millionDBRepository = millionDBRepository;
        }
        public async Task<IEnumerable<PropertyFilterResultEntity>> Execute(int top)
        {
            var result = await _millionDBRepository.GetTopPropertiesAsync(top);
            return result;
        }
    }
}
