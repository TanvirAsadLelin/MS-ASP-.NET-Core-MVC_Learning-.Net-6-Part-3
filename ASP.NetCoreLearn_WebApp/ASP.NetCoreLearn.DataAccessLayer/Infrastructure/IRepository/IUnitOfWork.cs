using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NetCoreLearn.DataAccessLayer.Infrastructure.IRepository
{
    public interface IUnitOfWork
    {
        ICityRepository City{ get; }
        void Save();
    }
}
