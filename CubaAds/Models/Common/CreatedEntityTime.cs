using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common 
{
    public abstract class CreatedEntityTime : Entity
    {
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
