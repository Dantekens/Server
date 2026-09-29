using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Logger
    {
        const string Reset = "\x1b[0m";
        const string Red = "\x1b[31m";
        const string Green = "\x1b[32m";
        const string Yellow = "\x1b[33m";
        Type classType = null;

        public Logger(Type classType)
        {
            this.classType = classType;
        }

        public void info(string text)
        {
            Console.WriteLine($"{Green}[INFO]{Reset} {DateTime.Now}     class {classType.FullName}   Message {text}");
        }
        public void error(string text , Exception ex = null)
        {
            string errInfo = ex != null ? ex.Message : "";
            Console.WriteLine($"{Red}[ERROR]{Reset} {DateTime.Now}     class {classType.FullName}   Message {text}  {errInfo}");
        }
        public void warning(string text)
        {
            Console.WriteLine($"{Yellow}[WARNING]{Reset} {DateTime.Now}     class {classType.FullName}   Message {text}");
        }
    }
}
