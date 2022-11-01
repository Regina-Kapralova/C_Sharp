using System.IO;
using System.Collections.Generic;
using System;

namespace PickyBrideProblem
{
    /// <summary>
    /// Princess wants to get married successfully.
    /// </summary>
    class Princess
    {
        private Hall _hall;
        private Friend _friend;
        ///  sorted list of contenders, who was not chosen by princess 
        private List<IContender> _exContenders;
        private int _levelHappinessPrincess;
        private const int LowerLimitCoolnessOfContender = 50;
        private const int LevelHappinessUnmarriedPrincess = 10;
        private const int PrincessIsUnhappy = 0;

        public Princess(Hall hall, Friend friend)
        {
            _hall = hall;
            _friend = friend;
            _exContenders = new List<IContender>();
        }

        /// <summary>
        /// Princess remembers what place the missed Contender has in her own ranking(_exContenders).
        /// </summary>
        private void SkipContender(IContender contender)
        {
            if (contender == null) return;
            int start = 0, end = _exContenders.Count;
            /// if current contender the worst, put it in _exContenders[0]
            if (end > 0 && _friend.Compare(contender, _exContenders[0]) != contender)
            {
                _exContenders.Insert(0, contender);
                return;
            }
            /// using binary search, find position for current contender in sortered list
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
            /// insert current contender in list on finded position
            _exContenders.Insert(end, contender);
        }

        /// <summary>
        /// Princess select Contender, who will become her husband.
        /// </summary>
        public void SelectBridegroom()
        {
            IContender contender;
            /// Princess skiped 30% contenders
            const double partSkipedContenders = 0.3;
            for (int i = 1; i < partSkipedContenders * Hall.AmountOfContenders; i++)
            {
                contender = _hall.InviteContender();
                SkipContender(contender);
            }
            /// Then princess find contender that better than _exContenders[_exContenders.Count - 2]
            while ((contender = _hall.InviteContender()) != null)
            {
                if (_friend.Compare(contender, _exContenders[_exContenders.Count - 2]) == contender)
                {
                    /// if finded, get married
                    ChooseContender(contender);
                    return;
                }
                SkipContender(contender);
            }
            /// if didn't find, don't get married
            ChooseContender(null);
            return;
        }

        /// <summary>
        /// Princess count her lavel happiness.
        /// </summary>
        private void ChooseContender(IContender contender)
        {
            if (contender == null)
            {
                _levelHappinessPrincess = LevelHappinessUnmarriedPrincess;
            }
            int mark = _hall.GetMark(contender.Name);
            _levelHappinessPrincess = (mark > LowerLimitCoolnessOfContender) ? mark : PrincessIsUnhappy;
            Console.WriteLine(_levelHappinessPrincess);
        }
    }
}
