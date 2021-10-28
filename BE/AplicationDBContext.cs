using BE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE
{
    public class AplicationDBContext: DbContext
    {
        public DbSet<Comentario> Comentario { get; set; }

        public AplicationDBContext(DbContextOptions<AplicationDBContext> options): base(options) { }

    }
}
