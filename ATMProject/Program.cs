namespace ATMProject
{
	internal class Program
	{
		static void Main(string[] args)
		{
			CommandManager commandManager = new CommandManager();

			commandManager.DiscoverCommands();

			while (true)
			{
				commandManager.Scan();
			}
		}
	}
}
