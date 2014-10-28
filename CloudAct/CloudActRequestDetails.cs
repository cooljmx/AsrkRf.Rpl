using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudAct
{
    /// <summary>
    /// RK_REL_ACT_REQUEST_DETAILS
    /// </summary>
    public class CloudActRequestDetails
    {
        /// <summary>
        /// ID_REL_ACT_REQUEST_DETAILS
        /// </summary>
        public decimal Id { get; set; }

        /// <summary>
        /// REQUEST_TABLE_NAME
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// REQUEST_TABLE_ID_KEY
        /// </summary>
        public decimal TableKeyValue { get; set; }
    }
}
