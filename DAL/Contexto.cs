using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P2_AP1_Julio_Cesar.Entidades;

namespace P2_AP1_Julio_Cesar.DAL
{
    public class Contexto : DbContext
    {
        public DbSet <TiposTareas> TiposTareas { get; set; }


        protected override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\Db2Proyectos.db");
        }

        protected override  void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TiposTareas>().HasData
                (new TiposTareas
                {
                    TipoTareaId = 1,
                    Acomulado = 0,
                    DecripcionTipoTarea = "Analisis"
                });

            modelBuilder.Entity<TiposTareas>().HasData
                (new TiposTareas { 
                TipoTareaId = 2,
                Acomulado = 0,
                DecripcionTipoTarea = "Diseño"
                });
            modelBuilder.Entity<TiposTareas>().HasData
                (new TiposTareas {
                TipoTareaId = 3,
                Acomulado = 0,
                DecripcionTipoTarea = "Programacion"
                });

            modelBuilder.Entity<TiposTareas>().HasData
                (new TiposTareas{
                    TipoTareaId = 4,
                    Acomulado = 0,
                    DecripcionTipoTarea = "Prueba"
                });
        }


    }
}
