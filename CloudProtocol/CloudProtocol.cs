using System;

namespace CloudProtocol
{
    /// <summary>
    /// RES_PROTOCOL_IZM_TP
    /// </summary>
    public class CloudProtocol
    {
        /// <summary>
        /// ID_PROTOCOL
        /// </summary>
        public decimal Id { get; set; }

        /// <summary>
        /// NUM_PROTOCOL
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// DATE_PROTOCOL
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// ID_CLIENT
        /// </summary>
        public decimal IdClient { get; set; }

        /// <summary>
        /// ID_RES
        /// </summary>
        public decimal IdRes { get; set; }

        /// <summary>
        /// ID_MEASUR_CONDITION (будет заменено на REL IList)
        /// </summary>
        public decimal IdMeasureCondition { get; set; }

        /// <summary>
        /// MEASUR_CONDITION (будет удалено)
        /// </summary>
        public string MeasureCondition { get; set; }

        /// <summary>
        /// ID_RK_EQUIPMENTSET (будет заменено на REL IList)
        /// </summary>
        public decimal IdEquipmentset { get; set; }

        /// <summary>
        /// EQUIPMENTSET (будет удалено)
        /// </summary>
        public string Equipmentset { get; set; }

        /// <summary>
        /// ID_METOD (будет заменено на REL IList) 
        /// </summary>
        public decimal IdMethodic { get; set; }

        /// <summary>
        /// METOD (будет удалено)
        /// </summary>
        public string Methodic { get; set; }

        /// <summary>
        /// DESCRIPTION
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ZADANIE_NUM 
        /// </summary>
        public string TaskNumber { get; set; }
    }
}
