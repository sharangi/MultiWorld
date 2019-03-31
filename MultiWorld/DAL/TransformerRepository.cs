using MultiWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiWorld.DAL
{
    public interface ITransformerRepository : IRepository<Transformer>
    {

    }
    public class TransformerRepository : Repository<Transformer>, ITransformerRepository
    {
        
        public TransformerRepository(MultiWorldDbContext context) :base(context)
        {

        }
    }
}
