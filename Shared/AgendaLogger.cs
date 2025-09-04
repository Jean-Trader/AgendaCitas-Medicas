using Application.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class AgendaLogger<T> : ILogs<T>
    {
        ILogs<AgendaLogger<T>> _logger;
        public AgendaLogger(ILogs<AgendaLogger<T>> logger) 
        { 
        _logger = logger;
        }
        public void logInfo(string message)
        {
           
        }
        public void logWard(string message)
        {
          
        }
        public void logError(string message)
        {
           
        }
    }
}
