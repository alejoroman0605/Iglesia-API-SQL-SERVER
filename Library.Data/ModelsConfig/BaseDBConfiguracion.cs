using Library.Data;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.ModelsConfigurations
{
    public class BaseDBConfiguracion<TEntity> where TEntity : EntityBase
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad

            modelBuilder.Entity<TEntity>().Property(entity => entity.Id).IsRequired()
                         .ValueGeneratedOnAdd();            

            modelBuilder.Entity<TEntity>().HasIndex(entity => entity.Id).IsUnique();

            #endregion
        }
    }
}
