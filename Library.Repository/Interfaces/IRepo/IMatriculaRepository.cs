using Library.Data.Interfaces;
using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository.Interfaces.IRepo
{
    public interface IMatriculaRepository : IBaseRepository<Matricula>
    {   
        Task<bool> AnyMatriculadoAsync(int ProyectoID, int NinoID, int Id);
    }
}
