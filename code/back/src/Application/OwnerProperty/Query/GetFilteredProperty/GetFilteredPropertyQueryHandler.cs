using Application.Commons;
using Application.Users.Command.Create;
using Domain.Entities;
using Domain.Interfaces.UseCases;
using MediatR;
using System.Text;
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
            StringBuilder errors; 
            if (ModelIsValid(request, out errors))
                return Result<IEnumerable<GetFilteredPropertyQueryResponse>>.Success(response);
            else
                return Result<IEnumerable<GetFilteredPropertyQueryResponse>>.Failure(errors.ToString());
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

        #region Private Methods
        private bool ModelIsValid(PropertyFilterRequestEntity propertyFilterRequest, out StringBuilder errors)
        {
            errors = new StringBuilder();

            if (!(propertyFilterRequest is not null))
            {
                errors.Append("The property filter request cannot be null.\n");
                return false;
            }

            if (!string.IsNullOrEmpty(propertyFilterRequest.Name) && propertyFilterRequest.Name.Length > 300)
                errors.Append("The property name cannot exceed 3000 characters.\n");

            if (!string.IsNullOrEmpty(propertyFilterRequest.Address) && propertyFilterRequest.Address.Length > 400)
                errors.Append("The property address cannot exceed 400 characters.\n");

            if (propertyFilterRequest.MinPrice.HasValue && propertyFilterRequest.MinPrice.Value < 0)
                errors.Append("The minimum price must be a positive value.\n");

            if (propertyFilterRequest.MaxPrice.HasValue && propertyFilterRequest.MaxPrice.Value < 0)
                errors.Append("The maximum price must be a positive value.\n");

            if (propertyFilterRequest.MinPrice.HasValue && propertyFilterRequest.MaxPrice.HasValue &&
                propertyFilterRequest.MinPrice.Value > propertyFilterRequest.MaxPrice.Value)
            {
                errors.Append("The minimum price cannot be greater than the maximum price.\n");
            }

            return errors.Length == 0;
        }
        #endregion
    }
}

