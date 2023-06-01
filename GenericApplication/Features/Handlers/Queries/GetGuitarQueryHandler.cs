using AutoMapper;
using GenericAPI.Models;
using GenericApplication.Features.Requests.Queries;
using GenericDomain.Models;
using GenericPersistence;
using MediatR;

namespace GenericApplication.Features.Handlers.Queries;

public class GetGuitarQueryHandler : IRequestHandler<GetGuitarQuery, GuitarModel>
{
    private readonly IUnitOfWork _unitOfWork;


    public GetGuitarQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GuitarModel> Handle(GetGuitarQuery request, CancellationToken cancellationToken)
    {
        var guitar = await _unitOfWork.GuitarRepository.Get(request.Id);
        if (guitar is null)
        {
            throw new Exception("We could not find this guitar.");
        }
        return guitar;
    }
}