using RegistroDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace RegistroDetalle.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Grupos> Grupo { get; set; }

        public DbSet<Personas> Personas { get; set; }

        public Contexto() : base("ConStr")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
