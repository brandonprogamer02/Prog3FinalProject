using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_finalproject.Models.Response
{
    public class Response<T>
    {
        public int Exito { get; set; }

        public string Mensaje { get; set; }

        public T ls { get; set; }
    }
}
