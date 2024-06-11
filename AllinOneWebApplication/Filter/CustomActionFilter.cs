using Microsoft.AspNetCore.Mvc.Filters;

namespace AllinOneWebApplication.Filter
{
    public class CustomActionFilter : IActionFilter
    {
        private readonly ILogger<CustomActionFilter> _logger;

        public CustomActionFilter(ILogger<CustomActionFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // This method is called before the action method is executed.
            // You can perform any necessary logging or setup here.
            // Get the controller and action names
            string controllerName = context.RouteData.Values["controller"].ToString();
            string actionName = context.RouteData.Values["action"].ToString();
        }

       
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Get the controller and action names
            string controllerName = context.RouteData.Values["controller"].ToString();
            string actionName = context.RouteData.Values["action"].ToString();

            string a = "";
        }
    }
}
