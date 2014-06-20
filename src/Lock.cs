#region Using

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using CursorLock.src;

#endregion

namespace CursorLock
{
    class Lock
    {
        private RECT defClip;
        private RECT fBoundsRect;

        public Lock(Screen selScreen)
        {
            GetClipCursor(ref defClip);

            // Sets rectangle to bounds of currently selected screen
            fBoundsRect = (RECT)selScreen.Bounds;
        }

        public void LockMouse()
        {
            ClipCursor(ref fBoundsRect);
        }

        public void UnlockMouse()
        {
            ClipCursor(ref defClip);
        }

        [DllImport("user32")]
        public static extern bool ClipCursor(ref RECT lpRect);

        [DllImport("user32")]
        public static extern bool GetClipCursor(ref RECT lpRect);
    }
}