using Application.Commons;
using Application.Users.Command.Create;
using Domain.Entities;
using Domain.Interfaces.UseCases;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.OwnerProperty.GetFilteredProperty
{
    public class GetTopPropertyQueryHandler : IRequestHandler<GetTopPropertyQuery, Result<IEnumerable<GetTopPropertyQueryResponse>>>
    {
        private readonly IGetTopPropertyUseCase _getTopPropertyUseCase;
        public GetTopPropertyQueryHandler(IGetTopPropertyUseCase getTopPropertyUseCase)
        {
            _getTopPropertyUseCase = getTopPropertyUseCase;
        }

        public async Task<Result<IEnumerable<GetTopPropertyQueryResponse>>> Handle(GetTopPropertyQuery request, CancellationToken cancellationToken)
        {
             var result = await _getTopPropertyUseCase.Execute(request.Top);
             var response = MapToResponse(result);

            if (response is not null && response.Count>0)
                return Result<IEnumerable<GetTopPropertyQueryResponse>>.Success(response);
            else
                return Result<IEnumerable<GetTopPropertyQueryResponse>>.Failure("");
        }

        private List<GetTopPropertyQueryResponse> MapToResponse(IEnumerable<PropertyFilterResultEntity> result)
        {
            List<GetTopPropertyQueryResponse> response = new();
            if (result is not null && result.Count() > 0)
            {
                foreach (var item in result)
                    response.Add(MapEntityToResponse(item));
            }
            return response;

        }

        private GetTopPropertyQueryResponse MapEntityToResponse(PropertyFilterResultEntity propertyResult)
        {
            return new GetTopPropertyQueryResponse(propertyResult.IdOwner, propertyResult.OwnerName, propertyResult.PropertyName, propertyResult.PropertyAddress, propertyResult.Price, propertyResult.ImageUrl);
        }
    }
}

