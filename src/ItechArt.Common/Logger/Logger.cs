using System;
using log4net;
using log4net.Config;

namespace ItechArt.Common.Logger
{
    public class Logger : ILogger
    {
        private static readonly ILog Log;


        static Logger()
        {
            XmlConfigurator.Configure();
            Log = LogManager.GetLogger(typeof(Logger));
        }


        public void Info(string message)
        {
            Log.Info(message);
        }

        public void Warn(string message, Exception ex = null)
        {
            Log.Warn(message, ex);
        }

        public void Error(string message, Exception ex)
        {
            Log.Error(message, ex);
        }

        public void FatalError(string message, Exception ex)
        {
            Log.Fatal(message, ex);
        }
    }
}