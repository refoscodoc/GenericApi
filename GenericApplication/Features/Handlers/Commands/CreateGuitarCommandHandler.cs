using AutoMapper;
using GenericAPI.Dtos;
using GenericAPI.Models;
using GenericApplication.Features.Requests.Commands;
using GenericPersistence;
using MediatR;

namespace GenericApplication.Features.Handlers.Commands;

public class CreateGuitarCommandHandler : IRequestHandler<CreateGuitarCommand, GuitarDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public CreateGuitarCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<GuitarDto> Handle(CreateGuitarCommand request, CancellationToken cancellationToken)
    {
        var response = new GuitarDto();

        if (request.CreateGuitarDto is not null)
        {
            var guitar = _mapper.Map<GuitarModel>(request.CreateGuitarDto);
            guitar.IsActive = true;
            await _unitOfWork.GuitarRepository.Add(guitar);
            await _unitOfWork.Save();
        }
        
        return response;
    }
}