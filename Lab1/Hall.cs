using System;
using System.IO;
using System.Collections.Generic;
namespace PickyBrideProblem
{
    /// <summary>
    /// This is Hall, where contenders wait to meet Princess.
    /// </summary>
    class Hall : IHallForPrincess, IHallForFriend
    {
        public int AmountOfContenders { get; } = 100;
        private readonly Dictionary<int, string> _contenders = new Dictionary<int, string>();
        private readonly Dictionary<string, int> _exContenders = new Dictionary<string, int>();
        private bool _selectionIsFinished = false;

        /// <summary>
        /// Creating list of contender.
        /// </summary>
        public void Start()
        {
            String line;
            StreamReader sr = new StreamReader("OneHundredUniqueNames.txt");
            for (int i = 1; i <= AmountOfContenders; i++)
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
                    Contender contender = new Contender(_contenders[value], value);
                    Console.WriteLine(contender.Name);
                    _exContenders.Add(contender.Name, contender.Mark);
                    _contenders.Remove(value);
                    return (IContender)contender;
                }
                else
                {
                    continue;
                }
            }
        }

        public bool IsInHall(string name)
        {
            return _contenders.ContainsValue(name);
        }

        public int GetMarkForFriend(string name)
        {
            return _exContenders[name];
        }

        public int GetMarkForPrincess(string name)
        {
            if (_selectionIsFinished)
            {
                throw new Exception("Error: Princess is already married");
            }
            else
            {
                _selectionIsFinished = true;
                return _exContenders[name];
            }
        }   
    }
}
