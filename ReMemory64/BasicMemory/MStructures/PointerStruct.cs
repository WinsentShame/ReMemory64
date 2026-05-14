using System;

namespace ReMemory64
{
    public abstract class PointerStruct
    {
        protected BaseMemory baseMemory;
        protected IntPtr baseAddress;
        protected int[] baseOffsets;

        public PointerStruct(BaseMemory memory) =>
            baseMemory = memory ?? throw new ArgumentNullException(nameof(memory));

        public PointerStruct(BaseMemory memory, int baseOffset, int[] offsets)
        {
            baseMemory = memory ?? throw new ArgumentNullException(nameof(memory));
            baseOffsets = offsets ?? throw new ArgumentNullException(nameof(offsets));

            IntPtr moduleBase = memory.GetMainModuleBaseAddress();
            if (moduleBase == IntPtr.Zero)
                throw new Exception("Main module not found. Process may not be open.");

            baseAddress = IntPtr.Add(moduleBase, baseOffset);
        }

        public IntPtr BaseDefault
        {
            get
            {
                try { return ResolveAddress(); }
                catch { return IntPtr.Zero; }
            }
        }

        public bool IsTrue() => BaseDefault != IntPtr.Zero;

        private IntPtr ResolveAddress()
        {
            if (baseAddress == IntPtr.Zero || baseOffsets == null)
                return IntPtr.Zero;

            IntPtr currentPtr = baseAddress;
            for (int i = 0; i < baseOffsets.Length; i++)
            {
                long ptrValue = baseMemory.ReadValue<long>(currentPtr);
                if (ptrValue == 0)
                    return IntPtr.Zero;

                currentPtr = new IntPtr(ptrValue + baseOffsets[i]);
            }
            return currentPtr;
        }
    }
}