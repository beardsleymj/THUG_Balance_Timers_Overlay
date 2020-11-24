using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace THUG_Balance_Timers_Overlay
{
    class THUGTimers
    {
        private const int PROCESS_ALL_ACCESS = (0x1F0FFF);
        
        [DllImport("User32.dll")]
        public static extern IntPtr FindWindowA(String lpClassName, String lpWindowName);
        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(int processAccess, bool bInheritHandle, uint processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(
        IntPtr hProcess,
        IntPtr lpBaseAddress,
        [Out, MarshalAs(UnmanagedType.AsAny)] object lpBuffer,
        int dwSize,
        out IntPtr lpNumberOfBytesRead);

        IntPtr hWnd;
        IntPtr hProcess;
        uint pid;
        IntPtr manual_timer_address;
        IntPtr grind_timer_address;
        double manual_timer;
        double grind_timer;

        byte[] buffer = new byte[4];
        IntPtr bytes_read;


        public THUGTimers()
        {
            FindTHUGProcessHandle();
        }

        public void FindTHUGProcessHandle()
        {
            hWnd = FindWindowA(null, "THUG PRO");
            // THUG PRO not found
            if (hWnd == (IntPtr)0)
                hWnd = FindWindowA(null, "Tony Hawk's Underground 2");

            // THUG PRO / THUG2 not found
            if (hWnd == (IntPtr)0)
                return;

            GetWindowThreadProcessId(hWnd, out pid);

            hProcess = OpenProcess(PROCESS_ALL_ACCESS, false, pid);
            if (hProcess == null)
            {
                MessageBox.Show("Cannot Open Process.");
            }

            manual_timer_address = FindManualTimerAddress();
            grind_timer_address = FindGrindTimerAddress();
        }

        private IntPtr FindManualTimerAddress()
        {
            IntPtr manual_timer_address = (IntPtr)0x6F0DC4; //  0x400000 + 2F0DC4

            ReadProcessMemory(hProcess, manual_timer_address, buffer, 4, out bytes_read);
            manual_timer_address = (IntPtr)BitConverter.ToUInt32(buffer, 0);
            ReadProcessMemory(hProcess, manual_timer_address + 0x10, buffer, 4, out bytes_read);
            manual_timer_address = (IntPtr)BitConverter.ToUInt32(buffer, 0);
            ReadProcessMemory(hProcess, manual_timer_address + 0x60, buffer, 4, out bytes_read);
            manual_timer_address = (IntPtr)BitConverter.ToUInt32(buffer, 0);
            ReadProcessMemory(hProcess, manual_timer_address + 0x70, buffer, 4, out bytes_read);
            manual_timer_address = (IntPtr)BitConverter.ToUInt32(buffer, 0);
            manual_timer_address += 0xDC;
            return manual_timer_address;
        }

        private IntPtr FindGrindTimerAddress()
        {
            IntPtr grind_timer_address = (IntPtr)0x6F0DC8; // 0x400000 + 2F0DC8

            ReadProcessMemory(hProcess, grind_timer_address, buffer, 4, out bytes_read);
            grind_timer_address = (IntPtr)BitConverter.ToUInt32(buffer, 0);
            ReadProcessMemory(hProcess, grind_timer_address + 0x10, buffer, 4, out bytes_read);
            grind_timer_address = (IntPtr)BitConverter.ToUInt32(buffer, 0);
            ReadProcessMemory(hProcess, grind_timer_address + 0x10, buffer, 4, out bytes_read);
            grind_timer_address = (IntPtr)BitConverter.ToUInt32(buffer, 0);
            ReadProcessMemory(hProcess, grind_timer_address + 0x10, buffer, 4, out bytes_read);
            grind_timer_address = (IntPtr)BitConverter.ToUInt32(buffer, 0);
            ReadProcessMemory(hProcess, grind_timer_address + 0x10, buffer, 4, out bytes_read);
            grind_timer_address = (IntPtr)BitConverter.ToUInt32(buffer, 0);
            ReadProcessMemory(hProcess, grind_timer_address + 0x70, buffer, 4, out bytes_read);
            grind_timer_address = (IntPtr)BitConverter.ToUInt32(buffer, 0);
            ReadProcessMemory(hProcess, grind_timer_address + 0x1C4, buffer, 4, out bytes_read);
            grind_timer_address = (IntPtr)BitConverter.ToUInt32(buffer, 0);
            grind_timer_address += 0xA4;
            return grind_timer_address;
        }

        public double GetManualTimer()
        {
            ReadProcessMemory(hProcess, manual_timer_address, buffer, 4, out bytes_read);
            manual_timer = Convert.ToDouble(System.BitConverter.ToSingle(buffer, 0));
            if ((int)bytes_read == 0)
                FindTHUGProcessHandle();
            return manual_timer;
        }

        public double GetGrindTimer()
        {
            ReadProcessMemory(hProcess, grind_timer_address, buffer, 4, out bytes_read);
            grind_timer = Convert.ToDouble(System.BitConverter.ToSingle(buffer, 0));
            return grind_timer;
        }
    }
}
