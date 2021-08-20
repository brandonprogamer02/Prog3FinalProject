using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_finalproject.Models.Response
{
    public class Response_Authentication
    {
        public string Token { get; set; }
        public DateTime Fecha_Expira { get; set; }
    }
}
