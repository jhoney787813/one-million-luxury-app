using Application.Commons;
using Domain.Entities;
using MediatR;

namespace Application.OwnerProperty.GetFilteredProperty
{
    public class GetTopPropertyQuery : IRequest<Result<IEnumerable<GetTopPropertyQueryResponse>>>
    {
        public GetTopPropertyQuery( int top)
        {
            Top = top;
        }
        public int Top{ get; set; }
    }
}