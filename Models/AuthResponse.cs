using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Models
{
    public class AuthResponse
    {
        public string? Access_Token { get; set; }
        public int? expires_in { get; set; }
        public string? Token_Type { get; set; }
    }
}