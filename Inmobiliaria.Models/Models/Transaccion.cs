namespace Inmobiliaria.Models
{
    public partial class Transaccion
    {
        public int IdTransaccion { get; set; }
        public int IdUsuario { get; set; }
        public int IdPropiedad { get; set; }
        public int IdTipoTransaccion { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaTransaccion { get; set; }

        public virtual Propiedad IdPropiedadNavigation { get; set; } = null!;
        public virtual TipoTransaccion IdTipoTransaccionNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
