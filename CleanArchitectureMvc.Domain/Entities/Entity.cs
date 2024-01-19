using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureMvc.Domain.Entities
{
    //definindo classe base
    public abstract class Entity
    {
        public int Id { get; protected set; }
    }
}
