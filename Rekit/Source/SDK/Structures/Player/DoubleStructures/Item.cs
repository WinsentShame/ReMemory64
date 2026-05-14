using ReMemory64;
using System;

namespace Rekit
{
    public class Item : PointerStruct
    {
        public Item(BaseMemory memory, IntPtr absoluteAddress) : base(memory, absoluteAddress) { }
    }
}
