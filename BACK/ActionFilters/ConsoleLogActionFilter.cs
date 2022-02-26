using System;
using BACK.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Back.Filters
{
    public class ConsoleLogActionFilter : IActionFilter
    {
        private readonly ILogger _logger;

        public ConsoleLogActionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("ConsoleLogActionFilter");
        }

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var result = (ObjectResult) context.Result;

            if (result.StatusCode != null) return;            
            
            _logger.LogInformation(GetLogMessage(context, result));
        }

        private string GetLogMessage(ActionExecutedContext context, ObjectResult result)
        {
            var card = context.HttpContext.Items["oldCard"] as Card;
            
            var action = context.HttpContext.Request.Method == "DELETE" ?  "Removido" : "Alterado";

            return $"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - Card {card.Id} - {card.Titulo} - {action}";
        }
    }
}