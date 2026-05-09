using ReMemory64;

namespace Rekit
{
    public class Local_Player : Memory_Struct
    {
        private static readonly int lpBaseAddress = 0x01921DF8;
        private static readonly int[] lpBaseOffsets = { 0x30, 0x30, 0x0, 0x58, 0x18, 0x0, 0x0 };

        public Local_Player(Base_Memory memory)
            : base(memory, lpBaseAddress, lpBaseOffsets) { }
    }
}
