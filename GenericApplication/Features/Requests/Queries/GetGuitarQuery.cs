using GenericAPI.Dtos;
using MediatR;

namespace GenericApplication.Features.Requests.Queries;

public class GetGuitarQuery : IRequest<GuitarDto>
{
    public Guid Id { get; set; }
}