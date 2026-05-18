using ReMemory64;

namespace Rekit
{
    class JumpDelay : AddressStruct
    {
        public JumpDelay(BaseMemory memory)
            : base(memory, 0xA1F4B2) { }
    }
}
