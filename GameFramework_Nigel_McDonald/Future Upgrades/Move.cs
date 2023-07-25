using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Move
    {   public int Row { get; set; }
        public int Column { get; set; }

        public Move(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
