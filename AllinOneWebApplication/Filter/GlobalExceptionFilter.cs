using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace AllinOneWebApplication.Filter
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            // Log the exception
            _logger.LogError(context.Exception, "An unexpected error occurred.");

            var exception = context.Exception;
            var stackTrace = new StackTrace(exception, true);
            var frame = stackTrace.GetFrame(0); // Get the top stack frame

            // Extract information from the stack frame
            var methodName = frame.GetMethod().Name;
            var typeName = frame.GetMethod().DeclaringType.FullName;
            var assemblyName = frame.GetMethod().DeclaringType.Assembly.GetName().Name;

            // Log the exception
            //  _errorLogDAL.SetError("MFTS", assemblyName, typeName, methodName, exception.Message, "ADDITIONAL REMARKS");

          

            // Optionally, handle the exception or perform additional actions here
            // context.Result = new RedirectToActionResult("Login", "Account", null);
            //  return;

        }
    }
}
