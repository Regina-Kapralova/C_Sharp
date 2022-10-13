using System;
using System.IO;
using System.Collections.Generic;
namespace PickyBrideProblem
{
    class Hall
    {
        public const int countContenders = 100;
        private Dictionary<int, string> _contenders = new Dictionary<int, string>();
        private const int lowerLimitCoolnessOfContender = 50;
        private const int levelHappinessUnmarriedPrincess = 10;
        private const int princessIsUnhappy = 0;

        public void Start()
        {
            String line;
            StreamReader sr = new StreamReader("OneHundredUniqueNames.txt");
            for (int i = 1; i <= countContenders; i++)
            {
                line = sr.ReadLine();
                _contenders.Add(i, line);
            }
            sr.Close();
        }

        public IContender InviteContender()
        {
            if (_contenders.Count <= 0) return null;
            Random rnd = new Random();
            while (true)
            {
                int value = rnd.Next(1, 101);
                if (_contenders.ContainsKey(value))
                {
                    IContender contender = new Contender(_contenders[value], value);
                    Console.WriteLine(_contenders[value], value);
                    _contenders.Remove(value);
                    return contender;
                }
                else
                {
                    continue;
                }
            }
        }

        public bool IsInHall(int mark)
        {
            return (_contenders.ContainsKey(mark)) ? true : false;
        }

        public int GetLevelHappinessPrincess(IContender contender)
        {
            if (contender == null)
            {
                return levelHappinessUnmarriedPrincess;
            }
            else
            {
                int levelCoolnessOfContender = ((Contender)contender).Mark;
                int levelHappinessPrincess = (levelCoolnessOfContender > lowerLimitCoolnessOfContender) 
                    ? levelCoolnessOfContender : princessIsUnhappy;
                return levelHappinessPrincess;
            }
        }   
    }
}
