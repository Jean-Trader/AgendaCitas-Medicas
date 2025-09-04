using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface ILogs<T>
    {
      void logInfo(string message);
      void logWard(string message);
      void logError(string message);
    }
}
 