﻿using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp.WebAPI.Filter
{
    public class HeaderFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add(
                "Name",
                "Aarsh");
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }
    }
}