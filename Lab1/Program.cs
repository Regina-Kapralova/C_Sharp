using System;
using System.IO;
namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
			File.Create("C:\\Users\\Регина\\OneDrive\\Рабочий стол\\Programming\\C#\\Lab1\\out.txt").Close();
			Hall.Start();
			Princess.Selection();

			Console.WriteLine("Final!");
			Console.ReadLine();

		}
	}
}
