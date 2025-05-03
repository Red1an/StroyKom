using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Entities
{
    public class ServiceCategory : EntityBase
    {
        public ICollection<Services>? Services { get; set; }
    }
}
