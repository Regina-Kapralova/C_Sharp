using System;
using System.IO;
namespace PickyBrideProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Hall hall = new Hall();
            hall.Start();
            Friend friend = new Friend((IHallForFriend)hall);
            Princess princess = new Princess((IHallForPrincess)hall, friend);
            princess.SelectBridegroom();
        }
    }
}
