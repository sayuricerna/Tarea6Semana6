using Microsoft.EntityFrameworkCore;
using Tarea6Semana6API.Models;

namespace Tarea6Semana6API.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    public class Tarea6Semana6AppContext:DbContext
    {
        public Tarea6Semana6AppContext(DbContextOptions<Tarea6Semana6AppContext> options) : base(options)
        { }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
