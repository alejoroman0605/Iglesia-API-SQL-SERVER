
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            string[] municipios = {
                "Matanzas", "Cárdenas",  "Martí", "Colón", "Perico", "Jovellanos", "Pedro Betancourt", "Limonar", "Unión de Reyes",
                "Ciénaga de Zapata", "Jagüey Grande", "Calimet",  "Los Arabos"
            };

            string[] prov = {
                "Pinar del Río", "Artemisa", "La Habana", "Mayabeque", "La isla de la Juventud", "Matanzas",
                "Villa Clara", "Cienfuegos", "Sancti Spíritus" , "Ciego de Ávila", "Camagüey", "Las Tunas", "Holguín", "Granma",
                "Santiago de Cuba" , "Guantánamo"
            };

            string[] gradoEsc = {
                "Pre-esolar", "Primero", "Segundo", "Tercero", "Cuarto", "Quinto", "Sexto", "Séptimo", "Octavo", "Noveno"
            };
            for (int i = 0; i < prov.Length; i++)
            {
                modelBuilder.Entity<Provincia>().HasData(new Provincia
                {
                    Id = i + 1,
                    Nombre = prov[i]
                });
            }
            for (int i = 0; i < municipios.Length; i++)
            {
                modelBuilder.Entity<Municipio>().HasData(new Municipio
                {
                    Id = i + 1,
                    Nombre = municipios[i],
                    ProvinciaID = 6
                });
            }
           
            for (int i = 0; i < gradoEsc.Length; i++)
            {
                modelBuilder.Entity<GradoEscolar>().HasData(new GradoEscolar
                {
                    Id = i + 1,
                    Nombre = gradoEsc[i]
                });
            }

        }
    }
}
