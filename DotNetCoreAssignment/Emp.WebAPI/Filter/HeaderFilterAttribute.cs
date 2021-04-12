using Microsoft.AspNetCore.Mvc;

namespace Emp.WebAPI.Filter
{
    /// <summary>
    /// Making HeaderFilter as an Attribute
    /// </summary>
    public class HeaderFilterAttribute : TypeFilterAttribute
    {
        public HeaderFilterAttribute() : base(typeof(HeaderFilter))
        {
        }
    }
}
