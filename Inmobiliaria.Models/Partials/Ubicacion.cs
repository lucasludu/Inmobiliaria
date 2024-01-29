namespace Inmobiliaria.Models
{
    public partial class Ubicacion
    {
        public Ubicacion(int idubicacion, string ciudad, string direccion) : base()
        {
            this.IdUbicacion = idubicacion;
            this.Ciudad = ciudad;
            this.Direccion = direccion;
        }
    }
}
