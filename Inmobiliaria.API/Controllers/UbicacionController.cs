using AutoMapper;
using Inmobiliaria.Models;
using Inmobiliaria.Models.DTO;
using Inmobiliaria.Negocio.UOW;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UbicacionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var lista = _unitOfWork.Ubicacion.GetAll();
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
        public IActionResult Insert([FromForm]UbicacionDTO dto)
        {
            try
            {
                var ubicacion = _unitOfWork.Ubicacion.GetByCondition(a => a.Ciudad.ToLower().Trim().Equals(dto.Ciudad.ToLower().Trim()));
                if (ubicacion != null)
                    return StatusCode(StatusCodes.Status400BadRequest, "Ya existe la ubicación ingresada.");

                return (_unitOfWork.Ubicacion.Insert(_mapper.Map<Ubicacion>(dto)))
                    ? StatusCode(StatusCodes.Status200OK, "Se insertó correctamente.")
                    : StatusCode(StatusCodes.Status400BadRequest, "No se pudo insertar la ubicación.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
