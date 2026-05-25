using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class Units
    {
        public int UnitId { get; private set; }
        public string UnitName { get; private set; } // Piece, Bottle, Pack, Box
        public string Symbol { get; private set; } // pc, bt, pk, bx
    }
}
