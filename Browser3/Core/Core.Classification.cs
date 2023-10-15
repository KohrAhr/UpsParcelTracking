using System.Collections.ObjectModel;
using Browser3.Types;

namespace Browser3.Core
{
    public static class CoreClassification
    {
        public static ObservableCollection<CommonIdValueObject> ShowTop = new ObservableCollection<CommonIdValueObject>();
        public static ObservableCollection<CommonIdValueObject> CommonPhrases = new ObservableCollection<CommonIdValueObject>();
        public static ObservableCollection<CommonIdValueObject> ShippingStatus = new ObservableCollection<CommonIdValueObject>();
        public static ObservableCollection<CommonIdValueObject> LateStatus = new ObservableCollection<CommonIdValueObject>();

        private static readonly (int, string)[, ] ClassificationShowTop = new (int, string)[, ]
        {
            {( 0, "" )},
            {( 1, "100")},
            {( 2, "250")},
            {( 3, "500")},
            {( 4, "1000")},
            {( 5, "2000")},
            {( 6, "5000")},
            {( 7, "10000")},
            {( 8, "20000")},
            {( 9, "50000")}
        };

        private static readonly (int, string)[,] ClassificationCommonPhrases = new (int, string)[,]
        {
            {( 0, "" )},
            {( 1, "Claim")},
            {( 2, "Lost")},
            {( 3, "No saturday guarantee" )},
            {( 4, "Tracer" )},
            {( 5, "Damage" )},
            {( 6, "Return" )},
            {( 7, "A correct" )},
            {( 8, "Is incorrect" )},
            {( 9, "Canceled the order" )},
            {( 10, "Correct street number is needed" )},
            {( 11, "Adverse weather conditions" )},
            {( 12, "Business was closed today" )},
            {( 13, "Correct company" )},
            {( 14, "Multiple errors exist in the address label" )},
            {( 15, "Receiver is on a Holiday" )},
            {( 16, "Receiver refuse" )},
            {( 17, "Receiver requested" )},
            {( 18, "Receiver is out" )},
            {( 19, "on the 2nd attempt" )},
            {( 20, "Late UPS trailer" )}
        };


        private static readonly (int, string)[,] ClassificationShippingStatus = new (int, string)[,]
        {
            {( 0, "" )},
            {( 1, "PICKUP SCAN" )},
            {( 2, "IN TRANSIT TO" )},
            {( 3, "BILLING INFORMATION VOIDED" )},
            {( 4, "BILLING INFORMATION RECEIVED" )},
            {( 5, "DELIVERED" )},
            {( 6, "EXCEPTION" )},
            {( 7, "RETURNED TO SHIPPER" )},
            {( 8, "ORIGIN SCAN" )}
        };

        private static readonly (int, string)[,] ClassificationLateStatus = new (int, string)[,]
        {
            {( 0, "" )},
            {( 1, "Could be refunded" )},
            {( 2, "Already refunded" )},
            {( 3, "Cannot be refunded" )}
        };

        static CoreClassification()
        {
            foreach((int, string) item in ClassificationShowTop)
            {
                ShowTop.Add(new CommonIdValueObject() { ID = item.Item1, Name = item.Item2 });
            }

            foreach ((int, string) item in ClassificationCommonPhrases)
            {
                CommonPhrases.Add(new CommonIdValueObject() { ID = item.Item1, Name = item.Item2 });
            }

            foreach ((int, string) item in ClassificationShippingStatus)
            {
                ShippingStatus.Add(new CommonIdValueObject() { ID = item.Item1, Name = item.Item2 });
            }

            foreach ((int, string) item in ClassificationLateStatus)
            {
                LateStatus.Add(new CommonIdValueObject() { ID = item.Item1, Name = item.Item2 });
            }
        }
    }
}
