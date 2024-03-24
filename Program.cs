using System;

namespace LibraryAdapter
{
    public interface IOldLoggingLibrary
    {
        void LogMessage(string message);
    }

    public interface INewLoggingLibrary
    {
        void Log(string message);
    }

    public class NewToOldLoggingAdapter : IOldLoggingLibrary
    {
        private readonly INewLoggingLibrary _newLoggingLibrary;

        public NewToOldLoggingAdapter(INewLoggingLibrary newLoggingLibrary)
        {
            _newLoggingLibrary = newLoggingLibrary;
        }

        public void LogMessage(string message)
        {
            _newLoggingLibrary.Log(message);
        }
    }

    public class MessageLogger
    {
        private readonly IOldLoggingLibrary _loggingLibrary;

        public MessageLogger(IOldLoggingLibrary loggingLibrary)
        {
            _loggingLibrary = loggingLibrary;
        }

        public void LogMessage(string message)
        {
            _loggingLibrary.LogMessage(message);
        }
    }

     public class NewLoggingLibrary : INewLoggingLibrary
    {
        public void Log(string message)
        {
            Console.WriteLine("Logging message: " + message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            INewLoggingLibrary newLoggingLibrary = new NewLoggingLibrary();

            IOldLoggingLibrary adapter = new NewToOldLoggingAdapter(newLoggingLibrary);

            MessageLogger logger = new MessageLogger(adapter);

            logger.LogMessage("Test message");
        }
    }
}
