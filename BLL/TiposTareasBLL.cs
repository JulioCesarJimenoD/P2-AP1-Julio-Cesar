using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P2_AP1_Julio_Cesar.Entidades;
using P2_AP1_Julio_Cesar.DAL;
using System.Linq.Expressions;

namespace P2_AP1_Julio_Cesar.BLL
{
    public class TiposTareasBLL
    {
       public static TiposTareas Buscar(int id)
        {
            TiposTareas tipos;
            Contexto contexto = new Contexto();

            try
            {
                tipos = contexto.TiposTareas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return tipos;
        }

        public static List<TiposTareas>GetTiposTarea()
        {
            List<TiposTareas> lista = new List<TiposTareas>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.TiposTareas.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static List<TiposTareas> GetList(Expression<Func<TiposTareas, bool>> criterio)
        {
            List<TiposTareas> Lista = new List<TiposTareas>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.TiposTareas.Where(criterio).ToList();
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


    }
}
