using AutoMapper;
using Inmobiliaria.Models;
using Inmobiliaria.Models.DTO;
using Inmobiliaria.Negocio.UOW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PropiedadController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var lista = _unitOfWork.Propiedad.GetAll();
                return (lista.Count > 0)
                    ? StatusCode(StatusCodes.Status200OK, lista)
                    : StatusCode(StatusCodes.Status204NoContent, "La lista se encuentra vacia.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Insert([FromForm]PropiedadDTO dto)
        {
            try
            {
                if (dto.IdUbicacion == 0)
                    return StatusCode(StatusCodes.Status400BadRequest, "Debe ingresar una ubicación.");

                if (_unitOfWork.Ubicacion.GetById(dto.IdUbicacion) == null)
                    return StatusCode(StatusCodes.Status400BadRequest, "No existe la ubicación ingresada.");

                return (_unitOfWork.Propiedad.Insert(_mapper.Map<Propiedad>(dto)))
                    ? StatusCode(StatusCodes.Status200OK, "Se insertó correctamente.")
                    : StatusCode(StatusCodes.Status400BadRequest, "No se pudo insertar la propiedad.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
