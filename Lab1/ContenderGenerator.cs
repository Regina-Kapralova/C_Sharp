using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickyBrideProblem
{
    public class ContenderGenerator : IContenderGenerator
    {
        private readonly Dictionary<int, string> _contenders = new Dictionary<int, string>();
        private List<Contender> _contendersForHall = new List<Contender>();

        public void Init(int amountOfContenders)
        {
            if (amountOfContenders < 0 || amountOfContenders > 100)
                throw new Exception("Error: impossible to create list of less than 0 or more than 100 Contenders!");
            string line;
            StreamReader sr = new StreamReader("OneHundredUniqueNames.txt");
            for (int i = 1; i <= amountOfContenders; i++)
            {
                line = sr.ReadLine();
                _contenders.Add(i, line);
            }
            sr.Close();
        }

        public List<Contender> InitContenderList()
        {
            Random rnd = new Random();
            int minContendersMark = 1;
            int maxContendersMark = 100;
            while (_contenders.Count > 0) 
            {
                while (true)
                {
                    int value = rnd.Next(minContendersMark, maxContendersMark + 1);
                    if (_contenders.ContainsKey(value))
                    {
                        Contender contender = new Contender(_contenders[value], value);
                        _contendersForHall.Add(contender);
                        _contenders.Remove(value);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return _contendersForHall;
        }
    }
}
