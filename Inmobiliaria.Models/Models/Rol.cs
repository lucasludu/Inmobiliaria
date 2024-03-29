﻿namespace Inmobiliaria.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdRol { get; set; }
        public string RolName { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
