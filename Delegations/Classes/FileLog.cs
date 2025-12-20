using Delegations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegations.Classes
{
    public class FileLog : ILog
    {
        public void Log(string message)
        {
            using (StreamWriter sw = new StreamWriter("c:\\temp\\DelegateLogger.log", true))
            {
                sw.WriteLine(message);
            }
        }
    }
}
