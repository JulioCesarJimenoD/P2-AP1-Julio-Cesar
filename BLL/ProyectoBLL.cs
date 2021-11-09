using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P2_AP1_Julio_Cesar.Entidades;
using P2_AP1_Julio_Cesar.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace P2_AP1_Julio_Cesar.BLL
{
   public class ProyectoBLL
    {
        public static bool Guardar(Proyectos proyecto)
        {
            if (!Existe(proyecto.ProyectoId))//si no existe insertamos
                return Insertar(proyecto);
            else
                return Modificar(proyecto);
        }
        private static bool Insertar(Proyectos proyecto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
               
                contexto.Proyectos.Add(proyecto);

                foreach (var detalle in proyecto.Detalle)
                {
                    contexto.Entry(detalle).State = EntityState.Added;
                    contexto.Entry(detalle.TiposTareas).State = EntityState.Modified;
                    contexto.Entry(detalle.proyecto).State = EntityState.Modified;
                    detalle.TiposTareas.Acomulado += detalle.Tiempo;
                    detalle.proyecto.Total += detalle.Tiempo;
                }

                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        private static bool Modificar(Proyectos proyecto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var proyectoAnterior = contexto.Proyectos
                    .Where(x => x.ProyectoId == proyecto.ProyectoId)
                    .Include(x => x.Detalle)
                    .ThenInclude(x => x.TiposTareas)
                    .AsNoTracking()
                    .SingleOrDefault();


                //busca la entidad en la base de datos y la elimina
                foreach (var detalle in proyectoAnterior.Detalle)
                {
                    detalle.TiposTareas.Acomulado -= detalle.Tiempo;
                    detalle.proyecto.Total -= detalle.Tiempo;
                }

                contexto.Database.ExecuteSqlRaw($"Delete FROM ProyectosDetalle Where Id={proyecto.ProyectoId}");

                foreach (var item in proyecto.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                    contexto.Entry(item.TiposTareas).State = EntityState.Modified;
                    contexto.Entry(item.proyecto).State = EntityState.Modified;
                    item.TiposTareas.Acomulado += item.Tiempo;
                    item.proyecto.Total += item.Tiempo;
                }

                contexto.Entry(proyecto).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static Proyectos Buscar(int id)
        {
            Proyectos proyecto = new Proyectos();
            Contexto contexto = new Contexto();

            try
            {
                proyecto = contexto.Proyectos.Include(x => x.Detalle)
                    .Where(x => x.ProyectoId == id)
                     .Include(x => x.Detalle)
                    .ThenInclude(x => x.TiposTareas)
                    .SingleOrDefault();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return proyecto;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //buscar la entidad que se desea eliminar
                var proyecto = Buscar(id);

                if (proyecto != null)
                {
                    foreach (var item in proyecto.Detalle)
                    {
                        contexto.Entry(item.proyecto).State = EntityState.Modified;
                        contexto.Entry(item.TiposTareas).State = EntityState.Modified;
                        item.TiposTareas.Acomulado -= item.Tiempo;
                        item.proyecto.Total -= item.Tiempo;
                    }
                    contexto.Proyectos.Remove(proyecto);
                    paso = contexto.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static List<Proyectos> GetList(Expression<Func<Proyectos, bool>> criterio)
        {
            List<Proyectos> Lista = new List<Proyectos>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Proyectos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Proyectos.Any(e => e.ProyectoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

    }

}
