using System.Reflection;
using System.Xml.Linq;

namespace HomeWorkReflection
{
	public class Program
	{
		static void Main(string[] args)
		{
			var person = new Person();
			Console.WriteLine(person.GetType());

			Type type = typeof(Person);
			Console.WriteLine(type);
			Console.WriteLine();

			foreach (var member in type.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance))
			{
				Console.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");
			}

			var privateField = type.GetField("Name", BindingFlags.NonPublic | BindingFlags.Instance);
			if (privateField != null)
			{
				Console.WriteLine("\nПриватное поле:");
				Console.WriteLine(privateField.Name);
				Console.WriteLine(privateField.FieldType.Name);
				Console.WriteLine($"GetValue - {privateField.GetValue(person)}");
				privateField.SetValue(person,"Jack");//Устанавливаем новое значение поля Name
				Console.WriteLine($"SetValue - {privateField.GetValue(person)}");
			}
			else
			{
				Console.WriteLine("Поле Name не найден");
			}

			var privateProperty = type.GetProperty("Age", BindingFlags.NonPublic | BindingFlags.Instance);		
			
			if (privateProperty != null)
			{
				Console.WriteLine("\nПриватное свойство:");
				Console.WriteLine(privateProperty.Name);
				Console.WriteLine(privateProperty.PropertyType.Name);
				Console.WriteLine($"GetValue - {privateProperty.GetValue(person)}");
				privateProperty.SetValue(person, 50);//Устанавливаем новое значение свойства Age
				Console.WriteLine($"SetValue - {privateProperty.GetValue(person)}");
			}
			else
			{
				Console.WriteLine("Свойство Age не найдено");
			}


			var privateMethod = type.GetMethod("ShowHello", BindingFlags.NonPublic | BindingFlags.Instance);
			if (privateMethod != null)
			{
				Console.WriteLine("\nПриватный метод:");
				Console.WriteLine(privateMethod.Name);
				Console.WriteLine(privateMethod.ReturnType.Name);
				privateMethod.Invoke(person, null);
			}
			else
			{
				Console.WriteLine("Метод SayHello не найден");
			}
		}
	}
}