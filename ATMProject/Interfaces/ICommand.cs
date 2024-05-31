using System.Collections.Generic;
using ATMProject.Results;

namespace ATMProject
{
	internal interface ICommand
	{
		Result Execute(List<string> parameters);
	}
}
