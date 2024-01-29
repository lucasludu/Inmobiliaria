using AutoMapper;
using Inmobiliaria.Models.DTO;

namespace Inmobiliaria.Models.Mapper
{
    public class InmoMapp : Profile
    {
        public InmoMapp()
        {
            CreateMap<Propiedad, PropiedadDTO>().ReverseMap();


            CreateMap<Ubicacion, UbicacionDTO>().ReverseMap();
        }
    }
}
