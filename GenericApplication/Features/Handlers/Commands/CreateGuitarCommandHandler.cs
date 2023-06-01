using AutoMapper;
using GenericAPI.Dtos;
using GenericAPI.Models;
using GenericApplication.Features.Requests.Commands;
using GenericDomain.Models;
using GenericPersistence;
using MediatR;

namespace GenericApplication.Features.Handlers.Commands;

public class CreateGuitarCommandHandler : IRequestHandler<CreateGuitarCommand, GuitarModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public CreateGuitarCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<GuitarModel> Handle(CreateGuitarCommand request, CancellationToken cancellationToken)
    {
        var response = new GuitarModel();

        if (request.CreateGuitarDto is not null)
        {
            response = _mapper.Map<GuitarModel>(request.CreateGuitarDto);
            response.IsActive = true;
            await _unitOfWork.GuitarRepository.Add(response);
            await _unitOfWork.Save();
        }
        
        return response;
    }
}