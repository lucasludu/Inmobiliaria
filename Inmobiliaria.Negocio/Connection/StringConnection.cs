using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria.Negocio.Connection
{
    public static class StringConnection
    {

        public static IConfiguration Configuration { get; set; }

        /// <summary>
        /// Cadena de conexión tomado desde el appsetings.json 
        /// </summary>
        public static string ConnectionString { get; set;}


        public static string GetConnectionString()
        {
            // Leo el archivo que contiene la cadena de conexión
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            string usarConnectionString = Configuration["StringConnection"];

            ConnectionString = Configuration.GetConnectionString(usarConnectionString);
            return ConnectionString;
        }
    }
}
