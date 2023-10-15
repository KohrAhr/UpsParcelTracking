using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Browser3.Core
{
    public static class CoreQueriers
    {
        public static readonly string CONST_SIMPLE_LIST_OF_COMPANY = 
            "SELECT distinct TOP (1000) [ID], [CompanyTitle] as [Name] " +
            "FROM [dbo].[Company] " +
            "order by [Name];";

        public static readonly string CONST_SIMPLE_LIST_OF_SUBCOMPANY = 
            "SELECT distinct TOP (1000) [TNSubCompany] as [Name] " +
            "FROM [dbo].[TNs] " +
            "order by [Name];";

        public static readonly string CONST_SIMPLE_LIST_OF_ACCOUNTS = 
            "SELECT distinct TOP (1000) [TNAccountID] as [Name] " +
            "FROM [dbo].[TNs] " +
            "where ([TNAccountID] is Not null) " +
            "order by [Name];";
    }
}
