using ReMemory64;
using System;

namespace Rekit
{
    class RekitStart
    {
        static void Main(string[] args)
        {
            var memory = new BaseMemory();

            if (!memory.OpenProcess("Minecraft.Windows.exe"))
            {
                Console.WriteLine("Process not found!");
                return;
            }

            var localPlayer = new LocalPlayer(memory);
            bool localPlayerIsTrue = localPlayer.IsTrue();
            Console.WriteLine($"LocalPlayer: {localPlayerIsTrue}");

            if (!localPlayerIsTrue)
            {
                Console.WriteLine("LocalPlayer not valid.");
                memory.CloseProcess();
                return;
            }

            var currentItem = localPlayer.GetCurrentItem();
            if (currentItem == null)
            {
                Console.WriteLine("CurrentItem pointer is null.");
                memory.CloseProcess();
                return;
            }

            Console.WriteLine($"CurrentItem: {currentItem.IsTrue()}");

            IntPtr itemBase = currentItem.BaseDefault;
            byte slotStack = memory.ReadValue<byte>(itemBase + 0x08);
            Console.WriteLine($"Slot Stack: {slotStack}");

            memory.CloseProcess();
        }



    }
}
