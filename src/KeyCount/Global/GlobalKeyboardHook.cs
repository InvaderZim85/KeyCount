using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyCount.Global
{
    /// <summary>
    /// Provides the global keyboard hook
    /// </summary>
    internal sealed class GlobalKeyboardHook
    {
        [DllImport("user32.dll")]
        static extern int CallNextHookEx(IntPtr hhk, int code, int wParam, ref KeyBoardHookStruct lParam);
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, KeyboardHook callback, IntPtr hInstance, uint threadId);
        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);
        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        public delegate int KeyboardHook(int code, int wParam, ref KeyBoardHookStruct lParam);
        

        public struct KeyBoardHookStruct
        {
            public int VkCode;
            public int ScanCode;
            public int Flags;
            public int Time;
            public int DwExtraInfo;
        }

        private const int WhKeyboardLl = 13;
        private const int WmKeyup = 0x0101;
        private const int WmSyskeyup = 0x0105;

        /// <summary>
        /// The keyboard hook
        /// </summary>
        private readonly KeyboardHook _keyboardHook;

        /// <summary>
        /// The list with the hooked keys
        /// </summary>
        private List<Keys> HookedKeys { get; } = new();

        /// <summary>
        /// Pointer of the hook
        /// </summary>
        private IntPtr _hook = IntPtr.Zero;

        /// <summary>
        /// Occurs when a key was released
        /// </summary>
        public event KeyEventHandler? KeyUp;

        /// <summary>
        /// Creates a new instance of the <see cref="GlobalKeyboardHook"/>
        /// </summary>
        public GlobalKeyboardHook()
        {
            _keyboardHook = HookProc;
            // This starts the hook. You can leave this as comment and you have to start it manually (the thing I do in the tutorial, with the button)
            // Or delete the comment mark and your hook will start automatically when your program starts (because a new GlobalKeyboardHook object is created)
            // That's why there are duplicates, because you start it twice! I'm sorry, I haven't noticed this...
            // hook(); <-- Choose!
        }

        /// <summary>
        /// Starts the hook
        /// </summary>
        public void Start()
        {
            InitKeyList();

            var hInstance = LoadLibrary("User32");
            _hook = SetWindowsHookEx(WhKeyboardLl, _keyboardHook, hInstance, 0);
        }

        /// <summary>
        /// Stops the hook
        /// </summary>
        public void Stop()
        {
            UnhookWindowsHookEx(_hook);
        }

        /// <summary>
        /// Init the hooked key list
        /// </summary>
        private void InitKeyList()
        {
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                HookedKeys.Add(key);
            }
        }

        /// <summary>
        /// Will be executed when a key was pressed
        /// </summary>
        /// <param name="code">The key code</param>
        /// <param name="wParam">The w param</param>
        /// <param name="lParam">The l param</param>
        /// <returns>1 if the key was handled</returns>
        private int HookProc(int code, int wParam, ref KeyBoardHookStruct lParam)
        {
            if (code < 0)
                return CallNextHookEx(_hook, code, wParam, ref lParam);

            var key = (Keys)lParam.VkCode;
            if (!HookedKeys.Contains(key))
                return CallNextHookEx(_hook, code, wParam, ref lParam);

            var kArg = new KeyEventArgs(key);
            if (wParam is WmKeyup or WmSyskeyup)
                KeyUp?.Invoke(this, kArg);

            return kArg.Handled ? 1 : CallNextHookEx(_hook, code, wParam, ref lParam);
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~GlobalKeyboardHook()
        {
            Stop();
        }
    }
}
