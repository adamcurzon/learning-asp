using learning_asp.Interface;

namespace learning_asp.Service
{
    public class ConsoleLogger : ILog
    {
		public void Log(string message)
		{
			Console.WriteLine("[Log] " + message);
		}
	}
}

