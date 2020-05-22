using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance_Repository
{
    public class Badge
    {
        public int BadgeNum { get; set; }
        public List<string> Doors { get; set; }

        public Badge(int badgeNum, List<string> doors)
        {
            BadgeNum = badgeNum;
            Doors = doors;
        }
        public Badge()
        {

        }
    }
}
