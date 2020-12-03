using Microsoft.Extensions.Logging;
using System;

namespace UnitTests.BL.Mocks
{
    public class LoggerFactoryMock : ILoggerFactory
    {
        public void AddProvider(ILoggerProvider provider) { }

        public ILogger CreateLogger(string categoryName)
        {
            return new LoggerMock();
        }

        public void Dispose() { }
    }
    public class LoggerMock<T> : ILogger<T>
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {}
    }
    public class LoggerMock : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {}
    }
}
