namespace Inmobiliaria.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Propiedads = new HashSet<Propiedad>();
        }

        public int IdEstado { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Propiedad> Propiedads { get; set; }
    }
}
