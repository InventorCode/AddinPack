
using System;

namespace InventorCode.AddinPack
{
    /// <summary>
    /// This class is used to wrap a Win32 hWnd as a .Net IWind32Window class.
    /// This is primarily used for parenting a dialog to the Inventor window.

    /// For example:
    /// myForm.Show(New WindowWrapper(g_inventorApplication.MainFrameHWND))

    /// </summary>
    public class WindowWrapper : System.Windows.Forms.IWin32Window
    {
        private IntPtr _hwnd;

        public WindowWrapper(IntPtr handle)
        {
            _hwnd = handle;
        }

        IntPtr System.Windows.Forms.IWin32Window.Handle
            { get => _hwnd; }
    }
}