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
            const int countContenders = 100;
            String line;
            StreamReader sr = new StreamReader("OneHundredUniqueNames.txt");
            for (int i = 1; i <= countContenders; i++)
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

        public static bool IsInHall(int mark)
        {
        return (_contenders.ContainsKey(mark)) ? true : false;
        }

        public static void GetMarried()
        {
            Console.WriteLine((_contender.Mark > 50) ? _contender.Mark : 0);
        }

        public static void DontGetMarried()
        {
            Console.WriteLine(10);
        }
    }
}
