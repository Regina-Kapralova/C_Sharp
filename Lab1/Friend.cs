namespace PickyBrideProblem
{
    static class Friend
    {
        public static IContender Compare(IContender contender1, IContender contender2)
        {
            return (((Contender)contender1).Mark >= ((Contender)contender2).Mark) ? contender1 : contender2;
        }
    }
}
