using System;

namespace ReMemory64
{
    public abstract class Memory_Struct
    {
        protected Base_Memory baseMemory;
        protected IntPtr baseAddress;
        protected int[] baseOffsets;

        public Memory_Struct(Base_Memory memory)
        {
            baseMemory = memory ?? throw new ArgumentNullException(nameof(memory));
        }

        public Memory_Struct(Base_Memory memory, int baseOffset, int[] offsets)
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
                try
                {
                    return ResolveAddress();
                }
                catch
                {
                    return IntPtr.Zero;
                }
            }
        }

        public bool IsTrue()
        {
            return BaseDefault != IntPtr.Zero;
        }

        public void DebugChain()
        {
            if (baseAddress == IntPtr.Zero)
            {
                Console.WriteLine("baseAddress is zero.");
                return;
            }

            IntPtr currentPtr = baseAddress;
            Console.WriteLine($"Start address (baseAddress): 0x{currentPtr.ToInt64():X}");

            for (int i = 0; i < baseOffsets.Length; i++)
            {
                long ptrValue = 0;
                try
                {
                    ptrValue = baseMemory.ReadValue<long>(currentPtr);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Read error at step {i}: {ex.Message}");
                    return;
                }

                Console.WriteLine($"  Step {i}: read at 0x{currentPtr.ToInt64():X} -> pointer = 0x{ptrValue:X}");
                if (ptrValue == 0)
                {
                    Console.WriteLine("  Chain broken, pointer is 0.");
                    return;
                }

                currentPtr = new IntPtr(ptrValue + baseOffsets[i]);
                Console.WriteLine($"  + offset 0x{baseOffsets[i]:X} => next address 0x{currentPtr.ToInt64():X}");
            }

            Console.WriteLine($"Final address: 0x{currentPtr.ToInt64():X}");
        }

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
