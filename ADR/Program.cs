using System;
using System.Runtime.InteropServices;



namespace ADR
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("DLL Address Resolution Program");
            Console.WriteLine("Author : Souhardya Sardar");


            Console.WriteLine();
            Console.WriteLine("Enter dll name (Ex - User32.dll) :");
            var dllname = Console.ReadLine();

            int hModule = LoadLibrary(dllname); // load dll 
            
            if (hModule == 0)
            {
                Console.WriteLine("dll can't be loaded");
                Console.WriteLine("Exiting....");
                System.Threading.Thread.Sleep(5000);
                Environment.Exit(0);
            } 


            Console.WriteLine(); // just for space don't mind
            Console.WriteLine("Function name (Ex- MessageBoxW) :");
            var funcname = Console.ReadLine();
            IntPtr Farproc = GetProcAddress(hModule, funcname); // finalise
            
            string hex = Farproc.ToString("X"); // convert result decimal to hex

            Console.WriteLine();
            Console.WriteLine("Address is : " + "Ox" + hex);
            Console.ReadKey();
            Console.Write("Press Enter to exit..");


        }


        [DllImport("kernel32.dll", EntryPoint = "LoadLibrary")]
        static extern int LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string lpLibFileName);

        [DllImport("kernel32.dll", EntryPoint = "GetProcAddress")]
        static extern IntPtr GetProcAddress(int hModule, [MarshalAs(UnmanagedType.LPStr)] string lpProcName);

    }
}
