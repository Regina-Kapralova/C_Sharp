namespace PickyBrideProblem
{
    /// <summary>
    /// Friend compare two contenders, who already meet Princess
    /// </summary>
    class Friend
    {
        private Hall _hall;

        public Friend(Hall hall)
        {
            _hall = hall;
        }

        public IContender Compare(IContender contender1, IContender contender2)
        {
            /// if (contender is not Contender or Princess didn't meet this contender yet) do not compare
            if (!(contender1 is Contender && contender2 is Contender))
            {
                throw new System.Exception("Error: incorrect type of contender in class Friend.");
            }
            if (_hall.IsInHall(contender1.Name) || _hall.IsInHall(contender2.Name))
            {
                throw new System.Exception("Error: contenders cannot be compared");
            }
            return (((Contender)contender1).Mark >= ((Contender)contender2).Mark) ? contender1 : contender2;
        }
    }
}
