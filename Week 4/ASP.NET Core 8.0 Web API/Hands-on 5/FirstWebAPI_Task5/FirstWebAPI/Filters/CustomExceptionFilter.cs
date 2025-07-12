using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FirstWebAPI_Task5.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var message = $"Exception: {exception.Message} at {DateTime.Now}\n";

            var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            var filePath = Path.Combine(logPath, "ExceptionLog.txt");

            try
            {
                Directory.CreateDirectory(logPath);
                File.AppendAllText(filePath, message);
            }
            catch { }

            context.Result = new ObjectResult("Internal server error occurred.")
            {
                StatusCode = 500
            };
        }
    }
}
