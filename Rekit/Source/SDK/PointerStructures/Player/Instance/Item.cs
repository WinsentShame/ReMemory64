using ReMemory64;
using System;

namespace Rekit
{
    public class Item : PointerStruct
    {
        public Item(BaseMemory memory, IntPtr absoluteAddress) 
            : base(memory, absoluteAddress) { }

        private enum Offset : int
        {
            /// <summary>
            /// 4 bytes
            /// </summary>
            isStuck = 0x08,

            /// <summary>
            /// string
            /// </summary>
            isName = 0x58,

            /// <summary>
            /// 4 bytes
            /// </summary>
            isDamage = 0xE8,

            /// <summary>
            /// 4 bytes
            /// </summary>
            typeId = 0x78,
        }

        // Helmet = 0x20316160
        // Chestplate = 0x20381696
        // Leggins = 0x20447232
        // Boots = 0x20512768
    }
}
