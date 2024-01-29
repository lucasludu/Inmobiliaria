namespace Inmobiliaria.Models
{
    public partial class Propiedad
    {
        public Propiedad(int idpropiedad, int idubicacion, int idtipopropiedad, int idestado, decimal precio, string imagen, string descripcion) : base()
        {
            this.IdPropiedad = idpropiedad;
            this.IdUbicacion = idubicacion;
            this.IdTipoPropiedad = idtipopropiedad;
            this.IdEstado = idestado;
            this.Precio = precio;
            this.Imagen = imagen;
            this.Descripcion = descripcion;
            this.FechaCreacion = DateTime.Now;
        }
    }
}
