using ReMemory64;

namespace Rekit
{
    class ItemDelay : AddressStruct
    {
        public ItemDelay(BaseMemory memory)
            : base(memory, 0xA1F4B2) { }
    }
}
