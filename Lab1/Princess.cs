using System.IO;
using System.Collections.Generic;

namespace PickyBrideProblem
{
    static class Princess
    {
        private static readonly List<IContender> _exContenders = new List<IContender>();

        private static void SkipContender(IContender contender)
        {
            if (contender == null) return;
            int start = 0, end = _exContenders.Count;
            if (end > 0 && Friend.Compare(contender, _exContenders[0]) != contender)
            {
                _exContenders.Insert(0, contender);
                return;
            }
            int center = (end - start) / 2;
            while (end - start > 1)
            {
                if (Friend.Compare(contender, _exContenders[center]) == contender)
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

        public static void SelectBridegroom()
        {
            IContender contender;
            for (int i = 1; i < 30; i++)
            {
                contender = Hall.InviteContender();
                SkipContender(contender);
            }
            while ((contender = Hall.InviteContender()) != null)
            {
                if (Friend.Compare(contender, _exContenders[_exContenders.Count - 2]) == contender)
                {
                    Hall.Get_married();
                    return;
                }
                SkipContender(contender);
            }
            Hall.Dont_get_married();
            return;
        }
    }
}
