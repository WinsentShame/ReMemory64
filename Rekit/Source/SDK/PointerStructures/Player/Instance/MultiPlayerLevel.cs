using ReMemory64;
using System;

namespace Rekit
{
    class MultiPlayerLevel : PointerStruct
    {
        public MultiPlayerLevel(BaseMemory memory, IntPtr absoluteAddress)
            : base(memory, absoluteAddress) { }
        private enum Offset : int
        {
            isTime = 0x194,
            educationEdition = 0x24C,
            TriggerAll = 0x3C8, // 3 - None, 0 - Block, 1 - Entity
            TriggerBlock = 0x3CC // 0 - None, 1 - locked Block, 4 - West, 2 - North, 3- South, 5 - East
                ww
        }
    }
}
