namespace DemoQA.Automation.Core
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Text;

    public class AutomationTrace
    {

        public interface ILogWritter
        {
            void writeLine(string message);

            void Indent();

            void Unindent();
        }

        private class TraceLogWritter : ILogWritter
        {
            public void Indent()
            {
                Trace.Indent();
            }

            public void Unindent()
            {
                Trace.Unindent();
            }

            public void writeLine(string message)
            {
                Trace.WriteLine(message);
            }
        }

        public static ILogWritter Logger
        {
            get;
            set;
        } = new TraceLogWritter();


        public static void ResetLogger()
        {
            Logger = new TraceLogWritter();
        }

        public static void WriteLine(string message, params object[] args)
        {
            StringBuilder traceMessage = new StringBuilder("[" + DateTime.UtcNow.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture) + "] ");
            if (args == null || args.Length == 0)
            {
                traceMessage.Append(message);
            }
            else
            {
                traceMessage.AppendFormat(message, args);
            }
            Logger.writeLine(traceMessage.ToString());
        }

        public static void WriteLineIf(bool shouldLog, string message)
        {
            if (shouldLog)
            {
                WriteLine(message);
            }
        }

        public static void Indent()
        {
            Trace.Indent();
        }

        public static void Unindent()
        {
            Trace.Unindent();
        }
    }
}
