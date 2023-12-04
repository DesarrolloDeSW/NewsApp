using AutoMapper;
using NewsApp.Listas;
using NewsApp.Noticias;
using NewsApp.Usuarios;
using NewsApp.Alertas;
using Volo.Abp.Identity;
using NewsApp.Articulos;

namespace NewsApp;

public class NewsAppApplicationAutoMapperProfile : Profile
{
    public NewsAppApplicationAutoMapperProfile()
    {
        CreateMap<Noticia, NoticiaDto>().ReverseMap();
        CreateMap<Lista, ListaDto>();
        CreateMap<Alerta, AlertaDto>();
        CreateMap<Notificacion, NotificacionDto>();
        CreateMap<IdentityUser, UsuarioDto>()
        .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Surname))
        .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.UserName));
        CreateMap<NoticiaDto, ArticuloDto>().ReverseMap()
        .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Title))
        .ForMember(dest => dest.Autor, opt => opt.MapFrom(src => src.Author))
        .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Description))
        .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
        .ForMember(dest => dest.Contenido, opt => opt.MapFrom(src => src.Content))
        .ForMember(dest => dest.FechaPublicacion, opt => opt.MapFrom(src => src.PublishedAt))
        .ForMember(dest => dest.Fuente, opt => opt.MapFrom(src => src.Source));

    }
}
