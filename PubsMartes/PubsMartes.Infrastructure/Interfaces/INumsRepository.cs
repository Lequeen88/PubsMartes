using PubsMartes.Domain.Entities;
using PubsMartes.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubsMartes.Infrastructure.Interfaces
{
   public interface  INumsRepository : IBaseRepository<Nums>
    {
        List<Nums> GetNumsByID(int id);
    }
}
