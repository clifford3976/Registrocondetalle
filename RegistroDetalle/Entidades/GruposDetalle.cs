using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace RegistroDetalle.Entidades
{
    public class GruposDetalle
    {
        [Key]
        public int Id { get; set; }
        public int GrupoId { get; set; }
        public int PersonaId { get; set; }
        public int Cargo { get; set; }

        [ForeignKey("PersonaId")]

        public virtual Personas Persona { get; set; }
        public int Cantidad { get; set; }

        public GruposDetalle()
        {
            this.Id = 0;
            this.GrupoId = 0;
            this.Cargo = 0;
        }

        public GruposDetalle(int id, int GrupoId, int PersonaId,int Cargo, int cantidad)
        {
            this.Id = id;
            this.GrupoId = GrupoId;
            this.PersonaId = PersonaId;
            this.Cargo = Cargo;
            this.Cantidad = cantidad;
        }
    }
}
