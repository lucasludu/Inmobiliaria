namespace Inmobiliaria.Models.DTO
{
    public class PropiedadDTO
    {
        public int IdUbicacion { get; set; }
        public int IdTipoPropiedad { get; set; }
        public int IdEstado { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }

        public PropiedadDTO()
        {
            
        }

        public PropiedadDTO(int idUbicacion, int idtipopropiedad, int idestado, decimal precio, string imagen, string descripcion) : base()
        {
            this.IdUbicacion = idUbicacion;
            this.IdTipoPropiedad = idtipopropiedad;
            this.IdEstado = idestado;
            this.Precio = precio;
            this.Imagen = imagen;
            this.Descripcion = descripcion;
        }
    }
}
