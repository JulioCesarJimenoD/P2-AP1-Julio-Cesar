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
        public static bool Guardar (Proyectos proyectos)
        {
            if (!Existe(proyectos.ProyectoId))
                return Insertar(proyectos);
            else
                return Modificar(proyectos);
        }

        public static bool Existe (int id)
        {
            Contexto contexto = new Contexto();
            bool encotrado = false;

            try
            {
                encotrado = contexto.Proyectos.Any(e => e.ProyectoId == id);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                contexto.Dispose();
            }
            return encotrado;
        }

        private static bool Insertar (Proyectos proyectos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Proyectos.Add(proyectos);

                foreach (var detalle in proyectos.Detalle)
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

        private static bool Modificar(Proyectos proyectos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var ProyectoAnte = contexto.Proyectos
                    .Where(x => x.ProyectoId == proyectos.ProyectoId)
                    .Include(x => x.Detalle)
                    .ThenInclude(x => x.TiposTareas)
                    .AsNoTracking()
                    .SingleOrDefault();

                foreach (var detalle in ProyectoAnte.Detalle)
                {
                    detalle.TiposTareas.Acomulado -= detalle.Tiempo;
                    detalle.proyecto.Total -= detalle.Tiempo;
                }
                contexto.Database.ExecuteSqlRaw($"Delete FROM ProyectosDetalles Where Id={proyectos.ProyectoId}");

                foreach (var item in proyectos.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                    contexto.Entry(item.TiposTareas).State = EntityState.Modified;
                    contexto.Entry(item.proyecto).State = EntityState.Modified;
                    item.TiposTareas.Acomulado += item.Tiempo;
                    item.proyecto.Total += item.Tiempo;
                }
                contexto.Entry(proyectos).State = EntityState.Modified;
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
            Proyectos proyectos = new Proyectos();
            Contexto contexto = new Contexto();

            try
            {
                proyectos = contexto.Proyectos.Include(x => x.Detalle)
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
            return proyectos;
        }
    
        public static bool Eliminar (int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
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
            List<Proyectos> Lis = new List<Proyectos>();
            Contexto contexto = new Contexto();

            try
            {
                Lis = contexto.Proyectos.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
        }


    }

}
