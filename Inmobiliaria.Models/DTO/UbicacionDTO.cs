using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria.Models.DTO
{
    public class UbicacionDTO
    {
        public string Ciudad { get; set; } = null!;
        public string Direccion { get; set; } = null!;

        public UbicacionDTO()
        {
            
        }

        public UbicacionDTO(string ciudad, string direccion) : base()
        {
            this.Ciudad = ciudad;
            this.Direccion = direccion; 
        }
    }
}
