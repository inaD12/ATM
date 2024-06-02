using ATMProject.Results;
using System;
using System.Collections.Generic;

namespace ATMProject.Commands
{
	internal class EndCommand : ICommand
	{
		public Result Execute(List<string> parameters)
		{
			Environment.Exit(0);

			return Result.Success();
		}
	}
}
