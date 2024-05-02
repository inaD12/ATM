using System.Collections.Generic;

namespace ATMProject
{
	internal interface ICommand
	{
		void Execute(List<string> parameters);
	}
}
