using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickyBrideProblem
{
    class ContenderGenerator
    {
        public int AmountOfContenders { get; } = 100;
        private readonly Dictionary<int, string> _contenders = new Dictionary<int, string>();

        public ContenderGenerator()
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

        public Contender GenerateContender()
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
                    _contenders.Remove(value);
                    return contender;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
