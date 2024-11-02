using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MobimentiNewVersion.Entity.Result
{
    public class AuthResult
    {
        public string? Token { get; set; }
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public ClaimsPrincipal? ClaimsPrincipal { get; set; }
    }

}
