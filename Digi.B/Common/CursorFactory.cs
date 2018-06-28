using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Digi.B
{
    public class CursorFactory
    {
        [DllImport("user32.dll",
            EntryPoint = "LoadCursorFromFileW",
            CharSet = CharSet.Unicode)]
        private static extern IntPtr LoadCursorFromFile(String str);

        static Cursor pWaitCursor = null;


        /// <summary>
        /// 创建一个等待的动态光标
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Cursor WaitCursor()
        {
            if (null == pWaitCursor) {
                string filename = "wait.ani";
                IntPtr hCursor;
                try {
                    hCursor = LoadCursorFromFile(filename);
                    if (!IntPtr.Zero.Equals(hCursor)) {
                        pWaitCursor = new Cursor(hCursor);
                    } else {
                        throw new
                        ApplicationException("Could not create cursor from file " + filename);
                    }
                } catch {
                    //throw new ApplicationException(ex.Message);
                    pWaitCursor = Cursors.WaitCursor;
                }
            }
                return pWaitCursor;
        }

    }

}