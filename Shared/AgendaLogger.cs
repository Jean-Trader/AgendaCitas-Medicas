using Application.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

namespace Shared
{
    public class AgendaLogger : ILogs
    {
        private readonly ILogger<AgendaLogger> _logger;
        public AgendaLogger(ILogger<AgendaLogger> logger) 
        { 
        _logger = logger;
        }
        public void logInfo(string message)
        {
           _logger.LogInformation($"{DateTime.Now} INFO: {message}");
        }
        public void logWarn(string message)
        {
          _logger.LogWarning($"{DateTime.Now} WARN: {message}");
        }
        public void logError(string message)
        {
           _logger.LogError($"{DateTime.Now} ERROR: {message}");
        }
    }
}
