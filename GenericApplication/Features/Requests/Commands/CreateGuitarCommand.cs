using GenericAPI.Dtos;
using GenericAPI.Models;
using GenericDomain.Models;
using MediatR;

namespace GenericApplication.Features.Requests.Commands;

public class CreateGuitarCommand : IRequest<GuitarModel>
{
    public GuitarDto CreateGuitarDto { get; set; }
}