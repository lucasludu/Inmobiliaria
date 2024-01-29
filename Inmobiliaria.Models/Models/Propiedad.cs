namespace Inmobiliaria.Models
{
    public partial class Propiedad
    {
        public Propiedad()
        {
            Transaccions = new HashSet<Transaccion>();
        }

        public int IdPropiedad { get; set; }
        public int IdUbicacion { get; set; }
        public int IdTipoPropiedad { get; set; }
        public int IdEstado { get; set; }
        public decimal Precio { get; set; }
        public string? Imagen { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public virtual Estado IdEstadoNavigation { get; set; } = null!;
        public virtual TipoPropiedad IdTipoPropiedadNavigation { get; set; } = null!;
        public virtual Ubicacion IdUbicacionNavigation { get; set; } = null!;
        public virtual ICollection<Transaccion> Transaccions { get; set; }
    }
}
