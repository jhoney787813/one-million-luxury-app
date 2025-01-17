using Application.Commons;
using Domain.Entities;
using MediatR;

namespace Application.OwnerProperty.GetFilteredProperty
{
    public class GetFilteredPropertyQuery : PropertyFilterRequestEntity, IRequest<Result<IEnumerable<GetFilteredPropertyQueryResponse>>>
    {
       
    }
}