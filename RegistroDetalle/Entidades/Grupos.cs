using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RegistroDetalle.Entidades
{
    public class Grupos
    {
        [Key]
        public int GrupoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int grupos { get; set; }
        public int Integrantes { get; set; }

        [StringLength(100)]
        public string Comentarios { get; set; }

        public virtual ICollection<GruposDetalle> Detalle { get; set; }

        public Grupos()
        {
            this.Detalle = new List<GruposDetalle>();
        }
        public void AgregarDetalle(int Id,int GrupoId,int PersonaId,int Cargo,int Cantidad)
        {
            this.Detalle.Add(new GruposDetalle(Id,GrupoId,PersonaId,Cargo,Cantidad));
        }

    }
}
