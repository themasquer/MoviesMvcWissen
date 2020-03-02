using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace _036_MoviesMvcWissen.Models.LogDemo
{
    public class DatabaseLogger : ILogger
    {
        public DatabaseLogger()
        {
            Debug.WriteLine("DatabaseLogger constructor initialized.");
        }

        public void Log(string message)
        {
            Debug.WriteLine("Logged to database: " + message);
        }
    }

    public class FileLogger : ILogger
    {
        public FileLogger()
        {
            Debug.WriteLine("FileLogger constructor initialized.");
        }

        public void Log(string message)
        {
            Debug.WriteLine("Logged to file: " + message);
        }
    }
}