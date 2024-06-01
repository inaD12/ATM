using ATMProject.Interfaces;

namespace ATMProject.Helpers
{
    public class Bootstrapper
    {
        private readonly CommandManager _commandManager;
        private readonly IConsoleManager _consoleManager;

        public Bootstrapper(CommandManager commandManager, IConsoleManager consoleManager)
        {
            _commandManager = commandManager;
            _consoleManager = consoleManager;
        }

        public void Run()
        {
            _commandManager.DiscoverCommands();

            _consoleManager.PrintAllCommands();

            _commandManager.Scan();
        }
    }
}
