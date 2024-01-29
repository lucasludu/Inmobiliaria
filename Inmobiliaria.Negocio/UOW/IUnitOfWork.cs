using Inmobiliaria.Negocio.Repos.Interfaces;

namespace Inmobiliaria.Negocio.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IPropiedadNegocio Propiedad { get; }
        IUbicacionNegocio Ubicacion { get; }
    }
}
