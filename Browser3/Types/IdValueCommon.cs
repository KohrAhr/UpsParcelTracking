using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.MVVM.Net6;

namespace Browser3.Types
{
    public class IdValueCommon : PropertyChangedNotificationEx
    {
        public int? ID
        {
            get => GetValue(() => ID);
            set => SetValue(() => ID, value);
        }

        public string ResultValue
        {
            get => GetValue(() => ResultValue);
            set => SetValue(() => ResultValue, value);
        }
    }
}
