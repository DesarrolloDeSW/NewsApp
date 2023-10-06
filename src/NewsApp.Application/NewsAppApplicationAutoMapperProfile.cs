using AutoMapper;
using NewsApp.Listas;
using NewsApp.Noticias;

namespace NewsApp;

public class NewsAppApplicationAutoMapperProfile : Profile
{
    public NewsAppApplicationAutoMapperProfile()
    {
        CreateMap<Fuente,FuenteDto>();
        CreateMap<Noticia,NoticiaDto>();
        CreateMap<Etiqueta, EtiquetaDto>();
        CreateMap<Lista, ListaDto>();

    }
}
