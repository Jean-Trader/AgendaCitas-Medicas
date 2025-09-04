using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class RepositoryExeption : Exception
    {
        
        public RepositoryExeption(string message) : base(message) { }
        public RepositoryExeption(string message, Exception inner) : base(message, inner) { }

    }
}
