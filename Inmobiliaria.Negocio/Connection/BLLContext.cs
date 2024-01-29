using Inmobiliaria.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria.Negocio.Connection
{
    public class BLLContext : IDisposable
    {
        protected Context _context;


        public BLLContext()
        {
            StringConnection.GetConnectionString();
            this._context = new Context(StringConnection.ConnectionString);
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}
