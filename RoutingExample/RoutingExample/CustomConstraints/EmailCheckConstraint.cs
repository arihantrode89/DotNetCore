
using System.Text.RegularExpressions;

namespace RoutingExample.CustomConstraints
{
    public class EmailCheckConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {

            if (!values.ContainsKey(routeKey))
            {
                return false;
            }


            Regex rg = new Regex("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$");

            if (rg.IsMatch(values[routeKey].ToString()!))
            {
                httpContext.Response.WriteAsync(values[routeKey].ToString() +"\n");
                return true;
            }
            httpContext.Response.WriteAsync("Please Enter Valid Email\n");
            return false;
        }
    }
}
