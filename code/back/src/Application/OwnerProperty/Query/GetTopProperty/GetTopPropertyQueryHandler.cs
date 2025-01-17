using Application.Commons;
using Domain.Entities;
using Domain.Interfaces.UseCases;
using MediatR;
using System.Text;
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
            StringBuilder errors;
            if (ModelIsValid(request, out errors))
            {
                var result = await _getTopPropertyUseCase.Execute(request.Top);
                var response = MapToResponse(result);
                return Result<IEnumerable<GetTopPropertyQueryResponse>>.Success(response);
            }
            return Result<IEnumerable<GetTopPropertyQueryResponse>>.Failure(errors.ToString());
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

        #region Private method
        private bool ModelIsValid(GetTopPropertyQuery propertyFilterRequest, out StringBuilder errors)
        {
            errors = new StringBuilder();

            if (!(propertyFilterRequest is not null))
            {
                errors.Append("The property filter request cannot be null.\n");
                return false;
            }

            if (propertyFilterRequest.Top < 0)
                errors.Append("The Top must be a positive value.\n");

            return errors.Length == 0;
        }
        #endregion
    }
}

