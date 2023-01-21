using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.ModelsConfigurations
{
    internal class PersonaDBConfig
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad
            BaseDBConfiguracion<Persona>.SetEntityBuilder(modelBuilder);
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasIndex(e => e.CI).IsUnique();
                entity.Property(p => p.PadreID).IsRequired(false);
            });
            modelBuilder.Entity<Persona>().HasOne(t => t.Madre).WithMany(t => t.HijosDeMadre)
               .HasForeignKey(t => t.MadreID).Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Persona>().HasOne(t => t.Padre).WithMany(t => t.HijosDePadre)
                .HasForeignKey(t => t.PadreID).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            #endregion

        }
    }
}
