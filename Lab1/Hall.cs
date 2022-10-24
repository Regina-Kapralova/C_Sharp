using System;
using System.IO;
using System.Collections.Generic;
namespace PickyBrideProblem
{
    /// <summary>
    /// This is Hall, where contenders wait to meet Princess.
    /// </summary>
    class Hall
    {
        public const int AmountContenders = 100;
        private readonly Dictionary<int, string> _contenders = new Dictionary<int, string>();
        private bool _selectionIsFinished = false;

        /// <summary>
        /// Creating list of contender.
        /// </summary>
        public void Start()
        {
            String line;
            StreamReader sr = new StreamReader("OneHundredUniqueNames.txt");
            for (int i = 1; i <= AmountContenders; i++)
            {
                line = sr.ReadLine();
                _contenders.Add(i, line);
            }
            sr.Close();
        }

        /// <summary>
        /// Contenders go to the princess in random order.
        /// </summary>
        public IContender InviteContender()
        {
            if (_contenders.Count <= 0) return null;
            Random rnd = new Random();
            int minContendersMark = 1;
            int maxContendersMark = 100;
            while (true)
            {
                int value = rnd.Next(minContendersMark, maxContendersMark + 1);
                if (_contenders.ContainsKey(value))
                {
                    IContender contender = new Contender(_contenders[value], value);
                    Console.WriteLine(_contenders[value]);
                    _contenders.Remove(value);
                    return contender;
                }
                else
                {
                    continue;
                }
            }
        }

        public bool IsInHall(string name)
        {
            return (_contenders.ContainsValue(name)) ? true : false;
        }

        public int GetMark(IContender contender)
        {
            if (_selectionIsFinished)
            {
                throw new Exception("Error: Princess is already married");
            }
            if (!(contender is Contender))
            {
                throw new Exception("Error: incorrect type of contender in class Hall.");
            }
            else
            {
                _selectionIsFinished = true;
                return ((Contender)contender).Mark;
            }
        }   
    }
}
