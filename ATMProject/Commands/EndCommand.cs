using System;
using System.Collections.Generic;

namespace ATMProject.Commands
{
	internal class EndCommand : ICommand
	{
		public void Execute(List<string> parameters)
		{
			Environment.Exit(0);
		}
	}
}
