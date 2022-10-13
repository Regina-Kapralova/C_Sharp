namespace PickyBrideProblem
{
    static class Friend
    {
        public static IContender Compare(IContender contender1, IContender contender2)
        {
            int mark1 = ((Contender)contender1).Mark;
            int mark2 = ((Contender)contender2).Mark;
            if (Hall.IsInHall(mark1) || Hall.IsInHall(mark2))
            {
                return null;
            }
            return (mark1 >= mark2) ? contender1 : contender2;
        }
    }
}
