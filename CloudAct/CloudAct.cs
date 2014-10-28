using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudAct
{
    /// <summary>
    /// ACT_DATA
    /// </summary>
    public class CloudAct
    {
        private readonly IList<CloudProtocol> protocols = new List<CloudProtocol>();
        private readonly IList<decimal> actPerformers = new List<decimal>();
        private readonly IList<decimal> rkoList = new List<decimal>();
        private readonly IList<CloudActWorkTime> workTimes = new List<CloudActWorkTime>();
        private readonly IList<decimal> tasks = new List<decimal>();
        private readonly IList<CloudActStatus> actStatuses = new List<CloudActStatus>();
        private readonly IList<decimal> actAuthors = new List<decimal>();
        private readonly IList<CloudActErrorClass> actErrorClasses = new List<CloudActErrorClass>();
        private readonly IList<CloudActRequestDetails> actRequestDetails = new List<CloudActRequestDetails>();

        /// <summary>
        /// ID_ACT_DATA
        /// </summary>
        public decimal Id { get; set; }

        /// <summary>
        /// ACT_NUM
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// ACT_DATE
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// ID_SP_ACTIVITY [SP_ACTIVITY]
        /// </summary>
        public decimal IdActivity { get; set; }

        /// <summary>
        /// OSNOVANIE
        /// </summary>
        public string ConditionAsText { get; set; }

        /// <summary>
        /// VYVOD
        /// </summary>
        public string Conclusion { get; set; }

        /// <summary>
        /// LOCATION
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// PROTOCOL_DATA_STRING
        /// </summary>
        public string ProtocolsAsText { get; set; }

        /// <summary>
        /// ID_MAN_CONFIRM [SOTRUDNIK]
        /// </summary>
        public decimal IdConfirmer { get; set; }

        /// <summary>
        /// DEPARTCOUNT
        /// </summary>
        public int DepartureCount { get; set; }

        /// <summary>
        /// MANHOUR
        /// </summary>
        public double ManHours { get; set; }

        /// <summary>
        /// ID_SP_REQUEST_TASK [RK_REQUEST_TASK]
        /// </summary>
        public decimal IdRequestTasks { get; set; }

        /// <summary>
        /// ID_ORDER_TYPE [ORDER_TYPE]
        /// </summary>
        public decimal IdOrderType { get; set; }

        /// <summary>
        /// RK_REL_ACT_PROTOCOL [REL]
        /// </summary>
        public IList<CloudProtocol> Protocols { get { return protocols; } }

        /// <summary>
        /// ACT_PERFORMER [REL]
        /// </summary>
        public IList<decimal> ActPerformers { get { return actPerformers; } }

        /// <summary>
        /// ACT_SR_IZM [REL]
        /// </summary>
        public IList<decimal> RkoList { get { return rkoList; } }

        /// <summary>
        /// ACT_WORK_TIME
        /// </summary>
        public IList<CloudActWorkTime> WorkTimes { get { return workTimes; } }

        /// <summary>
        /// REL_RK_ACT_ZADACHA [REL]
        /// </summary>
        public IList<decimal> Tasks { get { return tasks; } }

        /// <summary>
        /// RK_REL_ACT_STATUSES [REL]
        /// </summary>
        public IList<CloudActStatus> ActStatuses { get { return actStatuses; } }

        /// <summary>
        /// RK_ACT_ACTUAL_LINKS.ID_REL_ACT_STATUS
        /// </summary>
        public decimal IdCurrentStatus { get; set; }

        /// <summary>
        /// RK_REL_ACT_AUTHORS
        /// </summary>
        public IList<decimal> ActAuthors { get { return actAuthors; } }

        /// <summary>
        /// RK_REL_ACT_ERROR_CLASS
        /// </summary>
        public IList<CloudActErrorClass> ActErrorClasses { get { return actErrorClasses; } }

        /// <summary>
        /// RK_REL_ACT_REQUEST_DETAILS [?]
        /// </summary>
        public IList<CloudActRequestDetails> ActRequestDetails { get { return actRequestDetails; } }
    }
}
