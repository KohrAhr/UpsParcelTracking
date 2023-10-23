using System.Linq;
using Browser3.Core;

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

                result = TNTrackHTML;

                result = result?.Replace(";", "; ");

                return result;
            }

            set { }
        }

        public string? TNShippingStatusEx
        {
            get
            {
                string? result;

                result = CoreClassification.ShippingStatus.FirstOrDefault(x => x.ID == TNShippingStatus)?.Name;

                return result;
            }

            set { }
        }

        /// <summary>
        ///     LEFT OUTER JOIN dbo.Company
        /// </summary>
        public string CompanyTitle
        {
            get; set;
        } = string.Empty;
    }
}
