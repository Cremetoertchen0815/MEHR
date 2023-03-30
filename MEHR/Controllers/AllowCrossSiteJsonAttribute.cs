﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace MEHR.Controllers;

public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        filterContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        base.OnActionExecuting(filterContext);
    }
}