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
            Console.WriteLine($"Address valid: {localPlayerIsTrue}");

            if (localPlayerIsTrue)
            {
                IntPtr playerBase = localPlayer.BaseDefault;

                int velocityY = memory.ReadValue<int>(playerBase + 0x30);
                float health = memory.ReadValue<float>(playerBase + 0x100);

                Console.WriteLine($"Velocity Y: {velocityY}, Health: {health}");
            }
            memory.CloseProcess();
        }



    }
}
