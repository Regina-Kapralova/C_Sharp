using System;
using System.IO;
using System.Collections.Generic;
namespace PickyBrideProblem
{
    static class Hall
    {
        private static readonly Dictionary<int, string> _contenders = new Dictionary<int, string>();
        private static Contender _contender;

        public static void Start()
        {
            String line;
            StreamReader sr = new StreamReader("OneHundredUniqueNames.txt");
            for (int i = 1; i <= 100; i++)
            {
                line = sr.ReadLine();
                _contenders.Add(i, line);
            }
            sr.Close();
        }

        public static IContender InviteContender()
        {
            if (_contenders.Count <= 0) return null;
            Random rnd = new Random();
            while (true)
            {
                int value = rnd.Next(1, 101);
                if (_contenders.ContainsKey(value))
                {
                    _contender = new Contender(_contenders[value], value);
                    Console.WriteLine(_contenders[value]);
                    IContender c = _contender;
                    _contenders.Remove(value);
                    return c;
                }
                else
                {
                    continue;
                }
            }
        }

        public static void Get_married()
        {
            Console.WriteLine((_contender.Mark > 50) ? _contender.Mark : 0);
        }

        public static void Dont_get_married()
        {
            Console.WriteLine(10);
        }
    }
}
