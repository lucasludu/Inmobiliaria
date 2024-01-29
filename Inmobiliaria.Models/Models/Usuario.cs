namespace Inmobiliaria.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Transaccions = new HashSet<Transaccion>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Pass { get; set; } = null!;
        public int IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; } = null!;
        public virtual ICollection<Transaccion> Transaccions { get; set; }
    }
}
