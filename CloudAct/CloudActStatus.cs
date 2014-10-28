using System;

namespace CloudAct
{
    /// <summary>
    /// RK_REL_ACT_STATUSES
    /// </summary>
    public class CloudActStatus
    {
        /// <summary>
        /// ID_ACT_STATUS
        /// </summary>
        public decimal IdStatus { get; set; }

        /// <summary>
        /// ID_SOTRUDNIK
        /// </summary>
        public decimal IdSotrudnik { get; set; }

        /// <summary>
        /// STATUS_DATE
        /// </summary>
        public DateTime StatusDate { get; set; }

        /// <summary>
        /// MSG
        /// </summary>
        public string Message { get; set; }
    }
}
