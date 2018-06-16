using RegistroDetalle.DAL;
using RegistroDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroDetalle.BLL
{
   public class GruposBLL
    {

        public static bool Guardar(Grupos Grupo)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Grupo.Add(Grupo) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Grupos Grupo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                
                foreach (var item in Grupo.Detalle)
                {
                    
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }

                
                contexto.Entry(Grupo).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

       
        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Grupos Grupo = contexto.Grupo.Find(id);

                contexto.Grupo.Remove(Grupo);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static Grupos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Grupos Grupo = new Grupos();
            try
            {
                Grupo = contexto.Grupo.Find(id);

                Grupo.Detalle.Count();

               
                foreach (var item in Grupo.Detalle)
                {
                    
                    string s = item.Persona.Nombres;
                }

                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return Grupo;
        }

        public static List<Grupos> GetList(Expression<Func<Grupos, bool>> expression)
        {
            List<Grupos> Grupo = new List<Grupos>();
            Contexto contexto = new Contexto();
            try
            {
                Grupo = contexto.Grupo.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return Grupo;
        }
    }
}