using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobimentiNewVersion.Entity.Concrete
{
    public class Experience : BaseEntity
    {
        public string CompanyName { get; set; } = string.Empty;
        public DateOnly StartWorkingDate { get; set; }
        public DateOnly EndWorkingDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public byte[]? CompanyLogo { get; set; } = null;
    }
}
