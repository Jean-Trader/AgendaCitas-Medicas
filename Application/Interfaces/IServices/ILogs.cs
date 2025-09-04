using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface ILogs
    {
      void logInfo(string message);
      void logWarn(string message);
      void logError(string message);
    }
}
 