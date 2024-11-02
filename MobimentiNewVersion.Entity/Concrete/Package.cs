using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobimentiNewVersion.Entity.Concrete
{
    public class Package : BaseEntity
    {
        public string PackageName { get; set; }
        public double Price { get; set; }
        public int SessionCount { get; set; }
        public List<string> Advantages { get; set; } = new List<string>();
        public List<Sale> Sales { get; set; }

    }
}
