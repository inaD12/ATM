namespace ATMProject
{
	public class Bootstrapper
	{
		private readonly CommandManager _commandManager;

		public Bootstrapper(CommandManager commandManager)
		{
			_commandManager = commandManager;
		}

		public void Run()
		{
			_commandManager.DiscoverCommands();

			CommandPrinter.PrintAllCommands();

			while (true)
			{
				_commandManager.Scan();
			}
		}
	}

}
