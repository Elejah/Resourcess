using System;

namespace ItechArt.Common.Logger
{
    public interface ILogger
    {
        void Info(string message);

        void Warn(string message, Exception ex = null);

        void Error(string message, Exception ex);

        void FatalError(string message, Exception ex);
    }
}