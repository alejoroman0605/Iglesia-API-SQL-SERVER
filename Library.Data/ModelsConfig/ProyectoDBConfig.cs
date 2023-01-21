using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.ModelsConfigurations
{
    internal class ProyectoDBConfig
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad
            BaseDBConfiguracion<Proyecto>.SetEntityBuilder(modelBuilder);
           
            modelBuilder.Entity<Proyecto>().HasOne(t => t.Coordinador).WithMany(t => t.CoordinadorProyectos)
               .HasForeignKey(t => t.CoordinadorID).Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Proyecto>().HasOne(t => t.Administrador).WithMany(t => t.AdminProyectos)
                .HasForeignKey(t => t.AdministradorID).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            #endregion

        }
    }
}
