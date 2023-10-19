using System;

using System.Windows.Input;

namespace Lib.UI.Net6
{
    public class WaitCursor : IDisposable
    {
        private readonly Cursor originalCursor;
        private readonly Cursor customCursor;

        public WaitCursor() : this(null) { }

        public WaitCursor(Cursor? customCursor)
        {
            originalCursor = Mouse.OverrideCursor;
            this.customCursor = customCursor ?? Cursors.Wait;
            Mouse.OverrideCursor = this.customCursor;
            Mouse.UpdateCursor();
        }

        public void Dispose()
        {
            Mouse.OverrideCursor = originalCursor;
            Mouse.UpdateCursor();
        }
    }

    ///// <summary>
    ///// 
    ///// </summary>
    ///// <param name="parentWindow"></param>
    ///// <param name="aAction"></param>
    //public static void RunInCursorBusyMode(Action aAction)
    //{
    //    Cursor cursor = Mouse.OverrideCursor;
    //    Mouse.OverrideCursor = Cursors.Wait;
    //    Mouse.UpdateCursor();
    //    try
    //    {
    //        aAction.Invoke();
    //    }
    //    finally
    //    {
    //        Mouse.OverrideCursor = cursor;
    //        Mouse.UpdateCursor();
    //    }
    //}

}
