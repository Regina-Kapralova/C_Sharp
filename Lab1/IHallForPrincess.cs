using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickyBrideProblem
{
    interface IHallForPrincess
    {
        int AmountOfContenders { get; }
        IContender InviteContender();
        int GetMarkForPrincess(string name);
    }
}
