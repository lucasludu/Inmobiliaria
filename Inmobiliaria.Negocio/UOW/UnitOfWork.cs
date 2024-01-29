using Inmobiliaria.Negocio.Repos;
using Inmobiliaria.Negocio.Repos.Interfaces;

namespace Inmobiliaria.Negocio.UOW
{
    public class UnitOfWork : IUnitOfWork
    {

        #region Propiedad Privada

        private IPropiedadNegocio? propiedad;
        private IUbicacionNegocio? ubicacion;

        #endregion

        #region Constructor
        
        public UnitOfWork()
        {

        }

        #endregion


        #region Propiedad Publica

        public IPropiedadNegocio Propiedad
        {
            get
            {
                return propiedad ?? (propiedad = new PropiedadNegocio());
            }
        }
        
        public IUbicacionNegocio Ubicacion
        {
            get
            {
                return ubicacion ?? (ubicacion = new UbicacionNegocio());
            }
        }

        #endregion

        public void Dispose()
        {

        }
    }
}
