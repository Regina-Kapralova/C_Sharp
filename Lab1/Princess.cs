using System.IO;
using System.Collections.Generic;
using System;

namespace PickyBrideProblem
{
    class Princess
    {
        private Hall _hall;
        private Friend _friend;
        private List<IContender> _exContenders;
        private int levelHappinessPrincess;

        public Princess(Hall hall, Friend friend)
        {
            _hall = hall;
            _friend = friend;
            _exContenders = new List<IContender>();
        }

        private void SkipContender(IContender contender)
        {
            if (contender == null) return;
            int start = 0, end = _exContenders.Count;
            if (end > 0 && _friend.Compare(contender, _exContenders[0]) != contender)
            {
                _exContenders.Insert(0, contender);
                return;
            }
            int center = (end - start) / 2;
            while (end - start > 1)
            {
                if (_friend.Compare(contender, _exContenders[center]) == contender)
                {
                    start = center;
                    center = (end - start) / 2 + start;
                }
                else
                {
                    end = center;
                    center = (end - start) / 2;
                }
            }
            _exContenders.Insert(end, contender);
        }

        public void SelectBridegroom()
        {
            IContender contender;
            const double partSkipedContenders = 0.3;
            for (int i = 1; i < partSkipedContenders * Hall.countContenders; i++)
            {
                contender = _hall.InviteContender();
                SkipContender(contender);
            }
            while ((contender = _hall.InviteContender()) != null)
            {
                if (_friend.Compare(contender, _exContenders[_exContenders.Count - 2]) == contender)
                {
                    ChooseContender(contender);
                    return;
                }
                SkipContender(contender);
            }
            ChooseContender(null);
            return;
        }
        private void ChooseContender(IContender contender)
        {
            levelHappinessPrincess = _hall.GetLevelHappinessPrincess(contender);
            Console.WriteLine(levelHappinessPrincess);
        }
    }
}
