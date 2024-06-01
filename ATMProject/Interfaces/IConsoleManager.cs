namespace ATMProject.Interfaces
{
	public interface IConsoleManager
	{
		void WriteInfo(string message);
		void WriteError(string message);
		void WriteEmptyLine();
		void ClearConsole();
		string ReadLine();
	}
}