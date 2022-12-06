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
        private readonly List<Contender> _contenders = new List<Contender>();
        private readonly Dictionary<string, int> _exContenders = new Dictionary<string, int>();
        private bool _selectionIsFinished = false;
        private readonly ContenderGenerator _contenderGenerator;

        public Hall(ContenderGenerator contenderGenerator)
        {
            _contenderGenerator = contenderGenerator;
        }

        public void Init()
        {
            _contenderGenerator.Init();
            for (int i = 0; i < AmountOfContenders; i++)
            {
                _contenders.Add(_contenderGenerator.GenerateContender());
            }
        }

        /// <summary>
        /// Contenders go to the princess in random order.
        /// </summary>
        public IContender InviteContender()
        {
            if (_contenders.Count <= 0) return null;
            Contender contender = _contenders[0];
            _contenders.RemoveAt(0);
            _exContenders.Add(contender.Name, contender.Mark);
            Console.WriteLine(contender.Name);
            return (IContender)contender;
        }

        public bool IsInHall(string name)
        {
            return !(_exContenders.ContainsKey(name));
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
