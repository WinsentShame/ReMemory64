
using ReMemory64;

namespace Rekit
{
    class PlayerInventoryProxy : PointerStruct
    {
        private static readonly int pipBaseAddress = 0x01921DF8;
        private static readonly int[] pipBaseOffsets = { 0x30, 0x30, 0x0, 0x58, 0x18, 0x0, 0x0 };
        public PlayerInventoryProxy(BaseMemory memory)
            : base(memory, pipBaseAddress, pipBaseOffsets) { }
    }
}
