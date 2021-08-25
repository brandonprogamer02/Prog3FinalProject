using System;
using System.Collections.Generic;

#nullable disable

namespace api_finalproject.Models
{
    public partial class Aspnetusertoken
    {
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual Aspnetuser User { get; set; }
    }
}
