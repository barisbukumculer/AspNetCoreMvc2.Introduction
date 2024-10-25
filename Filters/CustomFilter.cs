using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace AspNetCoreMvc2.Introduction.Filters
{
    public class CustomFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            int i = 10;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            int i = 20;
        }

    }
}
