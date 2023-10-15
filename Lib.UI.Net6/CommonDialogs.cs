using System.Windows;

namespace Lib.UI.Net6
{
    public static class CommonDialogs
    {
        /// <summary>
        ///     Default result NONE
        /// </summary>
        /// <param name="aTitle"></param>
        /// <param name="aMessage"></param>
        /// <param name="aButtons"></param>
        /// <param name="aImage"></param>
        /// <returns></returns>
        private static MessageBoxResult ShowMessage(string aTitle, string aMessage, MessageBoxButton aButtons, MessageBoxImage aImage)
        {
            MessageBoxResult result = MessageBoxResult.None;

            WindowsUI.RunWindowDialog(() =>
            {
                result = MessageBox.Show(
                    aMessage,
                    aTitle,
                    aButtons,
                    aImage
                );
            });

            return result;
        }

        /// <summary>
        ///     Show Information window
        /// </summary>
        /// <param name="aTitle"></param>
        /// <param name="aMessage"></param>
        public static void ShowInfoMessage(string aTitle, string aMessage)
        {
            ShowMessage(aTitle, aMessage, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        ///     Show confirmation window
        ///     Default result NONE
        /// </summary>
        /// <param name="aTitle"></param>
        /// <param name="aMessage"></param>
        /// <returns></returns>
        public static MessageBoxResult ShowConfirmationMessage(string aTitle, string aMessage, MessageBoxButton aButtons = MessageBoxButton.YesNo)
        {
            MessageBoxResult result = ShowMessage(aTitle, aMessage, aButtons, MessageBoxImage.Question);

            return result;
        }

        /// <summary>
        ///     Show Warning window
        ///     Default result NONE
        /// </summary>
        /// <param name="aTitle"></param>
        /// <param name="aMessage"></param>
        /// <returns></returns>
        public static MessageBoxResult ShowWarningMessage(string aTitle, string aMessage, MessageBoxButton aButtons = MessageBoxButton.OK)
        {
            MessageBoxResult result = ShowMessage(aTitle, aMessage, aButtons, MessageBoxImage.Warning);

            return result;
        }

        /// <summary>
        ///     Show Error window
        /// </summary>
        /// <param name="aTitle"></param>
        /// <param name="aMessage"></param>
        /// <returns></returns>
        public static MessageBoxResult ShowErrorMessage(string aTitle, string aMessage, MessageBoxButton aButtons = MessageBoxButton.OK)
        {
            MessageBoxResult result = ShowMessage(aTitle, aMessage, aButtons, MessageBoxImage.Error);

            return result;
        }
    }
}
