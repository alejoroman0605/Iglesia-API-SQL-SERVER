using Library.Data.Interfaces;
using Library.Data.Models;
using Library.Repository.Interfaces;
using Library.Repository.Services;
using Library.Service.Interfaces;
using Library.Service.Interfaces.IServ;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Services.Serv
{
    public class IglesiaService : BaseService<Iglesia>, IIglesiaService
    {
        private Expression<Func<Iglesia, object>>[] includeProperties =  {
            l => l.Municipio
        };
        public IglesiaService(IUnitOfWork repositories /*,IBaseRepository<Recess> baseRepository*/) : base(repositories, repositories.Iglesias)
        {

        }
        protected override IQueryable<Iglesia> CreateQuery()
          => _baseRepository.GetQuery(includeProperties);
    }
}
