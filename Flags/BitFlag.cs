using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkPhysicsEngine.Flags
{
    class BitFlag
    {
        [Flags]
        enum Flags
        {
            Bit0,
            Bit1,
            Bit2,
            Bit3,
            Bit4,
            Bit5,
            Bit6,
            Bit7,
            Bit8,
            Bit9,
            Bit10,
            Bit11,
            Bit12,
            Bit13,
            Bit14,
            Bit15,
            Bit16,
            Bit17,
            Bit18,
            Bit19,
            Bit20,
            Bit21,
            Bit22,
            Bit23,
            Bit24,
            Bit25,
            Bit26,
            Bit27,
            Bit28,
            Bit29,
            Bit30,
            Bit31,
        }
        Flags Bits = 0;
        void SetFlag(Flags flag)
        {
            Bits = flag;
        }
        void AddFlag(Flags flag)
        {
            Bits |= flag;
        }
        bool CheckFlag(Flags flag)
        {
            return (Bits & flag) != 0;
        }
    }
}
