using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Lib.MVVM.Net6;

namespace Browser3.Types
{
    /// <summary>
    ///     Why not KeyValuePair int, string ?
    ///     I need Proper Names for XAML Binding ?
    /// </summary>
    public class CommonIdValueObject : PropertyChangedNotificationEx
    {
        public int ID
        {
            get => GetValue(() => ID);
            set => SetValue(() => ID, value);
        }

        public string Name
        {
            get => GetValue(() => Name);
            set => SetValue(() => Name, value);
        }
    }
}
