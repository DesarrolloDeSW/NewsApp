using AutoMapper;
using NewsApp.Listas;
using NewsApp.Noticias;
using NewsApp.Usuarios;
using NewsApp.Alertas;
using NewsApp.UltimasVisitas;

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
        CreateMap<Alerta, AlertaDto>();
        CreateMap<Notificacion, NotificacionDto>()
            .ForMember(dest => dest.UsuarioDestinatarioId, opt => opt.MapFrom(src => src.UsuarioDestinatario.Id));
        CreateMap<Usuario, UsuarioDto>();
        CreateMap<UltimaVisita, UltimaVisitaDto>();

    }
}
