using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudAct
{
    /// <summary>
    /// ACT_WORK_TIME
    /// </summary>
    public class CloudActWorkTime
    {
        /// <summary>
        /// ID_ACT_WORK_TIME
        /// </summary>
        public decimal Id { get; set; }

        /// <summary>
        /// DTBEGIN
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// DTEND
        /// </summary>
        public DateTime DateTo { get; set; }
    }
}
