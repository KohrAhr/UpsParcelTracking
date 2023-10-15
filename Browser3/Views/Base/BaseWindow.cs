using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Browser3.Core;

namespace Browser3.Views.Base
{
    /// <summary>
    ///     Low level
    ///     Any Window, except special window,
    ///     should restore and save UI settings
    /// </summary>
    public class BaseWindow : Window
    {
        private const string CONST_WIDTH = "Width";
        private const string CONST_HEIGHT = "Height";
        private const string CONST_LEFT = "Left";
        private const string CONST_TOP = "Top";
        private const int CONST_NO_VALUE = -1;
        private const int CONST_DEF_LEFT = 128;
        private const int CONST_DEF_TOP = 128;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (sender == null || sender is not Window)
            {
                return;
            }

            // If this window has Custom Location settings, then exit
            if (WindowStartupLocation != WindowStartupLocation.Manual)
            {
                return;
            }

            // Save UI settings only for normal windows (not minimized & not maximized)
            if (WindowState == WindowState.Normal)
            {
                // Save Width & Height for Resiable windows
                if (WindowStyle == WindowStyle.ThreeDBorderWindow || WindowStyle == WindowStyle.SingleBorderWindow)
                {
                    string? name = sender.ToString();

                    if (String.IsNullOrEmpty(name))
                    {
                        return;
                    }

                    if (ResizeMode != ResizeMode.NoResize && ResizeMode != ResizeMode.CanMinimize)
                    {
                        AppData.AppIniFile.WriteInteger(name, CONST_WIDTH, (int)Width);
                        AppData.AppIniFile.WriteInteger(name, CONST_HEIGHT, (int)Height);
                    }
                    AppData.AppIniFile.WriteInteger(name, CONST_TOP, (int)Top);
                    AppData.AppIniFile.WriteInteger(name, CONST_LEFT, (int)Left);
                }
            }
        }

        /// <summary>
        ///     Restore UI settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender == null || sender is not Window)
            {
                return;
            }

            // If this window has Custom Location settings, then exit
            if (WindowStartupLocation != WindowStartupLocation.Manual)
            {
                return;
            }

            // If previous value outside of Window, use 300 x 300

            // Load Width & Height for Resiable windows
            if (WindowStyle == WindowStyle.ThreeDBorderWindow || WindowStyle == WindowStyle.SingleBorderWindow)
            {
                string? name = sender.ToString();

                if (String.IsNullOrEmpty(name)) 
                {
                    return;
                }

                int value = CONST_NO_VALUE;

                if (ResizeMode != ResizeMode.NoResize && ResizeMode != ResizeMode.CanMinimize)
                {
                    value = AppData.AppIniFile.ReadInteger(name, CONST_WIDTH, CONST_NO_VALUE);
                    if (value != CONST_NO_VALUE)
                    {
                        Width = Convert.ToInt32(value);
                    }

                    value = AppData.AppIniFile.ReadInteger(name, CONST_HEIGHT, CONST_NO_VALUE);
                    if (value != CONST_NO_VALUE)
                    {
                        Height = Convert.ToInt32(value);
                    }
                }

                value = AppData.AppIniFile.ReadInteger(name, CONST_LEFT, CONST_NO_VALUE);
                if (value != CONST_NO_VALUE)
                {
                    if (value < 0)
                    {
                        value = 0;
                    }
                    if (value > SystemParameters.VirtualScreenWidth)
                    {
                        value = CONST_DEF_LEFT;
                    }
                    Left = Convert.ToInt32(value);
                }

                value = AppData.AppIniFile.ReadInteger(name, CONST_TOP, CONST_NO_VALUE);
                if (value != CONST_NO_VALUE)
                {
                    if (value < 0)
                    {
                        value = 0;
                    }
                    if (value > SystemParameters.VirtualScreenHeight)
                    {
                        value = CONST_DEF_TOP;
                    }
                    Top = Convert.ToInt32(value);
                }
            }
        }
    }
}
