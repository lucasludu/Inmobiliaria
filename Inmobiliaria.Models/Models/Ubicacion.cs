namespace Inmobiliaria.Models
{
    public partial class Ubicacion
    {
        public Ubicacion()
        {
            Propiedads = new HashSet<Propiedad>();
        }

        public int IdUbicacion { get; set; }
        public string Ciudad { get; set; } = null!;
        public string Direccion { get; set; } = null!;

        public virtual ICollection<Propiedad> Propiedads { get; set; }
    }
}
