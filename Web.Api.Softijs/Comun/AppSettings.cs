using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Softijs.Comun
{
    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }

    }

    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }
}
