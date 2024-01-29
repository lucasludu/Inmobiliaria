namespace Inmobiliaria.Models
{
    public partial class TipoPropiedad
    {
        public TipoPropiedad()
        {
            Propiedads = new HashSet<Propiedad>();
        }

        public int IdTipoPropiedad { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Propiedad> Propiedads { get; set; }
    }
}
