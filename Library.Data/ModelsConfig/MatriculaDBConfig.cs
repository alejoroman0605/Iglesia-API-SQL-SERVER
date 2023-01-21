using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.ModelsConfigurations
{
    internal class MatriculaDBConfig
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad
            BaseDBConfiguracion<Matricula>.SetEntityBuilder(modelBuilder);
            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasIndex(e => new { e.NinoID , e.ProyectoID}).IsUnique();
            });
            modelBuilder.Entity<Matricula>().HasOne(t => t.Responsable).WithMany(t => t.Matriculas)
                .HasForeignKey(t => t.ResponsableID).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            #endregion

        }
    }
}
