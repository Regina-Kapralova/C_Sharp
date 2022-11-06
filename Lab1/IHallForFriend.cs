using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickyBrideProblem
{
    interface IHallForFriend
    {
        bool IsInHall(string name);
        int GetMarkForFriend(string name);
    }
}
