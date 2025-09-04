using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
   public class BisnessExeption : Exception
    {
        public BisnessExeption(string message) : base(message) { }
        public BisnessExeption(string message, Exception inner) : base(message, inner) { }
    }
}
