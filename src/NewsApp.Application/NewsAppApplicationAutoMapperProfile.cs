using AutoMapper;
using NewsApp.Noticias;

namespace NewsApp;

public class NewsAppApplicationAutoMapperProfile : Profile
{
    public NewsAppApplicationAutoMapperProfile()
    {
        CreateMap<Fuente,FuenteDto>();
        CreateMap<Noticia,NoticiaDto>();

    }
}
