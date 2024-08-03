namespace SharedModels;
using AutoMapper;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Cliente, ClienteDto>().ReverseMap();
        CreateMap<Contato, ContatoDto>().ReverseMap();
    }
}