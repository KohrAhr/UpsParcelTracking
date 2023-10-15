using Browser3.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Browser3.Types
{
    /// <summary>
    ///     Extended specially for View
    /// </summary>
    public class TNBaseEx : TNBase
    {
        /// <summary>
        ///     To be moved into different Table
        /// </summary>
        public string? TNTrackHTMLEx
        {
            get 
            {
                string? result;

                result = GetValue(() => TNTrackHTML);

                result = result?.Replace(";", "; ");

                return result;
            }
            set => SetValue(() => TNTrackHTML, value);
        }

        public string? TNShippingStatusEx
        {
            get
            {
                string? result;

                result = CoreClassification.ShippingStatus.FirstOrDefault(x => x.ID == TNShippingStatus)?.Name;

                return result;
            }
            set => SetValue(() => TNTrackHTML, value);
        }

        /// <summary>
        ///     LEFT OUTER JOIN dbo.Company
        /// </summary>
        public string CompanyTitle
        {
            get => GetValue(() => CompanyTitle);
            set => SetValue(() => CompanyTitle, value);
        }
    }
}
