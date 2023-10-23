using AutoMapper;
using NewsApp.Listas;
using NewsApp.Noticias;
using NewsApp.Usuarios;

namespace NewsApp;

public class NewsAppApplicationAutoMapperProfile : Profile
{
    public NewsAppApplicationAutoMapperProfile()
    {
        CreateMap<Fuente,FuenteDto>();
        CreateMap<Noticia,NoticiaDto>();
        CreateMap<Lista, ListaDto>();
        CreateMap<Pais, PaisDto>();
        CreateMap<Idioma, IdiomaDto>();

    }
}
