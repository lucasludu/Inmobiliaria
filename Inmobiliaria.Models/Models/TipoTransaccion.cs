namespace Inmobiliaria.Models
{
    public partial class TipoTransaccion
    {
        public TipoTransaccion()
        {
            Transaccions = new HashSet<Transaccion>();
        }

        public int IdTipoTransaccion { get; set; }
        public string? Tipo { get; set; }

        public virtual ICollection<Transaccion> Transaccions { get; set; }
    }
}
