using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace FirstWebAPI_Task3.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Get exception message
            var exception = context.Exception;
            var message = $"Exception: {exception.Message} at {DateTime.Now}\n";

            // Write to log file (create Logs folder if needed)
            var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            Directory.CreateDirectory(logPath);
            var filePath = Path.Combine(logPath, "ExceptionLog.txt");

            File.AppendAllText(filePath, message);

            // Return internal server error to client
            context.Result = new ObjectResult("Internal server error occurred.")
            {
                StatusCode = 500
            };
        }
    }
}
