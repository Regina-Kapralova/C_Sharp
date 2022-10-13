namespace PickyBrideProblem
{
    class Friend
    {
        private Hall _hall;
        public Friend(Hall hall)
        {
            _hall = hall;
        }
        public IContender Compare(IContender contender1, IContender contender2)
        {
            int mark1 = ((Contender)contender1).Mark;
            int mark2 = ((Contender)contender2).Mark;
            if (_hall.IsInHall(mark1) || _hall.IsInHall(mark2))
            {
                return null;
            }
            return (mark1 >= mark2) ? contender1 : contender2;
        }
    }
}
