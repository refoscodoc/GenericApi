using GenericAPI.Dtos;
using MediatR;

namespace GenericApplication.Features.Requests.Commands;

public class CreateGuitarCommand : IRequest<GuitarDto>
{
    public GuitarDto CreateGuitarDto { get; set; }
}