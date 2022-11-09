using AutoMapper;
using GenericAPI.Dtos;
using GenericAPI.Models;
using GenericApplication.Features.Requests.Queries;
using GenericPersistence;
using MediatR;

namespace GenericApplication.Features.Handlers.Queries;

public class GetGuitarQueryHandler : IRequestHandler<GetGuitarQuery, GuitarDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public GetGuitarQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<GuitarDto> Handle(GetGuitarQuery request, CancellationToken cancellationToken)
    {
        var guitar = await _unitOfWork.GuitarRepository.Get(request.Id);
        if (guitar is null)
        {
            throw new Exception("We could not find this guitar.");
        }

        var guitarDetails = _mapper.Map<GuitarDto>(guitar);
        return guitarDetails;
    }
}