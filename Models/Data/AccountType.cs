using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Models.Data
{
    public enum AccountType : int
    {
        Usuario = 0,
        Vendedor = 1,
        Administrador = 2
    }
}