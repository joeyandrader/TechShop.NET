using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.src.Base.Utilities
{
    public static class AppSettings
    {
        public static string? SqlStringConnection { get; set; }
        public static void LoadSettings(IConfiguration config)
        {
            SqlStringConnection = config.GetValue<string>("SqlStringConnection");
        }
    }
}