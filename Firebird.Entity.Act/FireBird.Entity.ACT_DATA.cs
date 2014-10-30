using AsrkRf.Rpl.Common;
using FluentNHibernate.Mapping;
using System;
namespace FireBird.Entity
{
	public class ACT_DATA : IFirebird
	{
		public virtual DateTime ACT_DATE { get; set; } /* Original name ACT_DATE*/
		public virtual string ACT_NUM { get; set; } /* Original name ACT_NUM*/
		public virtual string CLIENT_NAME { get; set; } /* Original name CLIENT_NAME*/
		public virtual int DEPARTCOUNT { get; set; } /* Original name DEPARTCOUNT*/
		public virtual decimal ID_ACT_DATA { get; set; } /* Original name ID_ACT_DATA*/
		public virtual decimal ID_MAN_CONFIRM { get; set; } /* Original name ID_MAN_CONFIRM*/
		public virtual decimal ID_RK_REQUEST_TASK { get; set; } /* Original name ID_RK_REQUEST_TASK*/
		public virtual decimal ID_SP_ACT_EVENT { get; set; } /* Original name ID_SP_ACT_EVENT*/
		public virtual decimal ID_SP_ACTIVITY { get; set; } /* Original name ID_SP_ACTIVITY*/
		public virtual decimal ID_SP_DOCUMENT { get; set; } /* Original name ID_SP_DOCUMENT*/
		public virtual int IS_DEL { get; set; } /* Original name IS_DEL*/
		public virtual string LOCATION { get; set; } /* Original name LOCATION*/
		public virtual int MANHOUR { get; set; } /* Original name MANHOUR*/
		public virtual string NAME_DOL { get; set; } /* Original name NAME_DOL*/
		public virtual string OSNOVANIE { get; set; } /* Original name OSNOVANIE*/
		public virtual string PERIOD { get; set; } /* Original name PERIOD*/
		public virtual string PROTOCOL_DATA_STRING { get; set; } /* Original name PROTOCOL_DATA_STRING*/
		public virtual int RPL_ID_SERVER { get; set; } /* Original name RPL_ID_SERVER*/
		public virtual string VYVOD { get; set; } /* Original name VYVOD*/
	}
	public class ACT_DATAMap : ClassMap<ACT_DATA>
	{
		public ACT_DATAMap()
		{
			Table("ACT_DATA");
			Id(x => x.ID_ACT_DATA).Column("ID_ACT_DATA").GeneratedBy.TriggerIdentity();
			Map(x => x.ID_SP_ACTIVITY).Column("ID_SP_ACTIVITY");
			Map(x => x.ID_SP_DOCUMENT).Column("ID_SP_DOCUMENT");
			Map(x => x.ID_MAN_CONFIRM).Column("ID_MAN_CONFIRM");
			Map(x => x.ID_RK_REQUEST_TASK).Column("ID_RK_REQUEST_TASK");
			Map(x => x.ID_SP_ACT_EVENT).Column("ID_SP_ACT_EVENT");
			Map(x => x.ACT_DATE).Column("ACT_DATE");
			Map(x => x.IS_DEL).Column("IS_DEL");
			Map(x => x.RPL_ID_SERVER).Column("RPL_ID_SERVER");
			Map(x => x.DEPARTCOUNT).Column("DEPARTCOUNT");
			Map(x => x.MANHOUR).Column("MANHOUR");
			Map(x => x.ACT_NUM).Column("ACT_NUM");
			Map(x => x.OSNOVANIE).Column("OSNOVANIE");
			Map(x => x.NAME_DOL).Column("NAME_DOL");
			Map(x => x.VYVOD).Column("VYVOD");
			Map(x => x.PERIOD).Column("PERIOD");
			Map(x => x.LOCATION).Column("LOCATION");
			Map(x => x.PROTOCOL_DATA_STRING).Column("PROTOCOL_DATA_STRING");
			Map(x => x.CLIENT_NAME).Column("CLIENT_NAME");
		}
	}
}

