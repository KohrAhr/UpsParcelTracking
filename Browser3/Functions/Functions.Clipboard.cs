using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Browser3.Functions
{
    public static class ClipboardFunctions
    {
        public static void SetText(string aValue)
        {
            Clipboard.SetText(aValue);
        }


        /// <summary>
        ///     Copy to clipboard value from any class for any property
        /// </summary>
        /// <typeparam name="T">Type of source object</typeparam>
        /// <param name="aSelectedItem">Object with property</param>
        /// <param name="aFieldName">Property name</param>
        /// <returns>False is property not found or object is null</returns>
        public static bool CopyValueToClipboard<T>(T aSelectedItem, string aFieldName)
        {
            if (String.IsNullOrEmpty(aFieldName))
            {
                throw new ArgumentException("aFieldName cannot be empty");
            }

            // Get current object entry
            // If its not empty get field we need
            if (aSelectedItem == null)
            {
                return false;
            }

            PropertyInfo? property = aSelectedItem.GetType().GetProperty(aFieldName);
            if (property == null)
            {
                return false;
            }

            string? val = property.GetValue(aSelectedItem, null)?.ToString();
            if (String.IsNullOrEmpty(val))
            {
                val = string.Empty;
            }

            //            string val = selectedItem.GetType().GetProperties().Where(x => x.Name == field)?.FirstOrDefault()?.GetValue(selectedItem, null).ToString(); 

            ClipboardFunctions.SetText(val);

            return true;
        }

    }
}
