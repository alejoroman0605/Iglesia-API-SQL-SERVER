using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.ModelsConfigurations
{
    internal class ParticipacionDBConfig
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad
            BaseDBConfiguracion<Participacion>.SetEntityBuilder(modelBuilder);
            modelBuilder.Entity<Participacion>(entity =>
            {
                entity.HasIndex(e => new { e.NinoID , e.ActividadID}).IsUnique();
            });
            
            

            modelBuilder.Entity<Participacion>().HasOne(t => t.PersonaMayor).WithMany(t => t.Participaciones)
                .HasForeignKey(t => t.PersonaMayorID).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            #endregion

        }
    }
}
