using System;
using System.IO;
using System.Collections.Generic;
namespace Lab1
{
	static class Hall
	{
		private static readonly Dictionary<int, string> contenders = new Dictionary<int, string>();
		private static Contender contender;
		private static int number = 1;
		private static readonly Random rnd = new Random();
		public static void Start()
		{
			String line;
			StreamReader sr = new StreamReader("C:\\Users\\Регина\\OneDrive\\Рабочий стол\\Programming\\C#\\Lab1\\names.txt");
			for (int i = 1; i <= 100; i++)
			{
				line = sr.ReadLine();
				contenders.Add(i, line);
			}
			sr.Close();
		}
		public static IContender Invite_contender()
		{
			if (contenders.Count <= 0) return null;
			while (true)
			{
				int value = rnd.Next(1, 101);
				if (contenders.ContainsKey(value) == true)
				{
					contender = new Contender(contenders[value], value, number);
					Console.WriteLine(number + ") " + contenders[value] + " " + value);
					IContender c = contender;
					number++;
					contenders.Remove(value);
					return c;
				}
				else
				{
					continue;
				}
			}
		}
		public static int Get_married()
		{
			Console.WriteLine((contender.Mark > 50) ? contender.Mark : 0);
			return (contender.Mark > 50) ? contender.Mark : 0;
		}
		public static int Dont_get_married()
		{
			Console.WriteLine(10);
			return 10;
		}
	}
}
