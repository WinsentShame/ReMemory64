using System;

namespace ReMemory64
{
    public abstract class AddressStruct
    {
        protected BaseMemory baseMemory;
        protected IntPtr address;
        private byte[] originalBytes;

        public AddressStruct(BaseMemory memory, int moduleOffset)
        {
            baseMemory = memory ?? throw new ArgumentNullException(nameof(memory));
            IntPtr moduleBase = memory.GetMainModuleBaseAddress();
            if (moduleBase == IntPtr.Zero)
                throw new Exception("Main module not found.");
            address = IntPtr.Add(moduleBase, moduleOffset);
        }

        public AddressStruct(BaseMemory memory, IntPtr absoluteAddress)
        {
            baseMemory = memory ?? throw new ArgumentNullException(nameof(memory));
            address = absoluteAddress;
        }

        public IntPtr Address => address;
        public bool IsTrue() => address != IntPtr.Zero;

        public byte[] ReadBytes(int length) => baseMemory.ReadBytes(address, length);
        public void WriteBytes(byte[] bytes) => baseMemory.WriteBytes(address, bytes);

        public void Patch(int count)
        {
            if (originalBytes == null)
                originalBytes = ReadBytes(count);

            byte[] nops = new byte[count];
            for (int i = 0; i < count; i++)
                nops[i] = 0x90;
            WriteBytes(nops);
        }

        public void DePatch(byte[] bytes)
        {
            WriteBytes(bytes);
            originalBytes = null;
        }
    }
}