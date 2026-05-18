using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
// ---
using static ReMemory64.WinApi;

namespace ReMemory64
{
    public class BaseMemory : IDisposable
    {
        private IntPtr processHandle;
        private Process targetProcess;
        private string processName;

        public bool OpenProcess(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Process name cannot be empty.");

            string cleanName = name.Replace(".exe", "");
            Process[] processes = Process.GetProcessesByName(cleanName);
            if (processes.Length == 0)
                return false;

            targetProcess = processes[0];
            processName = targetProcess.ProcessName;

            uint accessFlags = PROCESS_VM_READ | PROCESS_VM_WRITE | PROCESS_VM_OPERATION | PROCESS_QUERY_INFORMATION;
            processHandle = WinApi.OpenProcess(accessFlags, false, targetProcess.Id);

            return processHandle != IntPtr.Zero;
        }

        public void CloseProcess()
        {
            if (processHandle != IntPtr.Zero)
            {
                CloseHandle(processHandle);
                processHandle = IntPtr.Zero;
                targetProcess = null;
                processName = null;
            }
        }

        public IntPtr GetMainModuleBaseAddress()
        {
            if (targetProcess == null)
                throw new InvalidOperationException("Process is not open.");
            if (string.IsNullOrEmpty(processName))
                throw new InvalidOperationException("Module name is not stored.");

            foreach (ProcessModule module in targetProcess.Modules)
            {
                if (module.ModuleName.Equals(processName + ".exe", StringComparison.OrdinalIgnoreCase))
                    return module.BaseAddress;
            }
            return IntPtr.Zero;
        }

        public IntPtr GetModuleBaseAddress(string moduleName)
        {
            if (targetProcess == null)
                throw new InvalidOperationException("Process is not open.");
            if (string.IsNullOrWhiteSpace(moduleName))
                throw new ArgumentException("Module name cannot be empty.");

            foreach (ProcessModule module in targetProcess.Modules)
            {
                if (module.ModuleName.Equals(moduleName, StringComparison.OrdinalIgnoreCase))
                    return module.BaseAddress;
            }
            return IntPtr.Zero;
        }

        public T ReadValue<T>(IntPtr address) where T : struct
        {
            int size = Marshal.SizeOf<T>();
            byte[] buffer = new byte[size];
            ReadProcessMemory(processHandle, address, buffer, (uint)size, out IntPtr bytesRead);

            if (bytesRead.ToInt64() != size)
                throw new Exception($"Failed to read memory at address 0x{address.ToInt64():X}.");

            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try
            {
                return Marshal.PtrToStructure<T>(handle.AddrOfPinnedObject());
            }
            finally
            {
                handle.Free();
            }
        }

        public void WriteValue<T>(IntPtr address, T value) where T : struct
        {
            int size = Marshal.SizeOf<T>();
            byte[] buffer = new byte[size];

            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try
            {
                Marshal.StructureToPtr(value, handle.AddrOfPinnedObject(), false);
            }
            finally
            {
                handle.Free();
            }

            WriteProcessMemory(processHandle, address, buffer, (uint)size, out IntPtr bytesWritten);
            if (bytesWritten.ToInt64() != size)
                throw new Exception($"Failed to write memory at address 0x{address.ToInt64():X}.");
        }

        public byte[] ReadBytes(IntPtr address, int length)
        {
            byte[] buffer = new byte[length];
            ReadProcessMemory(processHandle, address, buffer, (uint)length, out IntPtr bytesRead);
            if (bytesRead.ToInt64() != length)
                throw new Exception($"Failed to read {length} bytes at address 0x{address.ToInt64():X}.");
            return buffer;
        }

        public void WriteBytes(IntPtr address, byte[] buffer)
        {
            WriteProcessMemory(processHandle, address, buffer, (uint)buffer.Length, out IntPtr bytesWritten);
            if (bytesWritten.ToInt64() != buffer.Length)
                throw new Exception($"Failed to write {buffer.Length} bytes at address 0x{address.ToInt64():X}.");
        }

        public void Dispose()
        {
            CloseProcess();
        }
    }
}