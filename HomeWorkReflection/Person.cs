using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkReflection
{
	public class Person
	{
		private string? Name = "Vlad";
		private int Age { get; set; } = 31;

		

		private void ShowHello()
		{
			Console.WriteLine($"Привет, меня зовут {Name}");
		}
	}
}
