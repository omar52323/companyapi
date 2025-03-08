using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companyapi.Domain.Entities
{
    public class Stats
    {
        public int Id { get; set; }
        public  int Value  { get; set; }
        public float Change { get; set; }
    }
}
