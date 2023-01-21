using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.ModelsConfigurations
{
    internal class TipoActividadDBConfig
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad
            BaseDBConfiguracion<TipoActividad>.SetEntityBuilder(modelBuilder);
            modelBuilder.Entity<TipoActividad>(entity =>
            {
                entity.HasIndex(e => e.Nombre).IsUnique();
            });
            #endregion

        }
    }
}
