using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp.WebAPI.Filter
{
    public class HeaderFilterAttribute : TypeFilterAttribute
    {
        public HeaderFilterAttribute() : base(typeof(HeaderFilter))
        {
        }
    }
}
