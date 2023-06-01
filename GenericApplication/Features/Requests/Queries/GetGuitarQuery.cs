using GenericAPI.Models;
using GenericDomain.Models;
using MediatR;

namespace GenericApplication.Features.Requests.Queries;

public class GetGuitarQuery : IRequest<GuitarModel>
{
    public Guid Id { get; set; }
}