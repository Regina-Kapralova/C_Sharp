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
            /// if Princess didn't meet this contender yet do not compare
            if (_hall.IsInHall(contender1.Name) || _hall.IsInHall(contender2.Name))
            {
                throw new System.Exception("Error: contenders cannot be compared");
            }
            return _hall.Compare(contender1.Name, contender2.Name) ? contender1 : contender2;
        }
    }
}
