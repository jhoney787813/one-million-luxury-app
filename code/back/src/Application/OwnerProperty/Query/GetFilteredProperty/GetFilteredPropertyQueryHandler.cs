using Application.Commons;
using Application.Users.Command.Create;
using Domain.Entities;
using Domain.Interfaces.UseCases;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.OwnerProperty.GetFilteredProperty
{
    public class GetFilteredPropertyQueryHandler : IRequestHandler<GetFilteredPropertyQuery, Result<IEnumerable<GetFilteredPropertyQueryResponse>>>
    {
        private readonly IGetFilteredPropertyUseCase _getFilteredPropertyUseCase;
        public GetFilteredPropertyQueryHandler(IGetFilteredPropertyUseCase getFilteredPropertyUseCase)
        {
            _getFilteredPropertyUseCase= getFilteredPropertyUseCase;
        }

        public async Task<Result<IEnumerable<GetFilteredPropertyQueryResponse>>> Handle(GetFilteredPropertyQuery request, CancellationToken cancellationToken)
        {
             var result = await _getFilteredPropertyUseCase.Execute(request);
             var response = MapToResponse(result);

            if (response is not null && response.Count>0)
                return Result<IEnumerable<GetFilteredPropertyQueryResponse>>.Success(response);
            else
                return Result<IEnumerable<GetFilteredPropertyQueryResponse>>.Failure("");
        }

        private List<GetFilteredPropertyQueryResponse> MapToResponse(IEnumerable<PropertyFilterResultEntity> result)
        {
            List<GetFilteredPropertyQueryResponse> response = new();
            if (result is not null && result.Count() > 0)
            {
                foreach (var item in result)
                    response.Add(MapEntityToResponse(item));
            }
            return response;

        }

        private GetFilteredPropertyQueryResponse MapEntityToResponse(PropertyFilterResultEntity propertyResult)
        {
            return new GetFilteredPropertyQueryResponse(propertyResult.IdOwner, propertyResult.OwnerName, propertyResult.PropertyName, propertyResult.PropertyAddress, propertyResult.Price, propertyResult.ImageUrl);
        }
    }
}

