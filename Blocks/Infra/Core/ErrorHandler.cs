using System;
using System.Text;
using NLog;

namespace Dharma.Core
{
    /// <summary>
    /// Helper class to log error details
    /// </summary>
    public static class ErrorHandler
    {
        /// <summary>
        /// Helper method to log errors with all details (Message and stack trace) to further analysis
        /// </summary>
        /// <param name="e">Exception occurred</param>
        /// <typeparam name="T">Model that was handled</typeparam>
        /// <returns>A model containing generic error to display to client with error code.</returns>
        public static T LogError<T>(Exception e) where T : BaseModel, new()
        {
            var log = LogManager.GetCurrentClassLogger();
            var errorId = Guid.NewGuid();

            var errorInfo = new StringBuilder();

            errorInfo.Append("\n---------------\n\n");

            errorInfo.Append($"[{errorId}] - {DateTime.Now} - {e.Message}\n\n");
            errorInfo.Append($"[Stack Trace] - {e.StackTrace}\n\n");
            
            errorInfo.Append("--------------\n");
            
            log.Error(errorInfo.ToString());
            var result = new T();
            result.ValidationResult.Add(string.Format("An error occurred while trying to finish operation (Reference Code: {0}).", errorId));
            return result;
        }
    }
}