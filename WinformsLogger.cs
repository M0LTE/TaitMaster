using Microsoft.Extensions.Logging;

namespace TaitMaster
{
    public class WinformsLogger : ILogger
    {
        private TextBox logPane;

        public WinformsLogger(TextBox logPane)
        {
            this.logPane = logPane;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var msg = formatter(state, exception);

            logPane.Invoke(new Action(() =>
            {
                logPane.AppendText(msg + Environment.NewLine);
            }));
        }
    }
}
